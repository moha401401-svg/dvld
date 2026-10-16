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
   static public class ApplicationsRepo
    {
        public static int Add(int personid,DateTime ApplicationDate,int ApplicationTypeID, double PaidFees,int CreatedByUserID,int ApplicationStatus)
        {
          SqlConnection conn=  connection.ConnectionString();
            string query = "Insert into Applications values (@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID); select SCOPE_IDENTITY();";
            SqlCommand cmd= new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", personid);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@LastStatusDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            try
            {
                conn.Open();
                object id = cmd.ExecuteScalar();
                return Convert.ToInt32(id);
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }
        public static bool Update(int id, int status, DateTime LastStatusDate)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "update Applications set LastStatusDate=@LastStatusDate , ApplicationStatus=@ApplicationStatus  where ApplicationID=@ApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@ApplicationStatus", status);
            cmd.Parameters.AddWithValue("@ApplicationID", id);

            try
            {
                conn.Open();
                int rowsaffected = cmd.ExecuteNonQuery();

                conn.Close();
                return rowsaffected > 0;
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public static int GetPersonId(int id)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = @"select ApplicantPersonID from Applications
                        where ApplicationID= (select ApplicationID from LocalDrivingLicenseApplications
                        where LocalDrivingLicenseApplicationID=@ApplicationID)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ApplicationID", id);

            try
            {
                conn.Open();
                object ID = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(ID);


            }
            catch (Exception e) { throw new Exception(e.Message); }

        }


        public static bool Cancel(int id)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "update Applications set ApplicationStatus=2  where ApplicationID=@ApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);
      
            cmd.Parameters.AddWithValue("@ApplicationID", id);

            try
            {
                conn.Open();
                int rowsaffected = cmd.ExecuteNonQuery();

                conn.Close();
                return rowsaffected > 0;
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

    }
}
