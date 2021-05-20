using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseTier.Models;
using DatabaseTier.Persistence;
using DatabaseTier.Protocol;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTier
{
    class Program
    {
        static async Task Main(string[] args)
        {
            StartSocket socket = new StartSocket();
            socket.Start();
           
                using  (CloudContext context = new CloudContext())
                {
                    // IEnumerable<Customer>
                    var customers = await context.CustomersTable.
                        Include(a=> a.Address).ThenInclude(a=> a.City).ToListAsync();

                    foreach (Customer customer in customers)
                    {
                        Console.WriteLine($"{customer.CprNumber} lives in {customer.Address.City.CityName} - {customer.Address.StreetName}");
                    }
             
                }   
            
        }
    }
}