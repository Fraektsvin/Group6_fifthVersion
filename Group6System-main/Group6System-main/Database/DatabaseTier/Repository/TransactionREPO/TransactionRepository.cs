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
            try
            {
                var register = await context.AddAsync(transaction);
                Account sender = await context.AccountTable.FirstOrDefaultAsync(t =>
                    t.AccountNumber == transaction.Sender.AccountNumber);
                sender.Balance = transaction.Sender.Balance;
                context.Update(sender); 
                
                Account receiver =
                    await context.AccountTable.FirstOrDefaultAsync(t =>
                        t.AccountNumber == transaction.Receiver.AccountNumber);
                receiver.Balance = transaction.Receiver.Balance;
                context.Update(receiver); 
                
                await context.SaveChangesAsync();
                return register.Entity;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception($"Not found!");
            }
        }
        
        public async Task<Account> GetCustomerAccountAsync(string username)
        {
            await using CloudContext context = new CloudContext();
            {
                Customer customer = await context.CustomersTable.FirstOrDefaultAsync(a=> a.User.Username.Equals(username));
                
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