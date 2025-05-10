using System;
using System.Data;
using ContactsDataAccessLayar;




namespace ContactsBusinessLayar
{
    public class clsContact
    {
        public enum enMode {AddNew=0 , Update=1 }
        public enMode Mode = enMode.AddNew;
        public int ID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { set; get; }


        private clsContact(int iD, string firstName, string lastName,
            string email, string phone, string address, DateTime dateOfBirth, int countryId, string imagePath)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            CountryID = countryId;
            DateOfBirth = dateOfBirth;
            ImagePath = imagePath;
            Mode = enMode.Update;
        }


        public clsContact()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryID = -1;
            this.ImagePath = "";
            Mode = enMode.AddNew;
        }

        private bool _AddNewContact()
        {
            this.ID = clsContactDataAccess.AddNewContact(FirstName, LastName, Email, Phone,
                Address,DateOfBirth, CountryID, ImagePath);
            return (this.ID != -1);
        }

        private bool _UpdateContact()
        {
            return clsContactDataAccess.UpdateContact(ID, FirstName, LastName, Email, Phone,
                Address, DateOfBirth, CountryID, ImagePath);
        }

        public static clsContact Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = ""
            , Address = "", ImagePath = ""; int CountryID = -1;
            DateTime DateOfBirth = DateTime.Now;

            if (clsContactDataAccess.GetContactInfoByID(ID, ref FirstName, ref LastName,
                        ref Email, ref Phone, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath))
            {
                return new clsContact(ID, FirstName, LastName, Email,
                    Phone, Address, DateOfBirth, CountryID, ImagePath);
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
                    if (_AddNewContact())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdateContact();
            }
            return false;
        }

        public static bool DeleteContact(int ID)
        {
            return clsContactDataAccess.DeleteContact(ID);
        }

        public static DataTable GetAllContacts()
        {
            return clsContactDataAccess.GetAllContacts();
        }

        public static bool isContactExist(int ID)
        {
            return clsContactDataAccess.isContactExist(ID);
        }
}
}
