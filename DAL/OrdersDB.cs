using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DTO;


namespace DAL
{
    public class OrdersDB : IOrderDB
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

        // Add order for the customers
        public Orders AddOrders(Orders orders)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Orders(time, quantity, total, dishes_id, login_id) values(@time, @quantity, @total, @dishes_id, @login_id); SELECT SCOPE_IDENTITY()";

                    SqlCommand cmd = new SqlCommand(query, cn);  
                    cmd.Parameters.AddWithValue("@time", orders.time);
                    cmd.Parameters.AddWithValue("@quantity", orders.quantity);
                    cmd.Parameters.AddWithValue("@total", orders.total);
                    cmd.Parameters.AddWithValue("@dishes_id", orders.dishes_id);
                    cmd.Parameters.AddWithValue("@login_id", orders.login_id);

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

    
        // Get the order according to the foreigh key put in parameter
        public Orders GetOrderByFK(int fk)
        {
            Orders orders = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Orders where idOrders = @fk";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@fk", fk);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            orders = new Orders();
                            orders.idOrders = (int)dr["idOrders"];
                            orders.time = (string)dr["time"];
                            orders.quantity = (int)dr["quantity"];
                            orders.total = (double)dr["total"];
                            orders.dishes_id = (int)dr["dishes_id"];
                            orders.login_id = (int)dr["login_id"];


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

        // Return list of orders according to the id of the restaurant that was chosen
        public List<Orders> GetListOrder(int id)
        {
            List<Orders> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Orders WHERE login_id=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Orders>();

                            Orders orders = new Orders();

                            orders.idOrders = (int)dr["idOrders"];
                            orders.time = (string)dr["time"];
                            orders.quantity = (int)dr["quantity"];
                            orders.total = (double)dr["total"];
                            orders.dishes_id = (int)dr["dishes_id"];
                            orders.login_id = (int)dr["login_id"];

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
    }
}
