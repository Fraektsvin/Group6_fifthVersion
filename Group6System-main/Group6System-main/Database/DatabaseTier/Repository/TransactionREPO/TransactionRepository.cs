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
        
        public async Task<double> CheckBalanceAsync(Account account)
        {
            await using CloudContext context = new CloudContext();
            try
            {
                Account customerBalance = await context.AccountTable.FirstOrDefaultAsync(a => a.AccountNumber == account.AccountNumber);
                if (customerBalance != null) return customerBalance.Balance;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error message!!!");
            }

            return 0;
        }

        public async Task<Account> GetAccountNumberAsync(Account account)
        {
            await using CloudContext context = new CloudContext();
            try
            {
                var customerAccount = context.AccountTable.FirstOrDefault(a => a.AccountNumber == a.Customer.CprNumber);
                if (customerAccount != null) 
                    return customerAccount;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("No account found!");
            }

            return null;
        }
        
        public async Task<Transaction> PayBillAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();
            
            throw new System.NotImplementedException();
        }
    }
}