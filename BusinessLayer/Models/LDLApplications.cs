using DataAccessLayer.Repo;
using DVDL.Business.connectionString;
using DVLD.Business;
using DVLD.Business.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public  class LDLApplications
    {

        public static int Add( int LicenseClassID, int personid,enApplicationType type)
        {
            DateTime ApplicationDate = DateTime.Now;
            int AppID = Applications.Add(personid, ApplicationDate,type);
            if (AppID == 0) { return 0; }
            int LDLID= LDLApplicationsRepo.Add(AppID, LicenseClassID);
            return LDLID;
           


        }
        public static int GetApplicationID(int LDLAppID) { return LDLApplicationsRepo.GetApplicationID(LDLAppID); }

        public static int GetLicenseClassId(int id)
        {
            return LDLApplicationsRepo.GetLicenseClassId(id);

        }
    }
}
