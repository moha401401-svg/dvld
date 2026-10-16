using DataAccessLayer.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer.Models
{
    public class DetainedLicenses
    {

        public static int AddDetainedLicense(int licenseID, decimal fineFees)
        {
            int createdByUserID = CurrentUser.User.UserID;
            DateTime detainDate = DateTime.Now;
            return DetainedLicensesRepo.AddDetainedLicense(licenseID, detainDate, fineFees, createdByUserID);

        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return DetainedLicensesRepo.IsLicenseDetained(LicenseID);
        }
        public static DataTable GetDetainedLicenses() { return DetainedLicensesRepo.GetDetainedLicenses(); }


        public static bool ReleaseLicense( int detainID )
        {
            int LicenseID= DetainedLicensesRepo.GetLicenseID( detainID );
            int PersonID= Licenses.GetPersonID( LicenseID );
            int releaseApplicationID = Applications.Add(PersonID, DateTime.Now, enApplicationType.ReleaseDetainedLicense);
            int releasedByUserID = CurrentUser.User.UserID;
            return DetainedLicensesRepo.ReleaseLicense(detainID, releaseApplicationID, releasedByUserID);

            
        }

        public static int GetLicenseID(int detainID) { return DetainedLicensesRepo.GetLicenseID(detainID); }
        public static decimal GetFineFees(int detainID) { return DetainedLicensesRepo.GetFineFees(detainID); }




    }
}
