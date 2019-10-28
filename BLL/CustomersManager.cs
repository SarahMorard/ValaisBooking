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

        public List<Customers> GetCustomer()
        {
            return CustomersDB.GetHotels();
        }

        public Customers GetCustomerId(int id)
        {
            return CustomersDB.GetHotelId(id);
        }

        public Customers AddHotel(Customers customer)
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
