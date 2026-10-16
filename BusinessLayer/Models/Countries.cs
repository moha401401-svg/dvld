using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repo;
namespace BusinessLayer.Models
{
    public class Countries
    {
        public static DataTable GetAll()
        {
            return CountryRepo.GetAll();
        }
        public static string GetCountryName(int id) { return CountryRepo.GetCountryName(id); }
    }
}
