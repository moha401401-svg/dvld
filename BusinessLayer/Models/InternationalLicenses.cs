using DataAccessLayer.Repo;
using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{

    
    public class InternationalLicenses
    {

        public enum enIssueReason
        {

            Damaged = 3,
            Lost = 4
        }

        public static int Insertion(enIssueReason IssueReason, int OldLicenseID)
        {

            int PersonID = InternationalLicensesRepo.GetPersonID(OldLicenseID);

            enApplicationType type = (enApplicationType)IssueReason;

            int AppID = Applications.Add(PersonID, DateTime.Now, type);
            int DriverID= InternationalLicensesRepo.GetDriverID(PersonID);
           
            int userID = CurrentUser.User.UserID;
            

            
            
                if (InternationalLicensesRepo.Deactivate(OldLicenseID)) { return InternationalLicensesRepo.AddInternationalLicense(AppID,DriverID,OldLicenseID,DateTime.Now,DateTime.Now.AddYears(1),true,userID); }
                return 0;
         

        }

        public static int Insertion(int OldLicenseID)
        {

            

            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now.AddYears(1);
            int userID = CurrentUser.User.UserID;
           
            int PersonID = LicensesRepo.GetPersonID(OldLicenseID);
            int AppID = LicensesRepo.GetAppID(OldLicenseID);
            int DriverID, licenseID;

       



            

            
             DriverID = DriverRepo.GetDriver(PersonID);

             return InternationalLicensesRepo.AddInternationalLicense(AppID,DriverID,OldLicenseID, IssueDate, ExpirationDate, true,userID);
             


            
    


        }



        public static bool HasAnActiveLicense(int DriverID) { return InternationalLicensesRepo.HasAnActiveLicense(DriverID); }
        public static int GetDriverID(int InternationalLicenseID) { return InternationalLicensesRepo.GetDriverID(InternationalLicenseID); }
        public static int GetPersonID(int InternationalLicenseID) { return InternationalLicensesRepo.GetPersonID(InternationalLicenseID);  }
    }
}
