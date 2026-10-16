using DataAccessLayer.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public static class Test
    {
        public static bool Add(int TestAppointmentID, bool TestResult, string Notes)
        {
            int pass;
            if (TestResult) { pass = 1; }
            else pass = 0;
            int CreatedByUserID = CurrentUser.User.UserID;
            return TestRepo.Add(TestAppointmentID, pass, Notes, CreatedByUserID);
        }
    }
}
