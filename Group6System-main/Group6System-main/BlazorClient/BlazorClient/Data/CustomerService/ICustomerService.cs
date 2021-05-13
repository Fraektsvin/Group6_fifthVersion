﻿using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data.CustomerService
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(Customer customer);
    }
}