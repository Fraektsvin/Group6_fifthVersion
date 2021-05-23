﻿using System.Threading.Tasks;
using DatabaseTier.Models;

namespace DatabaseTier.Repository.TransactionREPO
{
    public interface ITransactionRepository
    {
        Task<Transaction> TransferMoneyAsync(Transaction transaction);
        Task<Transaction> PayBillAsync(Transaction transaction);
        Task<double> CheckBalanceAsync(Customer customer);
        Task<Account> GetAccountNumberAsync(Account account);
        Task<string> UpdateBalanceAsync(Account updateAccount);
    }
}