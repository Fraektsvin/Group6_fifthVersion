using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Repository;

namespace DatabaseTier.Protocol
{
    public class SocketHandler
    {
        private readonly NetworkStream _stream;
        private readonly TcpClient _client;
        
        public SocketHandler(TcpClient client)
        {
            _client = client;
            _stream = _client.GetStream();
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
                           GetCustomer(ToObject<String>((JsonElement) request.Obj)));
                    
                    //get customer with cprNumber
                    case "GetCustomerWithCpr":
                        return new Request("GetCustomerWithCpr", await RepositoryFactory.GetCustomerRepository().
                            GetCustomer(ToObject<int>((JsonElement) request.Obj)));
                    
                    //Add customer
                    case "AddCustomer":
                        return new Request("AddCustomer", await RepositoryFactory.
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
                        Console.WriteLine("handler -->  " + removeCustomer);
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
                        Console.WriteLine(RepositoryFactory.GetAdminRepository()
                            .GetLastAccountNumberAsync());
                        return new Request("LastUsedAccountNumber", 
                            await RepositoryFactory.GetAdminRepository()
                            .GetLastAccountNumberAsync());
                    
                    //check last balance
                    case "checkBalance":
                        Customer customerBalance = ToObject<Customer>((JsonElement) request.Obj);
                        return new Request("checkBalance",
                            await RepositoryFactory.GetTransactionRepository().CheckBalanceAsync(customerBalance));
                    
                    //get the account number for transfer
                    case "getAccountNUmber" :
                        Account accountNumber = ToObject<Account>((JsonElement) request.Obj);
                        return new Request("getAccountNumber",
                            await RepositoryFactory.GetTransactionRepository().GetAccountNumberAsync(accountNumber));
                    
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