using DVDL.Business.connectionString;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Repo
{
    public static class LDLApplicationsRepo
    {
        public static int Add(int ApplicationID, int LicenseClassID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = "Insert into LocalDrivingLicenseApplications values (@ApplicationID,@LicenseClassID); select SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, conn);
         
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
         
            try
            {
                conn.Open();
                object id = cmd.ExecuteScalar();
                return Convert.ToInt32(id);
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public static int GetLicenseClassId(int AppID)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "select LicenseClassID from LocalDrivingLicenseApplications  where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);
          
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", AppID);

            try
            {
                conn.Open();
                object clsID = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(clsID);


            }
            catch (Exception e) { throw new Exception(e.Message); }

        }
        public static int GetApplicationID(int LDLAppID)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "select ApplicationID from LocalDrivingLicenseApplications  where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);

            try
            {
                conn.Open();
                object clsID = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(clsID);


            }
            catch (Exception e) { throw new Exception(e.Message); }

        }
    }
}
