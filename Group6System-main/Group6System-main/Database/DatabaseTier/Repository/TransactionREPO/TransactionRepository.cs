using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DatabaseTier.Repository.TransactionREPO
{
    public class TransactionRepository : ITransactionRepository
    {
        public async Task<Transaction> TransferMoneyAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();
            try
            {
                EntityEntry<Transaction> register = await context.TransactionTable.AddAsync(transaction);
                Console.WriteLine("add before saving ------->>>>>>>> " + register);
                await context.SaveChangesAsync();
                Console.WriteLine("add transaction ------->>>>>>>> " + register);
                await UpdateSenderAsync(transaction);
                await UpdateReceiverAsync(transaction);
                                
                return register.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception($"FAILED!!!!");
            }
            
        }

        private static async Task UpdateReceiverAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();
            
            User user = await context.UsersTable.FirstOrDefaultAsync(a=> a.Username== transaction.Sender.User.Username);
                
            Account receiver = await context.AccountTable.Where(a => a.User.Username.Equals(user.Username)).FirstOrDefaultAsync(t =>
                    t.AccountNumber == transaction.Receiver.AccountNumber);
            receiver.Balance = transaction.Receiver.Balance;
            context.Update(receiver);
            Console.WriteLine("update receiver ------------>>>>>>>>>>>" + receiver);
            await context.SaveChangesAsync();
        }

        private static async Task UpdateSenderAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();
            User user = await context.UsersTable.FirstOrDefaultAsync(a=> a.Username== transaction.Sender.User.Username);
                
            Account sender = await context.AccountTable.Where(a => a.User.Username.Equals(user.Username)).FirstOrDefaultAsync(t =>
                    t.AccountNumber == transaction.Sender.AccountNumber);
                
            sender.Balance = transaction.Sender.Balance;
            context.Update(sender);
            Console.WriteLine("update sender -------->>>>>>>>" + sender);
            await context.SaveChangesAsync();
          
         
        }

        public async Task<Account> GetCustomerAccountAsync(string username)
        {
            await using CloudContext context = new CloudContext();

            try
            {
                User user = await context.UsersTable.FirstOrDefaultAsync(c => c.Username.Equals(username));
                
                
                Account account = await context.AccountTable
                    .FirstOrDefaultAsync(c => c.User.Equals(user));
                Console.WriteLine(account.ToString());
                return account;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception($"Not found!");
            }
           
        }
        
        public async Task<Transaction> PayBillAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();
            
            throw new System.NotImplementedException();
        }
    }
}