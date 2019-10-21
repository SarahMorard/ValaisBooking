using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public class CitiesDB
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

                            cities.idCities = (int)dr["idCities"];
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

        /*public Cities AddCity(Cities city)
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

        }*/

    }
}
