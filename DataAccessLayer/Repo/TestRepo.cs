using DVDL.Business.connectionString;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public static class TestRepo
    {
        public static bool Add(int TestAppointmentID,int TestResult,string Notes, int CreatedByUserID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @"INSERT INTO Tests       
            VALUES(
           @TestAppointmentID
           ,@TestResult
           ,@Notes
           ,@CreatedByUserID)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);
            cmd.Parameters.AddWithValue( "@Notes", (object)Notes ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try {
                conn.Open();
                int rowsaffected = cmd.ExecuteNonQuery();

                conn.Close();
                return rowsaffected > 0;
            }
         catch (Exception e) { throw new Exception(e.Message); }

        }
    }
}
