using DataAccessLayer.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class TestTypes
    {
        public static DataTable GetAll()
        {
            return TestTypesRepo.GetAll();
        }
        public static bool UpdateFees(int id, int fees) { return TestTypesRepo.UpdateFees(id, fees); }
        public static double GetFees(int id) { return TestTypesRepo.GetFees(id); }
        public static string GetDes(int id) { return TestTypesRepo.GetDes(id); }
        public static string GetName(int id) { return TestTypesRepo.GetName(id); }
    }
}
