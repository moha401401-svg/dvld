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
    public static class TestAppointmentRepo
    {
        public static bool Add(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, double PaidFees, int CreatedByUserID, bool IsLocked)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @"INSERT INTO [dbo].[TestAppointments]
           ([TestTypeID]
           ,[LocalDrivingLicenseApplicationID]
           ,[AppointmentDate]
           ,[PaidFees]
           ,[CreatedByUserID]
           ,[IsLocked])
     VALUES
           (@TestTypeID
           ,@LocalDrivingLicenseApplicationID
           ,@AppointmentDate
           ,@PaidFees
           ,@CreatedByUserID,
           @IsLocked)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);
            try
            {
                conn.Open();
                int rowsaffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsaffected > 0;

            }
            catch (Exception e) { throw new Exception(e.Message); }





        }

        public static bool IsLocked(int TestAppointmentID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @"select IsLocked from [TestAppointments] where TestAppointmentID=@TestAppointmentID ";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                conn.Open();
                object obj = cmd.ExecuteScalar();
                bool val = Convert.ToBoolean(obj);
                conn.Close();
                return val;

            }
            catch (Exception e) { throw new Exception(e.Message); }



        }
        public static bool ModifyAppointment(int TestAppointmentID, DateTime AppointmentDate)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @"update TestAppointments set  AppointmentDate=@AppointmentDate where TestAppointmentID=@TestAppointmentID ";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            try
            {
                conn.Open();
                int rowsaffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsaffected > 0;

            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public static bool Lock(int TestAppointmentID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @"update TestAppointments set  IsLocked=1 where TestAppointmentID=@TestAppointmentID ";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            
            try
            {
                conn.Open();
                int rowsaffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsaffected > 0;

            }
            catch (Exception e) { throw new Exception(e.Message); }

        }
        public static bool delete(int TestAppointmentID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @"delete from TestAppointments where TestAppointmentID=@TestAppointmentID ";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                conn.Open();
                int rowsaffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsaffected > 0;

            }
            catch (Exception e) { throw new Exception(e.Message); }

        }
        public static bool CanGetAppointment(int LocalDrivingLicenseApplicationID)
        {
            
            SqlConnection conn = connection.ConnectionString();
            string query = @"select COUNT(*) from TestAppointments where IsLocked=0 and LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                conn.Open();
                object obj= cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(obj) == 0;

            }
            catch (Exception e) { throw new Exception(e.Message); }


        }

        public static bool IsRetake(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = @"select COUNT(*) from TestAppointments where IsLocked=1 and LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TestTypeID=@TestTypeID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                conn.Open();
                object obj = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(obj) > 0;

            }
            catch (Exception e) { throw new Exception(e.Message); }


        }

    }
}
