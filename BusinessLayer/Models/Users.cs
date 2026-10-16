using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repo;
using DVLD.Business.Models;

namespace BusinessLayer.Models
{
    public class Users
    {
        public enum LoginResult
        {
            Success,
            UserNotFound,
            WrongPassword,
            Inactive
        }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
       
        public int PersonID { get; set; }
        public int UserPermissions { get; set; }
        public static bool IsPerson(int PersonID)
        {
            return People.GetPerson(PersonID) != null;
        }
        public static bool IsPersonUser(int PersonID)
        {
            return UsersRepo.IsPersonUser(PersonID);
        }
        public static Users GetUser(int UserID)
        {
            UsersRepo.stUser user=  UsersRepo.GetUser(UserID);
            return new Users { UserID = user.UserID, UserName = user.UserName, IsActive = user.IsActive, UserPermissions = user.UserPermissions, PersonID = user.PersonID }; ;
        }
        public static Users GetUser(string UserName)
        {
            UsersRepo.stUser user = UsersRepo.GetUser(UserName);
            return new Users { UserID = user.UserID, UserName = user.UserName, IsActive = user.IsActive, UserPermissions = user.UserPermissions, PersonID = user.PersonID }; ;
        }
        public static void SaveInRememberMe(string username)
        {
            string pass = GetPassword(username);
            RememberME.WriteInFile(username, pass);

        }
        public static bool IsUserExist(string UserName)
        {
            return UsersRepo.IsUserExist(UserName);
        }
        public static bool CanBeUser(int PersonID, string UserName)
        {
            return IsPerson(PersonID) && !IsPersonUser(PersonID) && !IsUserExist(UserName);
        }
        public static DataTable GetAll()
        {
           return UsersRepo.GetAllUsers();
        }
        public  int AddUser()
        {
            if (CanBeUser(this.PersonID,this.UserName)){
              this.Password=  HashPassword(this.Password);
                UsersRepo.stUser user = new UsersRepo.stUser(this.PersonID, this.UserName, this.Password, this.IsActive, this.UserPermissions);
                this.UserID = UsersRepo.Insertion(user);
                    user.UserID = this.UserID;
                return this.UserID;
            }
            else if (IsPersonUser(this.PersonID)) { return -1; }
            return 0;
        }
        public static bool DisableUser(int UserID)
        {
            return UsersRepo.DisableUser(UserID);
        }
        public static bool DeleteUser(int UserID)
        {
            return UsersRepo.Delete(UserID);
        }
        public static bool UpdateUser(Users user)
        {
            if (user.Password != "")
            {
                string pass = HashPassword(user.Password);
                if (!UsersRepo.UpdateCurrentUser(user.UserID, user.UserName, pass, user.IsActive)) return false;
            }
           if(!UsersRepo.UpdateCurrentUser(user.UserID, user.UserName, user.IsActive)) { return false; }
            CurrentUser.Refresh();
            SaveInRememberMe(CurrentUser.User.UserName);
            return true;

        }
        public static bool UpdateUserPermissions(int UserID, int UserPermissions)
        {
            if (UserID == CurrentUser.User.UserID)
            {
                return false;
            }
            if( UsersRepo.UpdatePermissions(UserID, UserPermissions))
            {
                CurrentUser.Refresh();
                return true;
            }
            return false;
        }
        public static bool ActiveUser(int UserID)
        {
            return UsersRepo.ActiveUser(UserID);
        }
        public static bool IsUserActive(string UserName)
        {
           return UsersRepo.IsActive(UserName);
        }
        public static string GetPassword(string UserName)
        {
           return UsersRepo.GetPassword(UserName);
        }
        public static string HashPassword(string Pass) { return PasswordHelper.HashPassword(Pass); }
        public static bool VerifyPassword(string Pass,string hash) { return PasswordHelper.VerifyPassword(Pass,hash); }
        public static LoginResult login(string UserName,string Password)
        {
            if (IsUserExist(UserName))
            {
                string HashedPassword = Users.GetPassword(UserName);

                if ((!string.IsNullOrEmpty(HashedPassword) && (Users.VerifyPassword(Password, HashedPassword) || Password == HashedPassword)))
                {
                    if (Users.IsUserActive(UserName)) { CurrentUser.Login(UserName); return LoginResult.Success; }
                    else { RememberME.Logout(); return LoginResult.Inactive; }
                }
                else { RememberME.Logout(); return LoginResult.WrongPassword; }
            }
            else { RememberME.Logout(); return LoginResult.UserNotFound; }
        }
    }




    }

