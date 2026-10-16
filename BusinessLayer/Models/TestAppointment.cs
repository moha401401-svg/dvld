using DataAccessLayer.Repo;
using DVDL.Business.connectionString;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class TestAppointment
    {

        public static bool Add(int TestTypeID, DateTime AppointmentDate, int LocalDrivingLicenseApplicationID)
        {
           double PaidFees= TestTypes.GetFees(TestTypeID);
           int UserID= CurrentUser.User.UserID;
            return TestAppointmentRepo.Add(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, UserID, false);
        }
        public static bool IsLocked(int TestAppointmentID)
        {
            return TestAppointmentRepo.IsLocked(TestAppointmentID);
        }

        public static bool ModifyAppointment(int TestAppointmentID, DateTime AppointmentDate)
        {
            return TestAppointmentRepo.ModifyAppointment(TestAppointmentID, AppointmentDate);
        }
        public static bool Lock(int TestAppointmentID)
        {
            return TestAppointmentRepo.Lock(TestAppointmentID);
        }

        public static bool delete(int TestAppointmentID)
        {
            return TestAppointmentRepo.delete(TestAppointmentID);
        }
        public static bool CanGetAppointment(int LocalDrivingLicenseApplicationID) { return TestAppointmentRepo.CanGetAppointment(LocalDrivingLicenseApplicationID); }
        public static bool IsRetake(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return TestAppointmentRepo.IsRetake(LocalDrivingLicenseApplicationID, TestTypeID);
        }

    }
}
