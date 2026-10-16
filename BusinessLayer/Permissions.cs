using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    [Flags]
    public enum enPermissions
    {
        None = 0,

        People = 1,
        ManageUsers = 2,
        Drivers = 4,
        Licenses = 8,
        Types = 16,
        ApplicationTypes = 32,
        AddAndRenewLocalLicense = 64,
        AddInternationalLicense = 128,
        ManageLocal = 256,
        ReplacementLicense = 512,
        DetainedLicense = 1024,
        All = -1
    }
}
