using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using DVDL.Business.connectionString;
using System.Data;

namespace DVLD.DataAccess.Repo
{

    public static class PeopleR
    {
        public struct stPeopleRepo
        {
            public int PersonID { get; set; }
            public string NationalNo { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string ThirdName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int Gender { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public int NationalityCountryID { get; set; }
            public string ImagePath { get; set; }

            public stPeopleRepo(int PersonID)
            {
                this.PersonID = PersonID;
                NationalNo = string.Empty;
                FirstName = string.Empty;
                SecondName = string.Empty;
                ThirdName = string.Empty;
                LastName = string.Empty;
                DateOfBirth = DateTime.MinValue;
                Gender = 0;
                Address = string.Empty;
                Phone = string.Empty;
                Email = string.Empty;
                NationalityCountryID = 0;
                ImagePath = string.Empty;
            }
            public stPeopleRepo(int personID, string nationalNo, string firstName, string secondName,
                          string thirdName, string lastName, DateTime dateOfBirth, int gender,
                          string address, string phone,string Email, int nationalityCountryID, string imagePath)
            {
                PersonID = personID;
                NationalNo = nationalNo;
                FirstName = firstName;
                SecondName = secondName;
                ThirdName = thirdName;
                LastName = lastName;
                DateOfBirth = dateOfBirth;
                Gender = gender;
                Address = address;
                Phone = phone;
                this.Email = Email;
                NationalityCountryID = nationalityCountryID;
                ImagePath = imagePath;
            }
            public stPeopleRepo(string nationalNo, string firstName, string secondName,
                          string thirdName, string lastName, DateTime dateOfBirth, int gender,
                          string address, string phone,string Email, int nationalityCountryID, string imagePath)
            {
                PersonID = 0;
                NationalNo = nationalNo;
                FirstName = firstName;
                SecondName = secondName;
                ThirdName = thirdName;
                LastName = lastName;
                DateOfBirth = dateOfBirth;
                Gender = gender;
                Address = address;
                Phone = phone;
                this.Email = Email;
                NationalityCountryID = nationalityCountryID;
                ImagePath = imagePath;
            }

        }
        
        public static int Insertion(stPeopleRepo person)
        {
            SqlConnection conn = connection.ConnectionString();
            string query = @"INSERT INTO People 
                        ( NationalNo, FirstName, SecondName, ThirdName, 
                         LastName, DateOfBirth, Gender, Address, Phone, Email,
                         NationalityCountryID, ImagePath)
                        VALUES 
                        ( @NationalNo, @FirstName, @SecondName, @ThirdName, 
                         @LastName, @DateOfBirth, @Gender, @Address, @Phone, @Email,
                         @NationalityCountryID, @ImagePath);
                           select SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, conn);


           
            command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
            command.Parameters.AddWithValue("@FirstName", person.FirstName);
            command.Parameters.AddWithValue("@SecondName", person.SecondName);
            command.Parameters.AddWithValue("@ThirdName", person.ThirdName);
            command.Parameters.AddWithValue("@LastName", person.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Phone", person.Phone);
            command.Parameters.AddWithValue("@Email", person.Email);
            command.Parameters.AddWithValue("@NationalityCountryID", person.NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", person.ImagePath);


            try
            {
                conn.Open();
                object id = command.ExecuteScalar();
                if (id != null)
                {
                    conn.Close();
                    return (int)id;
                }
                else { conn.Close(); return 0; }

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static bool Update(stPeopleRepo person)
        {
            using (SqlConnection conn = connection.ConnectionString())
            {
                string query = @"UPDATE People 
                        SET NationalNo = @NationalNo,
                            FirstName = @FirstName,
                            SecondName = @SecondName,
                            ThirdName = @ThirdName,
                            LastName = @LastName,
                            DateOfBirth = @DateOfBirth,
                            Gender = @Gender,
                            Address = @Address,
                            Phone = @Phone,
                            Email=@Email,
                            NationalityCountryID = @NationalityCountryID,
                            ImagePath = @ImagePath
                        WHERE PersonID = @ID";


                SqlCommand command = new SqlCommand(query, conn);

                object imagePath = string.IsNullOrEmpty(person.ImagePath)
                                                                    ? (object)DBNull.Value
                                                                    : person.ImagePath;

                command.Parameters.AddWithValue("@ID", person.PersonID);
                command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
                command.Parameters.AddWithValue("@FirstName", person.FirstName);
                command.Parameters.AddWithValue("@SecondName", person.SecondName);
                command.Parameters.AddWithValue("@ThirdName", person.ThirdName);
                command.Parameters.AddWithValue("@LastName", person.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", person.Gender);
                command.Parameters.AddWithValue("@Address", person.Address);
                command.Parameters.AddWithValue("@Phone", person.Phone);
                command.Parameters.AddWithValue("@Email", person.Email);
                command.Parameters.AddWithValue("@NationalityCountryID", person.NationalityCountryID);

                command.Parameters.AddWithValue("@ImagePath", imagePath);
                try
                {
                    conn.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch {  return false; }
            }
        }
        public static bool Delete(int ID) {

            SqlConnection conn = connection.ConnectionString();
            string query = "delete from People where PersonID=@ID;";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                conn.Open();
                int rowsaffected = command.ExecuteNonQuery();
                conn.Close();
                if (rowsaffected > 0) return true;
            
                else return false;

            }
            catch (Exception ex) { return false; }




        }
        public static stPeopleRepo GetPerson(int ID) {
            stPeopleRepo person = new stPeopleRepo();
            SqlConnection conn = connection.ConnectionString();
            string query = "select * from People where PersonID=@ID;";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    person.PersonID = Convert.ToInt32(reader["PersonID"]);
                    person.NationalNo = reader["NationalNo"].ToString();
                    person.FirstName = reader["FirstName"].ToString();
                    person.SecondName = reader["SecondName"].ToString();
                    person.ThirdName = reader["ThirdName"].ToString();
                    person.LastName = reader["LastName"].ToString();
                    person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    person.Gender = Convert.ToInt32(reader["Gender"]);
                    person.Address = reader["Address"].ToString();
                    person.Phone = reader["Phone"].ToString();
                    person.Email = reader["Email"].ToString();
                    person.NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    person.ImagePath = reader["ImagePath"].ToString();
                }
                conn.Close();
                return person;
            }


            catch (Exception ex) { return person; }
        }
        public static stPeopleRepo GetPerson(string NationalNo)
        {
            stPeopleRepo person = new stPeopleRepo();
            SqlConnection conn = connection.ConnectionString();
            string query = "select * from People where NationalNO=@NationalNo;";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    person.PersonID = Convert.ToInt32(reader["PersonID"]);
                    person.NationalNo = reader["NationalNo"].ToString();
                    person.FirstName = reader["FirstName"].ToString();
                    person.SecondName = reader["SecondName"].ToString();
                    person.ThirdName = reader["ThirdName"].ToString();
                    person.LastName = reader["LastName"].ToString();
                    person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    person.Gender = Convert.ToInt32(reader["Gender"]);
                    person.Address = reader["Address"].ToString();
                    person.Phone = reader["Phone"].ToString();
                    person.Email = reader["Email"].ToString();
                    person.NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    person.ImagePath = reader["ImagePath"].ToString();
                }
                conn.Close();
                return person;
            }


            catch (Exception ex) { return person; }
        }
        public static DataTable GetAllPeople()
        {
            DataTable people = new DataTable();

            using (SqlConnection conn = connection.ConnectionString())
            {
                string query = "SELECT * FROM People";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            people.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        return people;
                    }
                }
            }

            return people;
        }

        public static DataTable GetAllFewDetails()
        {
            DataTable people = new DataTable();

            using (SqlConnection conn = connection.ConnectionString())
            {
                string query = "SELECT PersonID,NationalNo,FullName=FirstName+' '+SecondName+' '+ThirdName+' '+LastName,Phone,Email FROM People";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            people.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        return people;
                    }
                }
            }

            return people;
        }



    }
    
}





  
