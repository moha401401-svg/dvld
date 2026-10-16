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
    public class CountryRepo
    {


        public static DataTable GetAll()
        {
            SqlConnection conn = connection.ConnectionString();
            string query = "SELECT * from Countries";
            DataTable contries = new DataTable();
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                contries.Load(reader);
                conn.Close();
                return contries;
            }
            catch (Exception ex) { return contries; }
        }
        public static string GetCountryName(int id)
        {
          SqlConnection conn=  connection.ConnectionString();
            string query = "select CountryName from Countries where CountryID= @id";
            SqlCommand command = new SqlCommand (query, conn);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                conn.Open();
                object name = command.ExecuteScalar();
                conn.Close();
                return (string)name;
            }
            catch(Exception ex)
            {
                return "Cannot open Database";
            }
            

        }


    }
}
