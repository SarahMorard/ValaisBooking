using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public class CitiesDB : ICitiesDB
    {
        public IConfiguration Configuration { get; }

        public CitiesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Cities> GetCities()
        {
            List<Cities> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Cities";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Cities>();

                            Cities cities = new Cities();

                            cities.idCities = (int)dr["IdCities"];
                            cities.zip_code = (int)dr["zip_code"];
                            cities.name = (string)dr["name"];


                            results.Add(cities);

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
        public Cities GetCityId(int idCities)
        {
            Cities cities = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Cities where IdCities = @idCities";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCities", idCities);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                             cities= new Cities();
                            cities.idCities = (int)dr["IdCities"];
                            cities.zip_code = (int)dr["zip_code"];
                            cities.name = (string)dr["name"];
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return cities;
        }
        public Cities AddCity(Cities city)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Cities(zip_code, name) values(@zip_code, @name); SELECT SCOPE_IDENTITY()";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@zip_code", city.zip_code);
                    cmd.Parameters.AddWithValue("@name", city.name);
                

                    cn.Open();

                    city.idCities = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return city;

        }
        public int UpdateCity(Cities cities)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Cities SET zip_code = @zip_code, name = @name WHERE IdCities=@id";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", cities.idCities);
                    cmd.Parameters.AddWithValue("@zip_code", cities.zip_code);
                    cmd.Parameters.AddWithValue("@name", cities.name);
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
        public int DeleteCity(int id)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "DELETE FROM Cities WHERE IdCities=@id";


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
