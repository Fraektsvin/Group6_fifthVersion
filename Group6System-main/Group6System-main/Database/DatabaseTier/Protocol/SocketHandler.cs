using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Repository;
using DatabaseTier.Repository.CustomerREPO;
using DatabaseTier.Repository.UserREPO;

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
            Console.WriteLine("step 1 --> from the 2nd tier to the handler  " + readRequest.Header + readRequest.Obj);

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
                       return new Request("GetCustomer", await RepositoryFactory.GetCustomerRepository().GetCustomer(ToObject<String>((JsonElement) request.Obj)));
                    
                    //get customer with cprNumber
                    case "GetCustomerWithCpr":
                        return new Request("GetCustomerWithCpr", await RepositoryFactory.GetCustomerRepository().GetCustomer(ToObject<int>((JsonElement) request.Obj)));
                    
                    //Add customer
                    case "AddCustomer":
                        return new Request("AddCustomer", await RepositoryFactory.GetCustomerRepository().AddCustomerAsync(ToObject<Customer>((JsonElement) request.Obj)));
                    
                    case "UpdateCustomer" :
                        return new Request("UpdateCustomer",
                            await RepositoryFactory.GetCustomerRepository().UpdateCustomerAsync(ToObject<Customer>((JsonElement) request.Obj)));
                    
                    //Administrator
                    //Get all customers
                    case "GetAllCustomers":
                        var all = new Request("GetAllCustomers", await RepositoryFactory.GetAdminRepository().
                            GetAllCustomersAsync());
                        Console.WriteLine("Handler " + all);
                        return all;
                    
                    //Remove customer
                    case "RemoveCustomerByCprNumber":
                        await RepositoryFactory.GetAdminRepository().RemoveCustomerAsync((int) request.Obj);
                        return new Request("RemoveCustomerByCprNumber", "User successfully removed");
                    
                    //Validate Customer
                    case "IsValid":
                        await RepositoryFactory.GetAdminRepository().ValidateCustomerAsync(ToObject<Customer>((JsonElement) request.Obj));
                        return new Request("IsValid", "Customer successfully validated!");
                    
                    //Create Account
                    case "CreateAccount":
                        return new Request("AccountCreate",
                            await RepositoryFactory.GetAdminRepository().CreateAccountAsync(ToObject<Account>((JsonElement) request.Obj)));
                    
                    //Get last used account number
                    case "GetLastUsedAccountNumber":
                        return new Request("LastUsedAccountNumber", await RepositoryFactory.GetAdminRepository()
                            .GetLastAccountNumberAsync());
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