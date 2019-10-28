using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class CustomersManager
    {
        public ICustomersDB CustomersDB{ get; }

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

        public int UpdateCustomer(Customers customer)
        {
            return CustomersDB.UpdateCustomer(customer);
        }

        public int DeleteCustomer(int IdHotel)
        {
            return CustomersDB.DeleteCustomer(IdCustomer);
        }

    }
}
