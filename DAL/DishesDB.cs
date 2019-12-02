using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

using System.Data.SqlClient;

namespace DAL
{
    public class DishesDB : IDishesDB
    {
        public IConfiguration Configuration { get; }
        public DishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Dishes> GetDishes()
        {
            List<Dishes> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Dishes";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dishes>();

                            Dishes dishes = new Dishes();

                            dishes.idDishes = (int)dr["idDishes"];
                            dishes.name = (string)dr["name"];
                            dishes.type = (string)dr["type"];
                            dishes.price = (double)dr["price"];

                            results.Add(dishes);

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
        public Dishes GetDishId(int idDishes)
        {
            Dishes dishes = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Dishes where idDishes = @idDishes";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idDishes", idDishes);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dishes = new Dishes();
                            dishes.idDishes = (int)dr["idDishes"];
                            dishes.name = (string)dr["name"];
                            dishes.type = (string)dr["type"];
                            dishes.price = (double)dr["price"];
                           
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return dishes;
        }
        public Dishes AddDish(Dishes dishes)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Dishes(name, type, price) values(@name, @type, @price); SELECT SCOPE_IDENTITY()";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@name", dishes.name);
                    cmd.Parameters.AddWithValue("@type", dishes.type);
                    cmd.Parameters.AddWithValue("@price", dishes.price);

                    cn.Open();

                    dishes.idDishes = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dishes;
        }
        public int UpdateDish(Dishes dishes)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Dishes SET name = @name, type = @type, price = @price WHERE idDishes=@id";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", dishes.idDishes);
                    cmd.Parameters.AddWithValue("@type", dishes.type);
                    cmd.Parameters.AddWithValue("@name", dishes.name);
                    cmd.Parameters.AddWithValue("@price", dishes.price);
                    
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
        public int DeleteDish(int id)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "DELETE FROM Dishes WHERE idDishes=@id";


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

        public int DeleteDishFromFK(int fk_status)
        {
            throw new NotImplementedException();
        }
    }


}
