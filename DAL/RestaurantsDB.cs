using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class RestaurantsDB:IRestaurantDB
    {
        public IConfiguration Configuration { get; }
        public RestaurantsDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //List all restaurants
        public List<Restaurants> GetRestaurants()
        {
            List<Restaurants> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Restaurants";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurants>();

                            Restaurants restaurants = new Restaurants();

                            restaurants.idRestaurant = (int)dr["idRestaurant"];
                            restaurants.name = (String)dr["name"];
                            restaurants.address = (String)dr["address"];
                            restaurants.city_id = (int)dr["city_id"];
                            restaurants.dishes_id = (int)dr["dishes_id"];

                            results.Add(restaurants);

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

        //Get restaurant by id
        public Restaurants GetRestaurantsId(int idRestaurant)
        {
            Restaurants restaurants = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Restaurants where idRestaurant = @idRestaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idRestaurant", idRestaurant);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            restaurants = new Restaurants();
                            restaurants.idRestaurant = (int)dr["idRestaurant"];
                            restaurants.name = (String)dr["name"];
                            restaurants.address = (String)dr["address"];
                            restaurants.city_id = (int)dr["city_id"];
                            restaurants.dishes_id = (int)dr["dishes_id"];

                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return restaurants;
        }

        //Add a new restaurant
        public Restaurants AddRestaurants(Restaurants restaurants)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Restaurants(name, address, city_id, dishes_id) values(@name, @address ,@city_id,@dishes_id); SELECT SCOPE_IDENTITY()";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@name", restaurants.name);
                    cmd.Parameters.AddWithValue("@address", restaurants.address);
                    cmd.Parameters.AddWithValue("@city_id", restaurants.city_id);
                    cmd.Parameters.AddWithValue("@dishes_id", restaurants.dishes_id);

                    cn.Open();

                    restaurants.idRestaurant = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurants;
        }

        //Update a restaurant
        public int UpdateRestaurants(Restaurants restaurants)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Restaurants SET name = @name, address = @address, city_id=@city_id,dishes_id=@dishes_id WHERE idRestaurant=@id";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", restaurants.idRestaurant);
                    cmd.Parameters.AddWithValue("@name", restaurants.name);
                    cmd.Parameters.AddWithValue("@address", restaurants.address);
                    cmd.Parameters.AddWithValue("@city_id", restaurants.city_id);
                    cmd.Parameters.AddWithValue("@dishes_id", restaurants.dishes_id);

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

        //Delete a restaurant
        public int DeleteRestaurant(int id)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "DELETE FROM Restaurants WHERE idRestaurant=@id";


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
