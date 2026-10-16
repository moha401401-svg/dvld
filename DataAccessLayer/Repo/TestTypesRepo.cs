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
    public static class TestTypesRepo
    {

        public static DataTable GetAll()
        {
            SqlConnection conn = connection.ConnectionString();
            string query = "select * from TestTypes";
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
            catch (Exception ex) { throw new Exception(ex.Message); }


        }
        public static bool UpdateFees(int id, int fees)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "update TestTypes set TestTypeFees=@TestTypeFees  where TestTypeID=@TestTypeID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestTypeFees", fees);
            cmd.Parameters.AddWithValue("@TestTypeID", id);

            try
            {
                conn.Open();
                int rowsaffected = cmd.ExecuteNonQuery();

                conn.Close();
                return rowsaffected > 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        public static double GetFees(int id)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "select TestTypeFees from TestTypes where TestTypeID=@TestTypeID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@TestTypeID", id);
            try
            {
                conn.Open();
                object fees = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToDouble(fees);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            ;

        }

        public static string GetDes(int id)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "select TestTypeDescription from TestTypes where TestTypeID=@TestTypeID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@TestTypeID", id);
            try
            {
                conn.Open();
                object des = cmd.ExecuteScalar();
                conn.Close();
                return (des).ToString();

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
           ;

        }

        public static string GetName(int id)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "select TestTypeTitle from TestTypes where TestTypeID=@TestTypeID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@TestTypeID", id);
            try
            {
                conn.Open();
                object des = cmd.ExecuteScalar();
                conn.Close();
                return (des).ToString();

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
          ;

        }
    }
}
