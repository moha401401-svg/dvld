using DataAccessLayer.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public static class Drivers
    {
        public static int Add(int PersonID)
        {
            DateTime CreatedDate = DateTime.Now;
            int userID = CurrentUser.User.UserID;
            return DriverRepo.Add(PersonID,userID,CreatedDate);
        }
    }
}
