using DataAccessLayer.Repo;

using System;
using System.Data;
using static DataAccessLayer.Repo.InternationalLicenses_ViewRepo;

namespace BusinessLayer.Models
{
    public class InternationalLicenses_View
    {

        public int InternationalLicenseID { get; private set; }

        public int ApplicationID { get; private set; }

        public int DriverID { get; private set; }

        public int IssuedUsingLocalLicenseID { get; private set; }

        public DateTime IssueDate { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public bool IsActive { get; private set; }

        public int CreatedByUserID { get; private set; }



        public InternationalLicenses_View(
            stInternationalLicense license)
        {
            InternationalLicenseID =
                license.InternationalLicenseID;

            ApplicationID =
                license.ApplicationID;

            DriverID =
                license.DriverID;

            IssuedUsingLocalLicenseID =
                license.IssuedUsingLocalLicenseID;

            IssueDate =
                license.IssueDate;

            ExpirationDate =
                license.ExpirationDate;

            IsActive =
                license.IsActive;

            CreatedByUserID =
                license.CreatedByUserID;
        }




        public static DataTable GetInternationalLicensesByDriverID(
            int driverID)
        {
            return InternationalLicenses_ViewRepo
                .GetInternationalLicensesByDriverID(
                    driverID);
        }




        public static InternationalLicenses_View GetInternationalLicenseByID(
            int internationalLicenseID)
        {

            stInternationalLicense license =
                InternationalLicenses_ViewRepo
                .GetInternationalLicenseByID(
                    internationalLicenseID);


            if (license.InternationalLicenseID == 0)
                return null;


            return new InternationalLicenses_View(
                license);
        }

    }
}