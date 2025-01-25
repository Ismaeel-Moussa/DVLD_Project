﻿using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsPerson
    {

        public enum enMode { AddNew = 0, Update = 1, }
        public enMode Mode = enMode.AddNew;    
        
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }
        }

        public clsCountry CountryInfo;

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 0; 
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            Mode = enMode.AddNew;
        }

        private clsPerson(int personID, string nationalNo, string firstName, string secondName,
                          string thirdName, string lastName, DateTime dateOfBirth,
                          byte gendor, string address, string phone, string email,
                          int nationalityCountryID, string imagePath)
        {
            this.PersonID = personID;
            this.NationalNo = nationalNo;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gendor = gendor;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = nationalityCountryID;
            this.ImagePath = imagePath;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);

            Mode = enMode.Update;
        }


        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName,
                                               this.ThirdName, this.LastName, this.DateOfBirth,
                                               this.Gendor, this.Address, this.Phone,
                                               this.Email, this.NationalityCountryID, this.ImagePath);
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName,
                                                       this.ThirdName, this.LastName, this.DateOfBirth,
                                                       this.Gendor, this.Address, this.Phone,
                                                       this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }


        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0; 
            string Address = "", Phone = "", Email = "", ImagePath = "";
            int NationalityCountryID = -1;

            if (clsPersonData.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,
                                                  ref LastName, ref DateOfBirth, ref Gendor, ref Address,
                                                  ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                     DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            string Address = "", Phone = "", Email = "", ImagePath = "";
            int NationalityCountryID = -1;


            if (clsPersonData.GetPersonInfoByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName,
                                                  ref LastName, ref DateOfBirth, ref Gendor, ref Address,
                                                  ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                     DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();


            }

            return false;
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static bool isPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }

        public static bool isPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }



    }
}

