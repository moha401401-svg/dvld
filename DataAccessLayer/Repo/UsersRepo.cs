using DVDL.Business.connectionString;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataAccessLayer.Repo
{
    public class UsersRepo
    {
        public struct stUser
        {
            
            public int UserID { get; set; }
            public int PersonID { get; set; }
            public string UserName { get; set; }
        
            
            public bool IsActive { get; set; }
            public string Password { get; set; }
           
          
            public int UserPermissions { get; set; }

            public stUser(int UserID)
            {
                this.UserID = UserID;
               
                UserName = string.Empty;
               
               
                IsActive = false;
                Password = string.Empty;
                
                PersonID = 0;
                UserPermissions = 0;
             
            }
            public stUser( int PersonID,string UserName,
                        string Password, bool isactive,int UserPermissions)
            {
                this.UserID = 0;
               this.IsActive= isactive ;
               this.UserName = UserName;
               
                
                this.Password = Password;
               
                this.PersonID = PersonID;
                this.UserPermissions= UserPermissions;
             
            }
            public stUser( string UserName,
                          string Password)
            {
                this.UserID = 0;
                
                this.UserName = UserName;
                PersonID= 0;

                this.IsActive = false;
                this.Password = Password;
                UserPermissions= 0;

                
                
            }

        }
       
        public static int Insertion(stUser User)
        {

            SqlConnection conn = connection.ConnectionString();

            string query = @"INSERT INTO Users 
                        ( UserName,
                          IsActive, Password, 
                         PersonID,UserPermissions )
                        VALUES 
                        ( @UserName, 
                           @IsActive, @Password, 
                         @PersonID,@UserPermissions);
                           select SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, conn);


            
            
            command.Parameters.AddWithValue("@UserName", User.UserName);
    
            command.Parameters.AddWithValue("@IsActive", User.IsActive);
            command.Parameters.AddWithValue("@Password", User.Password);
            command.Parameters.AddWithValue("@UserPermissions", User.UserPermissions);

            command.Parameters.AddWithValue("@PersonID", User.PersonID);
    


            try
            {
                conn.Open();
                object id = command.ExecuteScalar();
                if (id != null && id != DBNull.Value)
                {
                    conn.Close();
                    return Convert.ToInt32(id);
                }
                else { conn.Close(); return 0; }

            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        public static bool IsPersonUser ( int PersonID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = "select IsExist=1 from Users where PersonID=@PersonID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                conn.Open();
                object IsExist = cmd.ExecuteScalar();
                conn.Close();
                return IsExist!= null;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public static bool IsUserExist(string UserName)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = "select IsExist=1 from Users where UserName=@UserName;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                conn.Open();
                object IsExist = cmd.ExecuteScalar();
                conn.Close();
                return IsExist!=null;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        public static bool UpdateCurrentUser(int UserID,string UserName,string Password,bool IsActive)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @"UPDATE Users 
                        SET 
                            UserName = @UserName,
                              
                            
                            Password = @Password,
                            IsActive=@IsActive
                         
                            
                        WHERE UserID = @ID";


            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ID", UserID);
           
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@IsActive", IsActive);



            command.Parameters.AddWithValue("@Password", Password);
            
            

            try
            {
                conn.Open();
                int rowsAffected = command.ExecuteNonQuery();
                conn.Close();
                return (rowsAffected > 0); 
               
            }
            catch (Exception e) { throw new Exception(e.Message); }




        }
        public static bool UpdateCurrentUser(int UserID, string UserName, bool IsActive)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @"UPDATE Users 
                        SET 
                            UserName = @UserName,
                              
                            
                            
                            IsActive=@IsActive
                         
                            
                        WHERE UserID = @ID";


            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ID", UserID);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@IsActive", IsActive);



           



            try
            {
                conn.Open();
                int rowsAffected = command.ExecuteNonQuery();
                conn.Close();
                return (rowsAffected > 0);

            }
            catch (Exception e) { throw new Exception(e.Message); }




        }
        public static bool Delete(int ID)
        {

            SqlConnection conn = connection.ConnectionString();
            string query = "delete from Users where UserID=@ID;";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                conn.Open();
                int rowsaffected = command.ExecuteNonQuery();
                conn.Close();
                return (rowsaffected > 0);
              
                

            }
            catch (Exception e) { throw new Exception(e.Message); }




        }
        public static stUser GetUser(int ID)
        {
            stUser User = new stUser();
            SqlConnection conn = connection.ConnectionString();
            string query = "select * from Users where UserID=@ID;";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User.UserID = Convert.ToInt32(reader["UserID"]);
                    User.PersonID = Convert.ToInt32(reader["PersonID"]);
                    User.UserName = reader["UserName"].ToString();
                           
                    User.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    User.UserPermissions = Convert.ToInt32(reader["UserPermissions"]);
                   
                }
                conn.Close();
                return User;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        public static stUser GetUser(string UserName)
        {
            stUser User = new stUser();
            SqlConnection conn = connection.ConnectionString();
            string query = "select * from Users where UserName=@UserName;";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User.UserID = Convert.ToInt32(reader["UserID"]);
                    User.PersonID = Convert.ToInt32(reader["PersonID"]);
                    User.UserName = reader["UserName"].ToString();

                    User.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    User.UserPermissions = Convert.ToInt32(reader["UserPermissions"]);

                }
                conn.Close();
                return User;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public static DataTable GetAllUsers()
        {
            DataTable Users = new DataTable();
            SqlConnection conn = connection.ConnectionString();
            string query = "select UserID,PersonID,UserName,IsActive,UserPermissions from Users;";
            SqlCommand command = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                Users.Load(reader);
                
                conn.Close(); return Users;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        public static bool DisableUser(int UserID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = "update Users set IsActive=0 where UserID=@UserID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("UserId", UserID);
            try
            {
                conn.Open();
                object rowsaffected = cmd.ExecuteNonQuery();
                conn.Close();
                return (int)rowsaffected>  0;
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }
        public static bool ActiveUser(int UserID)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = "update Users set IsActive=1 where UserID=@UserID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("UserId", UserID);
            try
            {
                conn.Open();
                object rowsaffected = cmd.ExecuteNonQuery();
                conn.Close();
                return (int)rowsaffected > 0;
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }
        public static bool UpdatePermissions(int UserID, int UserPermissions)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = "update Users set UserPermissions=@UserPermissions where UserID=@UserID ";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserPermissions", UserPermissions);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                conn.Open();
                object rowsaffected = cmd.ExecuteNonQuery();
                conn.Close();
                return Convert.ToInt32(rowsaffected) > 0;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public static bool IsActive(string Username) {
            SqlConnection conn = connection.ConnectionString();
            string query = "select IsActive from Users where Username=@Username;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", Username);
            try
            {
                conn.Open();
                object IsExist = cmd.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(IsExist)==1;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        public static string GetPassword(string Username)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = "select Password from Users where Username=@Username;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", Username);
            try
            {
                conn.Open();
                object IsExist = cmd.ExecuteScalar();
                conn.Close();
                return IsExist.ToString();
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

    }
}
    internal class Program
    {
        static void Main(string[] args) { }
    }

