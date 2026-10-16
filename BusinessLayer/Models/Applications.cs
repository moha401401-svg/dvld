using DataAccessLayer.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public enum enUpdateApplicationMode { New = 1, Cancel = 2, Completed = 3 }
    public enum enApplicationType
    {
        NewLocalLicense = 1,
        RenewLicense = 2,
        ReplaceLostLicense = 3,
        ReplaceDamagedLicense = 4,
        ReleaseDetainedLicense = 5,
        NewInternationalLicense = 6
    }
    public class Applications
    {


        public static int Add(int personid, DateTime ApplicationDate, enApplicationType TypeMode)
        {
            double fees = ApplicationTypes.GetFees((int)TypeMode);
            int userId = CurrentUser.User.UserID;

            enUpdateApplicationMode mode = enUpdateApplicationMode.New;
            return ApplicationsRepo.Add(personid, ApplicationDate, (int)TypeMode, fees, userId, (int)mode);

        }
        public static bool Update(int AppID, enUpdateApplicationMode mode)
        {
            DateTime LastStatusDate = DateTime.Now;
            int status = (int)mode;
            return ApplicationsRepo.Update(AppID, status, LastStatusDate);
        }
        public static int GetPersonId(int id) { return ApplicationsRepo.GetPersonId(id); }


        public static bool Cancel(int id) { return ApplicationsRepo.Cancel(id); }
    }
}
