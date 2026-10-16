using DVLD.DataAccess;
using System.Collections.Generic;
using System.Data;

namespace DVLD.Business
{
    public class LicenseClasses
    {

        public static DataTable GetAll()
        {
            return
                LicenseClassesRepo.GetAll();
        }



        public static double GetClassFees( int LicenseClassID)
        {
            return
                LicenseClassesRepo.GetClassFees(
                    LicenseClassID);
        }
        public static HashSet<int> BlockedClasses(int id)
        {
            return LicenseClassesRepo.BlockedClasses(id);
        }
        public static string GetClassName(int id) { return LicenseClassesRepo.GetClassName(id); }


        public static int GetValidityLength(int id) { return LicenseClassesRepo.GetValidityLength(id); }
    }
}