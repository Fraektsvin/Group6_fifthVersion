using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;

namespace DatabaseTier.Repository.TransactionREPO
{
    public class TransactionRepository : ITransactionRepository
    {
        public async Task<Transaction> TransferMoneyAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();                         //cast long to object 
            IQueryable<Account> transferTo = context.AccountTable.Where(a => a.AccountNumber.Equals(transaction.Receiver));
            Account transferAccount = transferTo.FirstOrDefault();
            UpdateReceiverAccount(transaction, transferAccount);
            
            IQueryable<Account> transferFrom = context.AccountTable.Where(a => a.AccountNumber.Equals(transaction.Sender));
            Account senderAccount = transferFrom.FirstOrDefault();
            UpdateSenderAccount(transaction, senderAccount);
            
            var updateTransaction = await context.TransactionTable.AddAsync(transaction);
            return updateTransaction.Entity;
        }
        private bool UpdateSenderAccount(Transaction transaction, Account senderAccount)
        {
            if (senderAccount.AccountNumber.Equals(transaction.Sender))
            {
                UpdateSenderBalanceAsync();
            }
            else if (senderAccount.AccountNumber.Equals(transaction.Receiver))
            {
                UpdateReceiverBalanceAsync();
            }
            else return true;

            return false;
        }
        private bool UpdateReceiverAccount(Transaction transaction, Account transferAccount)
        {
            if (transferAccount.AccountNumber.Equals(transaction.Sender))
            {
                UpdateSenderBalanceAsync();
            }
            else if (transferAccount.AccountNumber.Equals(transaction.Receiver))
            {
                UpdateReceiverBalanceAsync();
            }
            else return true;

            return false;
        }
        private async Task UpdateReceiverBalanceAsync()
        {
            Account newBalance = null;
            Transaction amount = null;
            newBalance.Balance += amount.Amount;
        }

        private async Task  UpdateSenderBalanceAsync()
        {
            Account newBalance = null;
            Transaction amount = null; 
            newBalance.Balance -= amount.Amount;
        }
        
        public async Task<Transaction> PayBillAsync(Transaction transaction)
        {
            await using CloudContext context = new CloudContext();
            
            throw new System.NotImplementedException();
        }

        public async Task<double> CheckBalanceAsync(Customer customer)
        {
            await using CloudContext context = new CloudContext();
            var customerBalance = context.AccountTable.FirstOrDefault(a => a.Balance == customer.CprNumber);
            if (customerBalance != null)
                return customerBalance.Balance;
            return 0;
        }

        public async Task<Account> GetAccountNumberAsync(Account account)
        {
            await using CloudContext context = new CloudContext();
            var customerAccount = context.AccountTable.FirstOrDefault(a => a.AccountNumber == a.Customer.CprNumber);
            if (customerAccount != null)
                return customerAccount;
            return null;
        }
    }
}