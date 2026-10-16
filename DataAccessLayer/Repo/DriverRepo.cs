using DVDL.Business.connectionString;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public static class DriverRepo
    {
        public static int Add(int PersonID,int CreatedByUserID,DateTime CreatedDate)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @"insert into Drivers values(@PersonID,@CreatedByUserID,@CreatedDate);select SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            try
            {
                conn.Open();
                object obj = cmd.ExecuteScalar();
                conn.Close();
               
                return Convert.ToInt32(obj);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static bool IsDriver( int personID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @" select COUNT(*) from Drivers where PersonID=@personID";
            SqlCommand cmd = new SqlCommand(query, conn);
           
            cmd.Parameters.AddWithValue("@personID", personID);
            try
            {
                conn.Open();
                object obj = cmd.ExecuteScalar();
                conn.Close();
                return (int)obj > 0;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        public static int GetDriver(int personID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @" select DriverID from Drivers where PersonID=@personID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@personID", personID);
            try
            {
                conn.Open();
                object obj = cmd.ExecuteScalar();
                conn.Close();

                return Convert.ToInt32(obj);


            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

    }
}
