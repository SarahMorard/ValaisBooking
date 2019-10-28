using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class CustomersDB
    {
        public IConfiguration Configuration { get; }
        public CustomersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public List<Customers> GetCustomers()
        {
            List<Customers> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Customers";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Customers>();

                            Customers customers = new Customers();

                            customers.idCustomers = (int)dr["idCustomers"];
                            customers.firstName = (string)dr["firstName"];
                            customers.lastName = (string)dr["lastName"];
                            customers.address = (string)dr["address"];
                            customers.phone_number = (int)dr["phone_number"];
                            customers.email = (string)dr["email"];


                            results.Add(customers);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;

        }
        public Customers GetCustomerId(int idCustomers)
        {
            Customers customers= null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Customers where idCustomers = @idCustomers";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCustomers", idCustomers);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            customers = new Customers();
                            customers.idCustomers = (int)dr["idCustomers"];
                            customers.firstName = (string)dr["firstName"];
                            customers.lastName = (string)dr["lastName"];
                            customers.address = (string)dr["address"];
                            customers.phone_number = (int)dr["phone_number"];
                            customers.email = (string)dr["email"];
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return customers;
        }
    }
}
