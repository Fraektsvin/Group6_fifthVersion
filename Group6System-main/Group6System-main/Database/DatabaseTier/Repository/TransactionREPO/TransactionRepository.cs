using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DatabaseTier.Repository.TransactionREPO
{
    public class TransactionRepository : ITransactionRepository
    {
        public async Task<Transaction> TransferMoneyAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();
            try
            { 
                await UpdateSenderAsync(transaction.Sender);
                await UpdateReceiverAsync(transaction.Receiver);
                
                Account sender = await context.AccountTable.FirstOrDefaultAsync(u =>
                    u.User.Username.Equals(transaction.Sender.User.Username));
                Account receiver = await context.AccountTable.FirstOrDefaultAsync(u =>
                    u.User.Username.Equals(transaction.Receiver.User.Username));
                
                if (sender != null || receiver != null)
                {
                    transaction.Sender = sender;
                    transaction.Receiver = receiver;
                }
                EntityEntry<Transaction> register = await context.TransactionTable.AddAsync(transaction);
                await context.SaveChangesAsync();
                
                return register.Entity;
            }
            catch (Exception e)
            {
                throw new Exception($"FAILED!!!!");
            }
            
        }

        private static async Task UpdateReceiverAsync(Account receiver)
        {
            await using CloudContext context = new CloudContext();
            
           Account r = await context.AccountTable.Include(u => u.User).FirstOrDefaultAsync(t =>
                    t.AccountNumber == receiver.AccountNumber);
            r.Balance = receiver.Balance;
            context.Update(r);
        
            await context.SaveChangesAsync();
        }

        private static async Task UpdateSenderAsync(Account sender)
        {
            await using CloudContext context = new CloudContext();
                
            Account s = await context.AccountTable.Include(u => u.User).FirstOrDefaultAsync(t =>
                    t.AccountNumber == sender.AccountNumber);
                
            s.Balance = sender.Balance;
            context.Update(s); 
            await context.SaveChangesAsync();
        }

        public async Task<Account> GetCustomerAccountAsync(string username)
        {
            await using CloudContext context = new CloudContext();

            try
            {
                User user = await context.UsersTable.FirstOrDefaultAsync(c => c.Username.Equals(username));
                
                Account account = await context.AccountTable.FirstOrDefaultAsync(c => c.User.Equals(user));
                return account;
            }
            catch (Exception e)
            {
                throw new Exception($"Not found!");
            }
           
        }
    }
}