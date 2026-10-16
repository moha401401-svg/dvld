using DVDL.Business.connectionString;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Repo
{

   

    namespace DataAccessLayer.Structs
    {
       
    }
    public static class InternationalLicenses_ViewRepo
    {

        public struct stInternationalLicense
        {
            public int InternationalLicenseID { get; set; }

            public int ApplicationID { get; set; }

            public int DriverID { get; set; }

            public int IssuedUsingLocalLicenseID { get; set; }

            public DateTime IssueDate { get; set; }

            public DateTime ExpirationDate { get; set; }

            public bool IsActive { get; set; }

            public int CreatedByUserID { get; set; }
        }

        public static DataTable GetInternationalLicensesByDriverID(
            int driverID)
        {
            DataTable dt =
                new DataTable();


            using (SqlConnection conn =
                connection.ConnectionString())
            {

                string query = @"
                SELECT
                    InternationalLicenseID,
                    IssuedUsingLocalLicenseID,
                    IssueDate,
                    ExpirationDate,
                    IsActive,
                    UserName
                FROM InternationalLicenses_View
                WHERE DriverID = @DriverID;";


                using (SqlCommand cmd =
                    new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue(
                        "@DriverID",
                        driverID);


                    try
                    {
                        conn.Open();


                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(
                            ex.Message);
                    }
                }
            }


            return dt;
        }





        public static stInternationalLicense GetInternationalLicenseByID(
            int internationalLicenseID)
        {

            stInternationalLicense license =
                new stInternationalLicense();


            using (SqlConnection conn =
                connection.ConnectionString())
            {


                string query = @"
                SELECT
                    InternationalLicenseID,
                    ApplicationID,
                    DriverID,
                    IssuedUsingLocalLicenseID,
                    IssueDate,
                    ExpirationDate,
                    IsActive,
                    CreatedByUserID

                FROM InternationalLicenses

                WHERE InternationalLicenseID = @InternationalLicenseID;";



                using (SqlCommand cmd =
                    new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue(
                        "@InternationalLicenseID",
                        internationalLicenseID);



                    try
                    {
                        conn.Open();


                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                license.InternationalLicenseID =
                                    (int)reader["InternationalLicenseID"];


                                license.ApplicationID =
                                    (int)reader["ApplicationID"];


                                license.DriverID =
                                    (int)reader["DriverID"];


                                license.IssuedUsingLocalLicenseID =
                                    (int)reader["IssuedUsingLocalLicenseID"];


                                license.IssueDate =
                                    (DateTime)reader["IssueDate"];


                                license.ExpirationDate =
                                    (DateTime)reader["ExpirationDate"];


                                license.IsActive =
                                    (bool)reader["IsActive"];


                                license.CreatedByUserID =
                                    (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(
                            ex.Message);
                    }
                }
            }


            return license;
        }
    }
}