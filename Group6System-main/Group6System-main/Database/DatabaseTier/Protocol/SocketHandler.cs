﻿using System;
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
        private readonly ICustomerRepository _customerRepo;
        private readonly IUserRepo _userRepo;
        private readonly TcpClient _client;
        
        public SocketHandler(TcpClient client)
        {
            _client = client;
            _userRepo = new UserRepository();
            _customerRepo = new CustomerRepository();
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
                    case "CheckLogin":
                        Console.WriteLine("step 1 --> from the socket"+request.Obj);
                        return new Request("CheckLogin", await _userRepo.ValidateUserAsync(ToObject<User>((JsonElement) request.Obj)));
                    case "GetAllCustomers":
                       return new Request("GetAllCustomers", await _customerRepo.GetAllAsync());
                    case "AddCustomer":
                        return new Request("AddCustomer", await _customerRepo.AddCustomerAsync(ToObject<Customer>((JsonElement) request.Obj)));
                    case "UpdateCustomer" :
                        return new Request("UpdateCustomer",
                            await _customerRepo.UpdateCustomerAsync(ToObject<Customer>((JsonElement) request.Obj)));
                    case "RemoveCustomerByCprNumber":
                        await _customerRepo.RemoveCustomerAsync((int) request.Obj);
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