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
    public static class Drivers_ViewRepo
    {
        public static DataTable GetAlldata()
        {
            DataTable data = new DataTable();

            using (SqlConnection conn = connection.ConnectionString())
            {
                string query =
                    @"update licenses set IsActive=0 where ExpirationDate<GETDATE();
                      update Internationallicenses set IsActive=0 where ExpirationDate<GETDATE();
                    SELECT * FROM Drivers_View";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            data.Load(reader);
                        }
                    }
                    catch (Exception e) { throw new Exception(e.Message); }
                }
            }

            return data;
        }
    }
}
