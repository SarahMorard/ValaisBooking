using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class Order_DishesDB : IOrder_DishesDB
    {
        public IConfiguration Configuration { get; }
        public Order_DishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Order_Dishes> GetOrder_Dishes()
        {
            List<Order_Dishes> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * FROM Order_Dishes";
                    SqlCommand cmd = new SqlCommand(query, cn);                 

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order_Dishes>();

                            Order_Dishes order_Dishes = new Order_Dishes();

                            order_Dishes.idOrder_Dishes = (int)dr["idOrder_Dishes"];
                            order_Dishes.status = (string)dr["status"];
                            order_Dishes.order_id = (int)dr["order_id"];
                            order_Dishes.login_id = (int)dr["login_id"];

                            results.Add(order_Dishes);

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
        public Order_Dishes GetOrder_DishesId(int idOrder_Dishes)
        {
            Order_Dishes order_Dishes = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Order_Dishes where idOrder_Dishes = @idOrder_Dishes";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idOrder_Dishes", idOrder_Dishes);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order_Dishes = new Order_Dishes();
                            order_Dishes.idOrder_Dishes = (int)dr["idOrder_Dishes"];
                                                  
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return order_Dishes;
        }
        public Order_Dishes AddOrder_Dishes(Order_Dishes order_Dishes)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Order_Dishes(orders_id, dishes_id) values(@orders_id, @dishes_id); SELECT SCOPE_IDENTITY()";

                    SqlCommand cmd = new SqlCommand(query, cn);

                 

                    cn.Open();

                    order_Dishes.idOrder_Dishes = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order_Dishes;
        }

        // Update the selected order dishes 
        public int UpdateOrder_Dishes(Order_Dishes order_Dishes)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Order_Dishes SET status = @status WHERE idOrder_Dishes = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", order_Dishes.idOrder_Dishes);
                    cmd.Parameters.AddWithValue("@status", order_Dishes.status);
                    cmd.Parameters.AddWithValue("@order_id", order_Dishes.order_id);



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


        public int DeleteOrder_Dishes(int id)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "DELETE FROM Order_Dishes WHERE idOrder_Dishes=@id";


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

        //get the order according to the foreign key
        public List<Order_Dishes> GetOD(int id)
        {
            List<Order_Dishes> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * FROM Order_Dishes WHERE login_id=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order_Dishes>();

                            Order_Dishes order_Dishes = new Order_Dishes();

                            order_Dishes.idOrder_Dishes = (int)dr["idOrder_Dishes"];
                            order_Dishes.status = (string)dr["status"];
                            order_Dishes.order_id = (int)dr["order_id"];
                            order_Dishes.login_id = (int)dr["login_id"];

                            results.Add(order_Dishes);

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

        public bool VerifOrderDishes(int id)
        {
            bool Verif = false;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select COUNT (*) FROM Order_Dishes WHERE DATEDIFF(minute, NOW(), time)<30 AND login_id=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    if (cmd.ExecuteNonQuery()>5)
                    {
                        Verif = false;
                    }else
                    {
                        Verif = true;
                    }
                    cn.Open();
                   
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return Verif;
        }
    }
}
