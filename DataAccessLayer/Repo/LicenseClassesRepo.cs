using DVDL.Business.connectionString;
using DVLD.DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.DataAccess
{
    public class LicenseClassesRepo
    {

        public static DataTable GetAll()
        {
            DataTable dt =
                new DataTable();


            SqlConnection conn =connection.ConnectionString();


            string query =
                @"SELECT 
                    LicenseClassID,
                    ClassName,
                    ClassDescription,
                    MinimumAllowedAge,
                    DefaultValidityLength,
                    ClassFees
                  FROM LicenseClasses";


            SqlCommand cmd =
                new SqlCommand(
                    query,
                    conn);


            try
            {
                conn.Open();


                SqlDataReader reader =
                    cmd.ExecuteReader();


                dt.Load(reader);


                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error loading license classes: "
                    + ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return dt;
        }
        public static double GetClassFees(
    int LicenseClassID)
        {
            double fees = 0;


            SqlConnection conn = connection.ConnectionString();


            string query =
                @"SELECT ClassFees
          FROM LicenseClasses
          WHERE LicenseClassID = @LicenseClassID";


            SqlCommand cmd =
                new SqlCommand(
                    query,
                    conn);


            cmd.Parameters.AddWithValue(
                "@LicenseClassID",
                LicenseClassID);


            try
            {
                conn.Open();


                object result =
                    cmd.ExecuteScalar();


                if (result != null &&
                    result != DBNull.Value)
                {
                    fees =
                        Convert.ToDouble(result);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error getting license class fees: "
                    + ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return fees;
        }

        public static string GetClassName( int LicenseClassID)
        {
            


            SqlConnection conn = connection.ConnectionString();
            string name= string.Empty;

            string query =
                @"SELECT ClassName
          FROM LicenseClasses
          WHERE LicenseClassID = @LicenseClassID";


            SqlCommand cmd =
                new SqlCommand(
                    query,
                    conn);


            cmd.Parameters.AddWithValue(
                "@LicenseClassID",
                LicenseClassID);


            try
            {
                conn.Open();


                object result =
                    cmd.ExecuteScalar();


                if (result != null &&
                    result != DBNull.Value)
                {
                    name =
                        result.ToString();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error getting license class fees: "
                    + ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return name;
        }

        public static int GetValidityLength(int LicenseClassID)
        {



            SqlConnection conn = connection.ConnectionString();
            int len = 0;

            string query =
                @"SELECT DefaultValidityLength
          FROM LicenseClasses
          WHERE LicenseClassID = @LicenseClassID";


            SqlCommand cmd =
                new SqlCommand(
                    query,
                    conn);


            cmd.Parameters.AddWithValue(
                "@LicenseClassID",
                LicenseClassID);


            try
            {
                conn.Open();


                object result =
                    cmd.ExecuteScalar();


                if (result != null &&
                    result != DBNull.Value)
                {
                    len =
                      Convert.ToInt32(result);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error getting Validity Length: "
                    + ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return len;
        }


        public static HashSet<int> BlockedClasses(int id)
        {
            HashSet<int> classes = new HashSet<int>();
            SqlConnection conn = connection.ConnectionString();
            string query =
                @"select  LicenseClass from Licenses where IsActive=1 and DriverID =
                ( select  DriverID from Drivers where PersonID = @id)
                union
                select LicenseClassID from LicenseClasses
                where MinimumAllowedAge > (select age = DATEDIFF(year, DateOfBirth, GETDATE()) from People where PersonID = @id)
                union 
                select  LicenseClassID from LocalDrivingLicenseApplications where ApplicationID in 
                (select ApplicationID from Applications where ApplicantPersonID=@id and ApplicationStatus=1)";


            SqlCommand cmd =
                new SqlCommand(
                    query,
                    conn);


            cmd.Parameters.AddWithValue(
                "@id", id);


            try
            {
                conn.Open();


                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        classes.Add(reader.GetInt32(0));
                    }

            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error getting blocked license classes: "
                    + ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return classes;
        }


        
    }

    }
