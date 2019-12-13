using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class CustomersManager : ICustomersManager
    {
        public ICustomersDB CustomersDB{ get; }

        public ICustomersManager CitiesDB => throw new NotImplementedException();

        public CustomersManager(IConfiguration configuration)
        {
            CustomersDB = new CustomersDB(configuration);
        }

        public List<Customers> GetCustomers()
        {
            return CustomersDB.GetCustomers();
        }

        public Customers GetCustomerId(int id)
        {
            return CustomersDB.GetCustomerId(id);
        }

        public Customers AddCustomer(Customers customer)
        {
            return CustomersDB.AddCustomer(customer);
        }

        public int UpdateCustomer(int id, Customers customer)
        {
            return CustomersDB.UpdateCustomer(id, customer);
        }

        public int DeleteCustomer(int IdCustomer)
        {
            return CustomersDB.DeleteCustomer(IdCustomer);
        }

        public int GetLastIndex()
        {
            return CustomersDB.GetLastIndex();
        }

    }
}
