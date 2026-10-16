using DVDL.Business.connectionString;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public static class ApplicationTypesRepo
    {
        public static DataTable GetAll()
        {
            SqlConnection conn = connection.ConnectionString();
            string query = "select * from ApplicationTypes";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
             
                dt.Load(reader);
                conn.Close();
                return dt;
            }
            catch (Exception e) { throw new Exception(e.Message); }


        }
        public static bool UpdateFees(int id, int fees) {

            SqlConnection conn = connection.ConnectionString();
            string query = "update ApplicationTypes set ApplicationFees=@ApplicationFees  where ApplicationTypeID=@ApplicationTypeID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationFees", fees);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", id);
            
            try
            {
                conn.Open();
                int rowsaffected = cmd.ExecuteNonQuery();

                conn.Close();
                return rowsaffected > 0;
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }


        public static double GetFees(int id)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "select ApplicationFees from ApplicationTypes where ApplicationTypeID=@ApplicationTypeID";
            SqlCommand cmd = new SqlCommand(query, conn);
           
            cmd.Parameters.AddWithValue("@ApplicationTypeID", id);
            try
            {
                conn.Open();
                object fees = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(fees);

            }
            catch (Exception e) { throw new Exception(e.Message); }

        }


       
    }
}
