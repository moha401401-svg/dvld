using DVDL.Business.connectionString;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer.Repo
{
    public static class LDLApplications_ViewRepo
    {
        
        public static DataTable GetAlldata()
        {
            DataTable data = new DataTable();

            using (SqlConnection conn = connection.ConnectionString())
            {
                string query = "SELECT * FROM LocalDrivingLicenseApplications_View";

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
