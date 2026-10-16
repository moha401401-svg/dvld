using DVLD.DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace DVLD.Business.Models
{
    public class People
    {
        public enum enMode { add, update };



        public enMode Mode;
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
        public static bool IsPerson(int PersonID)
        {
            return GetPerson(PersonID) != null;
        }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public People()
        {
            this.PersonID = 0;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = 0;
            Address = string.Empty;
            Phone = string.Empty;

            NationalityCountryID = 0;
            ImagePath = string.Empty;
            this.Mode = enMode.add;
        }
        public People(int personID, string nationalNo, string firstName, string secondName,
                      string thirdName, string lastName, DateTime dateOfBirth, int gender,
                      string address, string phone, string Email, int nationalityCountryID, string imagePath)
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

            Mode = enMode.update;
        }
        public People(string nationalNo, string firstName, string secondName,
                      string thirdName, string lastName, DateTime dateOfBirth, int gender, string Email,
                      string address, string phone, int nationalityCountryID, string imagePath)
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
            Mode = enMode.add;
        }



        private bool _add()
        {
            PeopleR.stPeopleRepo person = new PeopleR.stPeopleRepo(this.NationalNo, this.FirstName, this.SecondName,
                                                                     this.ThirdName, this.LastName, this.DateOfBirth, this.Gender,
                                                                    this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);


            this.PersonID = PeopleR.Insertion(person);
            if (this.PersonID == 0) { return false; }
            return true;
        }

        private bool _modify()
        {

            PeopleR.stPeopleRepo person = new PeopleR.stPeopleRepo(this.PersonID, this.NationalNo, this.FirstName, this.SecondName,
                                                                    this.ThirdName, this.LastName, this.DateOfBirth, this.Gender,
                                                                   this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);


            return PeopleR.Update(person);

        }

        public static DataTable GetAllFewDetails()
        {
            return PeopleR.GetAllFewDetails();
        }

        public bool save()
        {
            switch (this.Mode)
            {

                case enMode.add:
                    if (_add())
                    {
                        this.Mode = enMode.update;
                        return true;
                    }
                    else return false;
                case enMode.update:
                    return _modify();
                default: return false;

            }
        }

        public static bool del(int id)
        {
            return PeopleR.Delete(id);


        }
        public static People GetPerson(int id)
        {
            PeopleR.stPeopleRepo p = PeopleR.GetPerson(id);
            return new People(p.PersonID, p.NationalNo, p.FirstName, p.SecondName, p.ThirdName, p.LastName, p.DateOfBirth, p.Gender,
                                                                   p.Address, p.Phone, p.Email, p.NationalityCountryID, p.ImagePath);
        }

        public static DataTable GetAll()
        {
            return PeopleR.GetAllPeople();
        }

        public static People GetPerson(string NationalNo)
        {
            PeopleR.stPeopleRepo p = PeopleR.GetPerson(NationalNo);
            return new People(p.PersonID, p.NationalNo, p.FirstName, p.SecondName, p.ThirdName, p.LastName, p.DateOfBirth, p.Gender,
                                                                   p.Address, p.Phone, p.Email, p.NationalityCountryID, p.ImagePath);
        }


    }

    internal class P
    {
         static void Main(string[] args) { }

    }
}
