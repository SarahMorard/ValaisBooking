using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class StaffDB: IStaffDB
    {
        public IConfiguration Configuration { get; }
        public StaffDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Staff> GetStaff()
        {
            List<Staff> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Staff";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Staff>();

                            Staff staff = new Staff();

                            staff.idStaff = (int)dr["idStaff"];
                            staff.firstName = (String)dr["firstName"];
                            staff.lastName = (String)dr["lastName"];
                            staff.no_staff = (int)dr["no_staff"];
                            staff.address = (String)dr["address"];
                            staff.phone_number = (int)dr["phone_number"];
                            staff.email = (String)dr["email"];
                            staff.cities_id = (int)dr["cities_id"];             
                            staff.login_id = (int)dr["login_id"];

                            results.Add(staff);

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
        public Staff GetStaffId(int idStaff)
        {
           Staff staff = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Staff where idStaff = @idStaff";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idStaff", idStaff);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            staff = new Staff();
                            staff.idStaff = (int)dr["idStaff"];
                            staff.firstName = (String)dr["firstName"];
                            staff.lastName = (String)dr["lastName"];
                            staff.no_staff = (int)dr["no_staff"];
                            staff.address = (String)dr["address"];
                            staff.phone_number = (int)dr["phone_number"];
                            staff.email = (String)dr["email"];
                            staff.cities_id = (int)dr["cities_id"];
                            staff.login_id = (int)dr["login_id"];

                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return staff;
        }
        public Staff AddStaff(Staff staff)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Staff(firstName, lastName, no_staff,address,phone_number,email,cities_id,Login_id) values(@firstName,@lastName,@no_staff,@address,@phone_number,@email,@cities_id,@login_id); SELECT SCOPE_IDENTITY()";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@firstName", staff.firstName);
                    cmd.Parameters.AddWithValue("@lastName", staff.lastName);
                    cmd.Parameters.AddWithValue("@no_staff", staff.no_staff);
                    cmd.Parameters.AddWithValue("@address", staff.address);
                    cmd.Parameters.AddWithValue("@phone_number", staff.phone_number);
                    cmd.Parameters.AddWithValue("@email", staff.email);
                    cmd.Parameters.AddWithValue("@cities_id", staff.cities_id);
                    cmd.Parameters.AddWithValue("@login_id", staff.login_id);

                    cn.Open();

                    staff.idStaff = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return staff;
        }
        public int UpdateStaff(Staff staff)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Staff SET firstName = @firstName, lastName=@lastName,no_staff=@no_staff,address=@address,phone_number=@phone_number,email=@email,cities_id=@cities_id,Login_id=@Login_id WHERE idStaff=@id";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", staff.idStaff);
                    cmd.Parameters.AddWithValue("@firstName", staff.firstName);
                    cmd.Parameters.AddWithValue("@lastName", staff.lastName);
                    cmd.Parameters.AddWithValue("@no_staff", staff.no_staff);
                    cmd.Parameters.AddWithValue("@address", staff.address);
                    cmd.Parameters.AddWithValue("@phone_number", staff.phone_number);
                    cmd.Parameters.AddWithValue("@email", staff.email);
                    cmd.Parameters.AddWithValue("@cities_id", staff.cities_id);
                    cmd.Parameters.AddWithValue("@login_id", staff.login_id);

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

        public int DeleteStaff(int id)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "DELETE FROM Staff WHERE idStaff=@id";


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
