using System.Threading.Tasks;

namespace BlazorClient.Data.SendMoney
{
    public interface ISendMoneyService
    {
        Task PayBillAsync();
    }
}