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
    public static class TestAppointments_ViewRepo
    {
        public static DataTable GetAppointments(int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = connection.ConnectionString();
            string query = @"select * from TestAppointments_View where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID"; 
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                conn.Close();
                return dt;

            }
            catch {  return dt; }


        }


       
    }
} 
