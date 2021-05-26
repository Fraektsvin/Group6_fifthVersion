using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTier.Repository.TransactionREPO
{
    public class TransactionRepository : ITransactionRepository
    {
        public async Task<Transaction> TransferMoneyAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();
            {
                 var register = await context.AddAsync(transaction);
                 Console.WriteLine("add before saving ------->>>>>>>> " + register);
                 //await context.SaveChangesAsync();
                 Console.WriteLine("add transaction ------->>>>>>>> " + register);
                 await UpdateSenderAsync(transaction);
                 await UpdateReceiverAsync(transaction);
                                
                 return register.Entity;
            }
        }

        private static async Task UpdateReceiverAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();
            {
                Customer customer = await context.CustomersTable.Include(a => a.Address).ThenInclude(a => a.City)
                    .Include(a => a.User).FirstOrDefaultAsync(a=> a.CprNumber== transaction.Sender.Customer.CprNumber);
                
                Account receiver = await context.AccountTable.Where(a => a.Customer.CprNumber.Equals(customer.CprNumber)).FirstOrDefaultAsync(t =>
                    t.AccountNumber == transaction.Receiver.AccountNumber);
                receiver.Balance = transaction.Receiver.Balance;
                context.Update(receiver);
                Console.WriteLine("update receiver ------------>>>>>>>>>>>" + receiver);
                await context.SaveChangesAsync();
            }
            
        }

        private static async Task UpdateSenderAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();
            {
                Customer customer = await context.CustomersTable.Include(a => a.Address).ThenInclude(a => a.City)
                    .Include(a => a.User).FirstOrDefaultAsync(a=> a.CprNumber== transaction.Sender.Customer.CprNumber);
                
                Account sender = await context.AccountTable.Where(a => a.Customer.CprNumber.Equals(customer.CprNumber)).FirstOrDefaultAsync(t =>
                    t.AccountNumber == transaction.Sender.AccountNumber);
                
                sender.Balance = transaction.Sender.Balance;
                context.Update(sender);
                Console.WriteLine("update sender -------->>>>>>>>" + sender);
                await context.SaveChangesAsync();
            }
         
        }

        public async Task<Account> GetCustomerAccountAsync(string username)
        {
            await using CloudContext context = new CloudContext();
            {
                Customer customer = await context.CustomersTable.Include(c=>c.Address).
                    ThenInclude(c=> c.City).FirstOrDefaultAsync(c => c.User.Username.Equals(username));
                
                Account account = await context.AccountTable
                    .FirstOrDefaultAsync(c => c.Customer.Equals(customer));
                Console.WriteLine(account.ToString());
                return account;
            }
        }
        
        public async Task<Transaction> PayBillAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();
            
            throw new System.NotImplementedException();
        }
    }
}