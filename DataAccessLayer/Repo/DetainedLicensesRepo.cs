using DVDL.Business.connectionString;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Repo
{
    public static class DetainedLicensesRepo
    {


        public static int AddDetainedLicense(
            int licenseID,
            DateTime detainDate,
            decimal fineFees,
            int createdByUserID)
        {

            int detainID = -1;


            using (SqlConnection conn =
                connection.ConnectionString())
            {

                string query = @"
                INSERT INTO DetainedLicenses
                (
                    LicenseID,
                    DetainDate,
                    FineFees,
                    CreatedByUserID,
                    IsReleased
                )

                VALUES
                (
                    @LicenseID,
                    @DetainDate,
                    @FineFees,
                    @CreatedByUserID,
                    0
                );

                SELECT SCOPE_IDENTITY();";


                using (SqlCommand cmd =
                    new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue(
                        "@LicenseID",
                        licenseID);


                    cmd.Parameters.AddWithValue(
                        "@DetainDate",
                        detainDate);


                    cmd.Parameters.AddWithValue(
                        "@FineFees",
                        fineFees);


                    cmd.Parameters.AddWithValue(
                        "@CreatedByUserID",
                        createdByUserID);


                    try
                    {
                        conn.Open();


                        object result =
                            cmd.ExecuteScalar();


                        if (result != null &&
                           int.TryParse(
                               result.ToString(),
                               out int id))
                        {
                            detainID = id;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(
                            ex.Message);
                    }
                }
            }


            return detainID;
        }




        public static bool IsLicenseDetained(int licenseID)
        {

            bool isDetained = false;


            using (SqlConnection conn =
                connection.ConnectionString())
            {

                string query = @"
                SELECT COUNT(*)

                FROM DetainedLicenses

                WHERE LicenseID = @LicenseID
                AND IsReleased = 0;";



                using (SqlCommand cmd =
                    new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue(
                        "@LicenseID",
                        licenseID);


                    try
                    {
                        conn.Open();


                        int count =
                            (int)cmd.ExecuteScalar();


                        isDetained =
                            count > 0;

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(
                            ex.Message);
                    }
                }
            }


            return isDetained;
        }





        public static DataTable GetDetainedLicenses()
        {

            DataTable dt =
                new DataTable();



            using (SqlConnection conn =
                connection.ConnectionString())
            {

                string query = @"
                SELECT
                    DetainID,
                    LicenseID,
                    DetainDate,
                    FineFees,
                    CreatedByUserID,
                    IsReleased,
                    ReleaseDate,
                    ReleasedByUserID,
                    ReleaseApplicationID

                FROM DetainedLicenses;";



                using (SqlCommand cmd =
                    new SqlCommand(query, conn))
                {

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


        public static decimal GetFineFees(int detainID)
        {
            decimal fineFees = 0;


            using (SqlConnection conn =
                connection.ConnectionString())
            {
                string query = @"
        SELECT FineFees
        FROM DetainedLicenses
        WHERE DetainID = @DetainID;";


                using (SqlCommand cmd =
                    new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@DetainID",
                        detainID);


                    try
                    {
                        conn.Open();

                        object result =
                            cmd.ExecuteScalar();


                        if (result != null)
                            fineFees =
                                Convert.ToDecimal(result);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(
                            ex.Message);
                    }
                }
            }


            return fineFees;
        }




        public static int GetLicenseID(int detainID)
        {
            int licenseID = -1;


            using (SqlConnection conn =
                connection.ConnectionString())
            {
                string query = @"
        SELECT LicenseID
        FROM DetainedLicenses
        WHERE DetainID = @DetainID;";


                using (SqlCommand cmd =
                    new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@DetainID",
                        detainID);


                    try
                    {
                        conn.Open();


                        object result =
                            cmd.ExecuteScalar();


                        if (result != null)
                            licenseID =
                                Convert.ToInt32(result);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(
                            ex.Message);
                    }
                }
            }


            return licenseID;
        }




        public static bool ReleaseLicense(
            int detainID,
            int releaseApplicationID,
            int releasedByUserID)
        {

            bool result = false;


            using (SqlConnection conn =
                connection.ConnectionString())
            {

                string query = @"
        UPDATE DetainedLicenses

        SET
            IsReleased = 1,
            ReleaseDate = @ReleaseDate,
            ReleasedByUserID = @ReleasedByUserID,
            ReleaseApplicationID = @ReleaseApplicationID

        WHERE DetainID = @DetainID;";



                using (SqlCommand cmd =
                    new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue(
                        "@DetainID",
                        detainID);


                    cmd.Parameters.AddWithValue(
                        "@ReleaseDate",
                        DateTime.Now);


                    cmd.Parameters.AddWithValue(
                        "@ReleasedByUserID",
                        releasedByUserID);


                    cmd.Parameters.AddWithValue(
                        "@ReleaseApplicationID",
                        releaseApplicationID);



                    try
                    {
                        conn.Open();


                        result =
                            cmd.ExecuteNonQuery() > 0;

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(
                            ex.Message);
                    }
                }
            }


            return result;
        }

    }
}