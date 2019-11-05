﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DTO;


namespace DAL
{
    public class OrdersDB:IOrderDB
    {
        public IConfiguration Configuration { get; }
        public OrdersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Orders> GetOrders()
        {
            List<Orders> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Orders";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Orders>();

                            Orders orders = new Orders();

                            orders.idOrders = (int)dr["idOrders"];
                            orders.Status_id = (int)dr["Status_id"];
                          
                            results.Add(orders);

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
        public Orders GetOrdersId(int idOrders)
        {
            Orders orders = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Orders where idOrders = @idOrders";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idOrders", idOrders);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            orders = new Orders();
                            orders.idOrders = (int)dr["idOrders"];
                            orders.Status_id = (int)dr["Status_id"];
                            
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return orders;
        }
        public Orders AddOrders(Orders orders)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Orders(idOrders, Status_id) values(@idOrders, @Status_id); SELECT SCOPE_IDENTITY()";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@Status_id", orders.Status_id);
                   
                    cn.Open();

                    orders.idOrders = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders;
        }
        public int UpdateOrders(Orders orders)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Orders SET Status_id = @Status_id WHERE idOrders=@id";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", orders.idOrders);
                    cmd.Parameters.AddWithValue("@Status_id", orders.Status_id);

                    cn.Open();

                    resultat = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return resultat;
        }
        public int DeleteOrders(int id)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "DELETE FROM Orders WHERE idOrders=@id";


                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();

                    resultat = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return resultat;
        }


    }
}
