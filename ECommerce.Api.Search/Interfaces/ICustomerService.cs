﻿using ECommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Interfaces
{
    public interface ICustomerService
    {
        Task<(bool IsSucces, CustomerModel Result, string ErrorMessage)> 
            GetCustomersAsync(int customerId);
    }
}
