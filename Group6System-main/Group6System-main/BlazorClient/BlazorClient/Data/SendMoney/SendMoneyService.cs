using System.Threading.Tasks;

namespace BlazorClient.Data.SendMoney
{
    public class SendMoneyService : ISendMoneyService
    {
        private string path = "http://localhost:8080";
        
        public Task PayBillAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}