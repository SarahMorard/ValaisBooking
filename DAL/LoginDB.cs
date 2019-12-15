using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class LoginDB : ILoginDB
    {
        public IConfiguration Configuration { get; }
        public LoginDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Login> GetLogins()
        {
            List<Login> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Login";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Login>();

                            Login login = new Login();

                            login.idLogin = (int)dr["idLogin"];
                            login.login = (string)dr["login"];
                            login.password = (string)dr["password"];
                            login.type = (string)dr["type"];
                            login.firstName = (string)dr["firstName"];
                            login.lastName = (string)dr["lastName"];
                            login.address = (string)dr["address"];
                            login.phone = (int)dr["phone"];
                            login.email = (string)dr["email"];
                            login.city_id = (int)dr["city_id"];

                            results.Add(login);

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
        public Login GetLoginId(int idLogin)
        {
            Login login = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Login where idLogin = @idLogin";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idLogin", idLogin);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            login = new Login();
                            login.idLogin = (int)dr["idLogin"];
                            login.login = (string)dr["login"];
                            login.password = (string)dr["password"];
                            login.firstName = (string)dr["firstName"];
                            login.lastName = (string)dr["lastName"];
                            login.address = (string)dr["address"];
                            login.phone = (int)dr["phone"];
                            login.email = (string)dr["email"];
                            login.city_id = (int)dr["city_id"];

                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return login;
        }
        public Login AddLogin(Login login)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Login(login, password, type, firstname, lastname, address, phone, email, city_id) VALUES(@login, @password, @type, @firstname, @lastname, @address, @phone, @email, @email, @city_id); SELECT SCOPE_IDENTITY()";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@login", login.login);
                    cmd.Parameters.AddWithValue("@password", login.password);
                    cmd.Parameters.AddWithValue("@type", login.type);
                    cmd.Parameters.AddWithValue("@firstname", login.firstName);
                    cmd.Parameters.AddWithValue("@lastname", login.lastName);
                    cmd.Parameters.AddWithValue("@address", login.address);
                    cmd.Parameters.AddWithValue("@phone", login.phone);
                    cmd.Parameters.AddWithValue("@email", login.email);
                    cmd.Parameters.AddWithValue("@city_id", login.city_id);


                    cn.Open();

                    login.idLogin = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return login;
        }
        public int UpdateLogin(Login login)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Login SET login = @login, password = @password, firstName = @firstName, lastName = @lastName, address = @address, phone = @phone, email = @email, city_id = @city_id WHERE idLogin=@id";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", login.idLogin);
                    cmd.Parameters.AddWithValue("@login", login.login);
                    cmd.Parameters.AddWithValue("@firstName", login.firstName);
                    cmd.Parameters.AddWithValue("@lastName", login.lastName);
                    cmd.Parameters.AddWithValue("@address", login.address);
                    cmd.Parameters.AddWithValue("@phone", login.phone);
                    cmd.Parameters.AddWithValue("@email", login.email);
                    cmd.Parameters.AddWithValue("@city_id", login.city_id);




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
        public int DeleteLogin(int id)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "DELETE FROM Login WHERE idLogin=@id";


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

        //to check the user
        public Login IsUserValid(string login, string password)
        {   
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            Login result = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Login WHERE login=@login AND password=@password";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new Login();

                            result.idLogin = (int)dr["idLogin"];
                            result.login = (String)dr["login"];
                            result.password = (String)dr["password"];
                            result.type = (String)dr["type"];
                        }
                           
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        //get the login according to the foreigh key put in parameter
        public Login GetLoginByFK(int fk)
        {
            Login login = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Login where idLogin = @fk";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@fk", fk);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            login = new Login();
                            login.idLogin = (int)dr["idLogin"];
                            login.login = (string)dr["login"];
                            login.password = (string)dr["password"];
                            login.firstName = (string)dr["firstName"];
                            login.lastName = (string)dr["lastName"];
                            login.address = (string)dr["address"];
                            login.phone = (int)dr["phone"];
                            login.email = (string)dr["email"];
                            login.city_id = (int)dr["city_id"];


                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return login;

        }
    }
}


 

