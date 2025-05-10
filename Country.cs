using System;
using System.Data;
using System.Net;
using System.Security.Policy;
using ContactsDataAccessLayar;

namespace ContactsBusinessLayar
{
    public class clsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public string CountryName { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }

        private clsCountry(int ID, string CountryName,string Code,string PhoneCode)
        {
            this.ID = ID;
            this.CountryName = CountryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;
            Mode = enMode.Update;
        }

        public clsCountry()
        {
            this.ID = -1;
            this.CountryName = "";
            this.Code = "";
            this.PhoneCode = "";
            Mode = enMode.AddNew;
        }

        private bool _AddNewCountry()
        {
            this.ID = clsCountryDataAccess.AddNewCountry(CountryName,Code,PhoneCode);
            return (this.ID != -1);
        }

        private bool _UpdateCountry()
        {
            //call DataAccess Layer 

            return clsCountryDataAccess.UpdateCountry(this.ID, this.CountryName, this.Code, this.PhoneCode);

        }


        public static clsCountry FindCountryInfoByID(int CountryID)
        {
            
            string CountryName = "";
            string Code = "";
            string PhoneCode = "";

            if (clsCountryDataAccess.GetCountryInfoByID(CountryID,ref CountryName,ref Code ,ref PhoneCode))
            {
                return new clsCountry(CountryID, CountryName, Code, PhoneCode); 
            }
            else
            {
                return null;
            }
        }

        public static clsCountry FindCountryInfoByName(string CountryName)
        {
            int CountryID = 0;
            string Code = "";
            string PhoneCode = "";

            if (clsCountryDataAccess.GetCountryInfoByName(ref CountryID, CountryName, ref Code, ref PhoneCode))
            {
                return new clsCountry(CountryID, CountryName, Code, PhoneCode);
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
                    if (_AddNewCountry())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdateCountry();
            }
            return false;
        }

        public static bool IsCountryExist(int CountryID) 
        {
            return clsCountryDataAccess.IsCountryExist(CountryID);
        }

        public static bool IsCountryExist(string CountryName)
        {
            return clsCountryDataAccess.IsCountryExist(CountryName);
        }

        public static DataTable GetAllContacts()
        {
            return clsCountryDataAccess.GetAllCountries();
        }

        public static bool DeleteCountry(int ID)
        {
            return clsCountryDataAccess.DeleteCountry(ID);
        }

        }
}
