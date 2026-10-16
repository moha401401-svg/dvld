using DVDL.Business.connectionString;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repo;
using System.Data;

namespace BusinessLayer.Models
{
    public class LDLApplications_View
    {

       public static DataTable GetData()
        {
            return LDLApplications_ViewRepo.GetAlldata();
        }
    }
}
