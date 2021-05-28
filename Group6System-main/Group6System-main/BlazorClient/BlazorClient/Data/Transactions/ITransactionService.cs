using System;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.Transactions
{
    public interface ITransactionService
    {
        Task<String> SendMoney(Transaction transaction);
    }
}