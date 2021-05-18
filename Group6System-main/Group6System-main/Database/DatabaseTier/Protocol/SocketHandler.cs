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
                    
                    //get customer with cprnumber
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
                        return new Request("GetAllCustomers", await RepositoryFactory.GetCustomerRepository()
                            .GetAllAsync());
                    
                    //Remove customer
                    case "RemoveCustomerByCprNumber":
                        await RepositoryFactory.GetCustomerRepository().RemoveCustomerAsync((int) request.Obj);
                        return new Request("RemoveCustomerByCprNumber", "User successfully removed");
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