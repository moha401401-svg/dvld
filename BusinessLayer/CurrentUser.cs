using BusinessLayer.Models;
using DVLD.Business.Models;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class CurrentUser
    {
       public static Users User {  get; set; }
        public static People Person {  get; set; }




        public static event Action UserChanged;
        public static void  Login( string UserName) {
            User = Users.GetUser(UserName);
            Person = People.GetPerson(User.PersonID);
          
        }
        public static void Refresh()
        {
            User =
                Users.GetUser(User.UserID);

            Person = People.GetPerson(User.PersonID);

            UserChanged?.Invoke();
        }
        public static void logout()
        {
            User = null;
            Person = null;
            
           
        }

        public static bool HasPermission(enPermissions permission)
        {
            return User.UserPermissions == (int)enPermissions.All ||
                   (((enPermissions)User.UserPermissions & permission) == permission);
        }

    }
}
