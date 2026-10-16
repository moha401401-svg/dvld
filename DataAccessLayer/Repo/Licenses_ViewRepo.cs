using DVDL.Business.connectionString;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Repo
{
    public static class Licenses_ViewRepo
    {
        public struct stLicenseView
        {
            public int LicenseID;
            public string ClassName;
            public string CreatedByUsername;
            public bool IsActive;
            public DateTime IssueDate;
            public DateTime ExpirationDate;
            public string Notes;
            public string IssueReason;
            public int DriverID;
        }


        public static DataTable GetAlldata(int id)
        {
            DataTable data = new DataTable();

            using (SqlConnection conn =
                connection.ConnectionString())
            {
                string query = @"
                    SELECT
                        [LicenseID],
                        [ClassName],
                        [CreatedByUsername],
                        [IsActive],
                        [IssueDate],
                        [ExpirationDate],
                        [Notes],
                        [IssueReason]
                    FROM [DVLD].[dbo].[Licenses_View]
                    WHERE DriverID = @ID";

                using (SqlCommand command =
                    new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue(
                        "@ID",
                        id);

                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader =
                            command.ExecuteReader())
                        {
                            data.Load(reader);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception(
                            e.Message);
                    }
                }
            }

            return data;
        }

        public static DataTable GetAlldata()
        {
            DataTable data = new DataTable();

            using (SqlConnection conn =
                connection.ConnectionString())
            {
                string query = @"
                    SELECT * from Licenses_View;";

                using (SqlCommand command =
                    new SqlCommand(query, conn))
                {
                  

                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader =
                            command.ExecuteReader())
                        {
                            data.Load(reader);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception(
                            e.Message);
                    }
                }
            }

            return data;
        }


        public static stLicenseView GetLicense(
            int licenseID)
        {
            stLicenseView license =
                new stLicenseView();

            using (SqlConnection conn =
                connection.ConnectionString())
            {
                string query = @"
                    SELECT
                        [LicenseID],
                        [ClassName],
                        [CreatedByUsername],
                        [IsActive],
                        [IssueDate],
                        [ExpirationDate],
                        [Notes],
                        [IssueReason],
                        [DriverID]
                    FROM [DVLD].[dbo].[Licenses_View]
                    WHERE LicenseID = @LicenseID";

                using (SqlCommand command =
                    new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue(
                        "@LicenseID",
                        licenseID);

                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                throw new Exception(
                                    "License not found.");
                            }


                            license.LicenseID =
                                Convert.ToInt32(
                                    reader["LicenseID"]);


                            license.ClassName =
                                reader["ClassName"]
                                .ToString();


                            license.CreatedByUsername =
                                reader["CreatedByUsername"]
                                .ToString();


                            license.IsActive =
                                Convert.ToBoolean(
                                    reader["IsActive"]);


                            license.IssueDate =
                                Convert.ToDateTime(
                                    reader["IssueDate"]);


                            license.ExpirationDate =
                                Convert.ToDateTime(
                                    reader["ExpirationDate"]);


                            license.Notes =
                                reader["Notes"] == DBNull.Value
                                ? null
                                : reader["Notes"].ToString();


                            license.IssueReason =
                                reader["IssueReason"]
                                .ToString();


                            license.DriverID =
                                Convert.ToInt32(
                                    reader["DriverID"]);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception(
                            "Error getting license data: "
                            + e.Message);
                    }
                }
            }

            return license;
        }


        public static int GetPersonIDByLicenseID(
            int licenseID)
        {
            using (SqlConnection conn =
                connection.ConnectionString())
            {
                string query = @"
                    SELECT PersonID
                    FROM Drivers
                    WHERE DriverID =
                    (
                        SELECT DriverID
                        FROM Licenses_View
                        WHERE LicenseID = @LicenseID
                    )";

                using (SqlCommand command =
                    new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue(
                        "@LicenseID",
                        licenseID);

                    try
                    {
                        conn.Open();

                        object result =
                            command.ExecuteScalar();


                        if (result == null ||
                            result == DBNull.Value)
                        {
                            throw new Exception(
                                "Person ID was not found for this license.");
                        }


                        return Convert.ToInt32(result);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(
                            "Error getting PersonID: "
                            + e.Message);
                    }
                }
            }
        }
    }
}