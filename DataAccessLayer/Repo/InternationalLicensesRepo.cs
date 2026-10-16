using DVDL.Business.connectionString;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public static class InternationalLicensesRepo
    {


        public static int AddInternationalLicense(
        int applicationID,
        int driverID,
        int issuedUsingLocalLicenseID,
        DateTime issueDate,
        DateTime expirationDate,
        bool isActive,
        int createdByUserID)
        {
            int internationalLicenseID = -1;

            using (SqlConnection conn = connection.ConnectionString())
            {
                string query = @"
                                INSERT INTO InternationalLicenses
                                (
                                    ApplicationID,
                                    DriverID,
                                    IssuedUsingLocalLicenseID,
                                    IssueDate,
                                    ExpirationDate,
                                    IsActive,
                                    CreatedByUserID
                                )
                                VALUES
                                (
                                    @ApplicationID,
                                    @DriverID,
                                    @IssuedUsingLocalLicenseID,
                                    @IssueDate,
                                    @ExpirationDate,
                                    @IsActive,
                                    @CreatedByUserID
                                );

                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    command.Parameters.AddWithValue("@DriverID", driverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", issueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        conn.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            internationalLicenseID = id;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return internationalLicenseID;
        }

        public static bool Deactivate(int InternationallicenseID)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = @"update Internationallicenses set IsActive=0 where InternationallicenseID=@InternationallicenseID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@InternationallicenseID", InternationallicenseID);

            try
            {
                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        public static int GetPersonID(int InternationalLicenseID)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = @"select PersonID from Drivers where DriverID = (select DriverID from InternationalLicenses where InternationalLicenseID=@InternationalLicenseID)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                conn.Open();
                object PersonID = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(PersonID);

            }
            catch (Exception e) { throw new Exception(e.Message); }


        }

        public static int GetDriverID(int InternationalLicenseID)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = @"select DriverID from InternationalLicenses where InternationalLicenseID=@InternationalLicenseID  )";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                conn.Open();
                object DriverID = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(DriverID);

            }
            catch (Exception e) { throw new Exception(e.Message); }


        }


        public static bool HasAnActiveLicense(int DriverID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @" select COUNT(*) from InternationalLicenses where IsActive = 1 and DriverID=@DriverID ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                conn.Open();
                object obj = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32( obj)>0;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }


    }


}
