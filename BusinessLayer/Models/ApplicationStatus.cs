using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repo;
namespace BusinessLayer.Models
{
    public class ApplicationStatus
    {
        public static string GetStatusName (int id) { return ApplicationStatusRepo.GetStatusName (id); }
    }
}
