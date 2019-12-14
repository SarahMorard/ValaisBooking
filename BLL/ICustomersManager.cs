﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface ICustomersManager
    {
        ICustomersManager CitiesDB { get; }
        List<Customers> GetCustomers();
        Customers GetCustomerId(int id);
        Customers AddCustomer(Customers customer);
        int UpdateCustomer(int id, Customers customer);
        int DeleteCustomer(int IdCustomer);
    }
}
