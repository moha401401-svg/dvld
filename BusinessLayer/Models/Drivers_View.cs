using DataAccessLayer.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public static class Drivers_View
    {
        public static DataTable GetData()
        {
            return Drivers_ViewRepo.GetAlldata();
        }
    }


}
