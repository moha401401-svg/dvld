using DataAccessLayer.Repo;
using DVDL.Business.connectionString;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer.Models
{
    public class ApplicationTypes
    {
        public static DataTable GetAll()
        {
            return ApplicationTypesRepo.GetAll();
        }
        public static bool UpdateFees(int id, int fees) { return ApplicationTypesRepo.UpdateFees(id, fees); }
        public static double GetFees(int id)
        {

          return ApplicationTypesRepo.GetFees(id);
        }
    }
}
