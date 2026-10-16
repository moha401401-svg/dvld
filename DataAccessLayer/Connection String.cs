using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL.Business.connectionString
{
    public class connection
    {
        public static string ConnString = "Server=(localdb)\\MSSQLLocalDB;Database=DVLD;Integrated Security=true;";
        public  static SqlConnection ConnectionString()
        {
            return new SqlConnection(ConnString);
        }
    }
}
