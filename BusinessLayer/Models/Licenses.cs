using DataAccessLayer.Repo;
using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class Licenses
    {

        public enum enIssueReason
        {
       
            Damaged = 3,
            Lost = 4
        }

        public static int Insertion( int LDLAppID, string Notes, enIssueReason IssueReason,int OldLicenseID)
        {

            int LicenseClass = LDLApplicationsRepo.GetLicenseClassId(LDLAppID);

            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now.AddYears(LicenseClassesRepo.GetValidityLength(LicenseClass));
            int userID = CurrentUser.User.UserID;
            double PaidFees = ApplicationTypesRepo.GetFees((int)IssueReason);
            int PersonID = ApplicationsRepo.GetPersonId(LDLAppID);
            int DriverID = DriverRepo.GetDriver(PersonID);
            int AppID = LDLApplications.GetApplicationID(LDLAppID);
            if (IssueReason == enIssueReason.Damaged) {
                if (LicensesRepo.Deactivate(OldLicenseID)) { return LicensesRepo.Insertion(AppID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, true, 3, userID); }
                else return 0;
            }
            if (LicensesRepo.Deactivate(OldLicenseID)) { return LicensesRepo.Insertion(AppID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, true, 4, userID); }
            else return 0;

        }

        public static int Insertion( int LDLAppID , string Notes)
        {


            int LicenseClass = LDLApplicationsRepo.GetLicenseClassId(LDLAppID);
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now.AddYears(LicenseClassesRepo.GetValidityLength(LicenseClass));
            int userID = CurrentUser.User.UserID;
          
            int PersonID = ApplicationsRepo.GetPersonId(LDLAppID);
            int AppID= LDLApplications.GetApplicationID(LDLAppID);
            int DriverID, licenseID;

            if (LicensesRepo.IsFirstLicense(LicenseClass, PersonID))
            {
                double PaidFees = LicenseClassesRepo.GetClassFees(1);
                if (DriverRepo.IsDriver(PersonID))
                {
                    DriverID = DriverRepo.GetDriver(PersonID);
                    licenseID = LicensesRepo.Insertion(AppID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, true, 1, userID);
                }
                else
                {
                    DriverID = DriverRepo.Add(PersonID, userID, IssueDate);
                    licenseID = LicensesRepo.Insertion(AppID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, true, 1, userID);
                }

               

            }
            else
            {
                double PaidFees = LicenseClassesRepo.GetClassFees(2);
                DriverID = DriverRepo.GetDriver(PersonID);
              
                licenseID = LicensesRepo.Insertion(AppID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, true, 2, userID); 
             
                

            }
            return licenseID;


        }

        public static bool IsActive(int LicenseID) {return LicensesRepo.IsActive(LicenseID); }
        public static int GetLicenseClass(int id) { return LicensesRepo.GetLicenseClass(id); }
        public static bool IsFirstLicense(int LicenseClass,int PersonID) {
         
            return LicensesRepo.IsFirstLicense(LicenseClass, PersonID); 
        }

        public static int GetPersonID(int LicenseiD) { return LicensesRepo.GetPersonID(LicenseiD); }
        public static bool Deactivate(int licenseID) { return LicensesRepo.Deactivate(licenseID);  }
        public static bool Activate(int licenseID) { return LicensesRepo.Activate(licenseID); }

    }
}
