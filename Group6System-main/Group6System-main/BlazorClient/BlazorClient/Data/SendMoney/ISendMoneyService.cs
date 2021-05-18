using System;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.SendMoney
{
    public interface ISendMoneyService
    {
        Task<String> PayBillAsync(Transaction transaction);
    }
}