using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Repository;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DatabaseTier.Protocol
{
    public class SocketHandler
    {
        private readonly NetworkStream _stream;

        public SocketHandler(TcpClient client)
        {
            _stream = client.GetStream();
        }

        public async Task ExchangeMessages()
        {
             //read 
            byte[] readBuffer = new byte[8000];
            int bytesToRead = _stream.Read(readBuffer, 0, readBuffer.Length);
            string message = Encoding.UTF8.GetString(readBuffer, 0, bytesToRead);
            
            Request readRequest = JsonSerializer.Deserialize<Request>(message, 
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            
            Console.WriteLine(" --> from the 2nd tier to the handler  " + readRequest.Header + readRequest.Obj);

            Request reply;
            try
            {
                reply = await Operation(readRequest);
            }
            catch (Exception e)
            {
                reply = new Request("Invalid Request", e.Message);
            }

            string readMessage = JsonSerializer.Serialize(reply, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            
            byte[] sendToServer = Encoding.UTF8.GetBytes(readMessage);
            _stream.Write(sendToServer, 0, sendToServer.Length);
        }

        private async Task<Request> Operation(Request request)
        {
            Request wrongRequest = new Request("Wrong request", null);
            
                switch (request.Header)
                {
                    //User
                    //For login
                    case "CheckLogin":
                        return new Request("CheckLogin", await RepositoryFactory.GetUserRepository().ValidateUserAsync(ToObject<User>((JsonElement) request.Obj)));
                    
                    //Customers
                    // get customer with username
                    case "GetCustomer":
                       return new Request("GetCustomer", await RepositoryFactory.GetCustomerRepository().
                           GetCustomerAsync(ToObject<String>((JsonElement) request.Obj)));
                    
                    //get customer with cprNumber
                    case "GetCustomerWithCpr":
                        return new Request("GetCustomerWithCpr", await RepositoryFactory.GetCustomerRepository().
                            GetCustomerAsync(ToObject<int>((JsonElement) request.Obj)));
                    
                    //Add customer
                    case "AddCustomer":
                        return new Request("CustomerAdded", await RepositoryFactory.
                            GetCustomerRepository().AddCustomerAsync(ToObject<Customer>((JsonElement) request.Obj)));
                    
                    case "UpdateCustomer" :
                        return new Request("UpdateCustomer",
                            await RepositoryFactory.GetCustomerRepository().UpdateCustomerAsync(ToObject<Customer>((JsonElement) request.Obj)));
                    
                    //Administrator
                    //Get all customers
                    case "GetAllCustomers":
                        var all = new Request("GetAllCustomers", await RepositoryFactory.GetAdminRepository().
                            GetAllCustomersAsync());
                        return all;
                    
                    //Remove customer
                    case "RemoveCustomerByCprNumber":
                        var removeCustomer = await RepositoryFactory.GetAdminRepository().
                            RemoveCustomerAsync(ToObject<int>((JsonElement) request.Obj));
                        return new Request("RemoveCustomerByCprNumber", removeCustomer);
                    
                    //Validate Customer
                    case "IsValid":
                        return new Request("IsValid", await RepositoryFactory.
                            GetAdminRepository().ValidateCustomerAsync(ToObject<Customer>((JsonElement) request.Obj)));
                    
                    //Create Account
                    case "CreateAccount":
                        Account account = ToObject<Account>((JsonElement) request.Obj);
                        return new Request("AccountCreate",
                            await RepositoryFactory.GetAdminRepository().
                                CreateAccountAsync(account));
                    
                    //Get last used account number
                    case "GetLastUsedAccountNumber":
                        return new Request("LastUsedAccountNumber", 
                            await RepositoryFactory.GetAdminRepository()
                            .GetLastAccountNumberAsync());
                    

                    //get account with username
                    case"GetAccountWithUsername":
                        string username = ToObject<string>((JsonElement) request.Obj);
                        Account acc = await RepositoryFactory.GetTransactionRepository().GetCustomerAccountAsync(username);
                        Console.WriteLine(acc);
                        return new Request("AccountWithUsername",acc);

                    //transfer money
                     case "transferMoney":
                        Transaction transfer = ToObject<Transaction>((JsonElement) request.Obj);
                         return new Request("transferMoney", await RepositoryFactory.
                             GetTransactionRepository().TransferMoneyAsync(transfer)); 
                     
                     //pay bill
                    case "payBill":
                        Transaction payment = ToObject<Transaction>((JsonElement) request.Obj);
                        return new Request("payBill",
                            await RepositoryFactory.GetTransactionRepository().PayBillAsync(payment));
                    
                    //get notification from admin
                    case "getNotification":
                        string notification = ToObject<string>((JsonElement) request.Obj);
                        return new Request("getNotification",
                            await RepositoryFactory.GetNotificationRepository().GetNotificationAsync(notification)); 
                    
                    //send notification to customer
                    case "sendNotificationToUser":
                        Notification toSend = ToObject<Notification>((JsonElement) request.Obj);
                        return new Request("sendNotificationToUser",
                            await RepositoryFactory.GetNotificationRepository().SendNotificationToUserAsync(toSend));
                }

                return wrongRequest;
        }
        
        private static T ToObject<T>(JsonElement element)
        {
            var json = element.GetRawText(); 
            var result = JsonSerializer.Deserialize<T>(json);
            return result;
        }
    }
}