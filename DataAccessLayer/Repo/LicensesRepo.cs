using DVDL.Business.connectionString;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace DataAccessLayer.Repo
{
    public static class LicensesRepo
    {
        public static int Insertion(int ApplicationID,int DriverID,int LicenseClass,
            DateTime IssueDate,DateTime ExpirationDate,string Notes,double PaidFees,bool IsActive,int IssueReason,int CreatedByUserID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @"INSERT INTO Licenses 
                       
                        VALUES 
                        (  @ApplicationID, @DriverID, @LicenseClass, 
                         @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason,
                         @CreatedByUserID);
                           select SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, conn);



            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes",(object)Notes?? DBNull.Value);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
       


            try
            {
                conn.Open();
                object id = command.ExecuteScalar();
                if (id != null)
                {
                    conn.Close();
                    return Convert.ToInt32( id);
                }
                else { conn.Close(); return 0; }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static bool Deactivate(int licenseID)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = @"update Licenses set IsActive=0 where LicenseID=@licenseID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@licenseID", licenseID);
           
            try
            {
                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        public static bool Activate(int licenseID)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = @"update Licenses set IsActive=1 where LicenseID=@licenseID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@licenseID", licenseID);

            try
            {
                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        public static bool IsFirstLicense(int LicenseClass,int personID)
        {
            SqlConnection conn= connection.ConnectionString();
            string query = @" select COUNT(*) from Licenses where LicenseClass = @LicenseClass and DriverID = (select DriverID from Drivers where PersonID = @personID)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd.Parameters.AddWithValue("@personID", personID);
            try
            {
                conn.Open();
                object obj = cmd.ExecuteScalar();
                conn.Close();
                return (int)obj==0;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        public static bool IsActive(int LicenseID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @" select IsActive from Licenses where LicenseID = @LicenseID ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
         
            try
            {
                conn.Open();
                object obj = cmd.ExecuteScalar();
                conn.Close();
                return (bool)obj;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        public static int GetLicenseClass(int LicenseID)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "select LicenseClass from Licenses where LicenseID=@LicenseID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                conn.Open();
                object ClassID = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(ClassID);

            }
            catch (Exception e) { throw new Exception(e.Message); }
            

        }

        public static int GetLicenseID(int DriverID)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "select LicenseClass from Licenses where DriverID=@DriverID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                conn.Open();
                object LicenseID = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(LicenseID);

            }
            catch (Exception e) { throw new Exception(e.Message); }


        }

        public static int GetAppID(int LicenseiD)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "select ApplicationID from Licenses where LicenseiD=@LicenseiD";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@LicenseiD", LicenseiD);
            try
            {
                conn.Open();
                object LicenseID = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(LicenseID);

            }
            catch (Exception e) { throw new Exception(e.Message); }


        }

        public static int GetPersonID(int LicenseiD)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = @"select PersonID from Drivers where DriverID = (select DriverID from Licenses where LicenseID=@LicenseiD)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@LicenseiD", LicenseiD);
            try
            {
                conn.Open();
                object LicenseID = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(LicenseID);

            }
            catch (Exception e) { throw new Exception(e.Message); }


        }

    }
}
