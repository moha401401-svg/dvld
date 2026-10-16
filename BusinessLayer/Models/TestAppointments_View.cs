using DataAccessLayer.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class TestAppointments_View
    {

        public static DataTable GetAppointments(int LocalDrivingLicenseApplicationID) {
            return TestAppointments_ViewRepo.GetAppointments(LocalDrivingLicenseApplicationID);
        }

    }
}
