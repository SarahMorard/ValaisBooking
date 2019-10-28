using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface ICustomersManager
    {
        ICustomersManager CitiesDB { get; }
        List<Customers> GetCustomer();
        Customers GetCustomerId(int id);
        Customers AddCustomer(Customers customer);
        int UpdateCustomer(Customers customer);
        int DeleteCustomer(int IdCustomer);
    }
}
