using DVDL.Business.connectionString;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
   public static class ApplicationStatusRepo
    {
        public static string GetStatusName(int id)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = "select StatusName from ApplicationStatus where StatusID=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                conn.Open();
                object obj = cmd.ExecuteScalar();
                if (obj == null) { return ""; }
                string Statusname = obj.ToString();

                conn.Close();
                return Statusname;
            }
            catch  { return ""; }
        }
    }
}
