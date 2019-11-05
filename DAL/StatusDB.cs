using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class StatusDB:IStatusDB
    {
        public IConfiguration Configuration { get; }
        public StatusDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Status> GetStatus()
        {
            List<Status> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Status";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Status>();

                            Status status = new Status();

                            status.idStatus = (int)dr["idStatus"];
                            status.status_name = (String)dr["status_name"];
                            status.status = (bool)dr["status"];
                         
                            results.Add(status);

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
        public Status GetStatusId(int idStatus)
        {
            Status status = null;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Status where idStatus = @idStatus";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idStatus", idStatus);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            status = new Status();
                            status.idStatus = (int)dr["idStatus"];
                            status.status_name = (String)dr["status_name"];
                            status.status = (bool)dr["status"];

                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return status;
        }
        public Status AddStatus(Status status)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Status( idStatus, status_name, status) values(@idStatus, @status_name,@status); SELECT SCOPE_IDENTITY()";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@status_name", status.status_name);
                    cmd.Parameters.AddWithValue("@status", status.status);

                    cn.Open();

                    status.idStatus = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return status;
        }
        public int UpdateStatus(Status status)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Status SET status_name = @status_name, status=@status WHERE idStatus=@id";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", status.idStatus);
                    cmd.Parameters.AddWithValue("@status_name", status.status_name);
                    cmd.Parameters.AddWithValue("@status", status.status);

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
        public int DeleteStatus(int id)
        {
            int resultat = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "DELETE FROM Status WHERE idStatus=@id";


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
