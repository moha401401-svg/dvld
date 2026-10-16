using DataAccessLayer.Repo;
using System;
using System.Data;

namespace BusinessLayer.Models
{
    public class Licenses_View
    {
        public int LicenseID { get; private set; }

        public string ClassName { get; private set; }

        public string CreatedByUsername { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime IssueDate { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public string Notes { get; private set; }

        public string IssueReason { get; private set; }

        public int DriverID { get; private set; }


        public static DataTable GetAll( int DriverID)
        {
            return Licenses_ViewRepo.GetAlldata(
                DriverID);
        }

        public static DataTable GetAlldata() { return Licenses_ViewRepo.GetAlldata(); }
        public static Licenses_View GetLicense( int licenseID)
        {
            Licenses_ViewRepo.stLicenseView data =
                Licenses_ViewRepo.GetLicense(
                    licenseID);


            return new Licenses_View
            {
                LicenseID =
                    data.LicenseID,

                ClassName =
                    data.ClassName,

                CreatedByUsername =
                    data.CreatedByUsername,

                IsActive =
                    data.IsActive,

                IssueDate =
                    data.IssueDate,

                ExpirationDate =
                    data.ExpirationDate,

                Notes =
                    data.Notes,

                IssueReason =
                    data.IssueReason,

                DriverID =
                    data.DriverID
            };
        }


        public static int GetPersonIDByLicenseID(
            int licenseID)
        {
            return Licenses_ViewRepo
                .GetPersonIDByLicenseID(
                    licenseID);
        }
    }
}