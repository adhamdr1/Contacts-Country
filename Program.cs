using System;
using System.Data;
using System.Diagnostics.Contracts;
using ContactsBusinessLayar;

namespace ContactsConsole_app
{
    internal class Program
    {
        static void testFindContact(int ID)

        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                Console.WriteLine(Contact1.FirstName + " " + Contact1.LastName);
                Console.WriteLine(Contact1.Email);
                Console.WriteLine(Contact1.Phone);
                Console.WriteLine(Contact1.Address);
                Console.WriteLine(Contact1.DateOfBirth);
                Console.WriteLine(Contact1.CountryID);
                Console.WriteLine(Contact1.ImagePath);
            }
            else
            {
                Console.WriteLine("Contact [" + ID + "] Not found!");
            }
        }

        static void testAddNewContact()
        {
            clsContact Contact1 = new clsContact();
            Contact1.FirstName = "Fadi";
            Contact1.LastName = "Maher";
            Contact1.Email = "A@a.com";
            Contact1.Phone = "010010";
            Contact1.Address = "address1";
            Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";

            if (Contact1.Save())
            {

                Console.WriteLine("Contact Added Successfully with id=" + Contact1.ID);
            }

        }

        static void testUpdateContact(int ID)

        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                //update whatever info you want
                Contact1.FirstName = "Adham";
                Contact1.LastName = "Mohamed";
                Contact1.Email = "A2@Dr.com";
                Contact1.Phone = "2222";
                Contact1.Address = "222";
                Contact1.DateOfBirth = new DateTime(2004, 10, 23, 10, 30, 0);
                Contact1.CountryID = 1;
                Contact1.ImagePath = "D:\"";

                if (Contact1.Save())
                {

                    Console.WriteLine("Contact updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void testDeleteContact(int ID)
        {
            if (clsContact.isContactExist(ID))
            {
                if (clsContact.DeleteContact(ID))
                {
                    Console.WriteLine("Contact Delete Successfully ");
                }
                else
                {
                    Console.WriteLine("Contact Delete Failed ");
                }
            }
            else
            {
                Console.WriteLine("No , Contact is ID = " + ID+" Not Exist");
            }

            
        }

        static void ListContacts()
        {
            DataTable dataTable = clsContact.GetAllContacts();

            Console.WriteLine("Contacts Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]}, {row["FirstName"]} {row["LastName"]}");
            }
        }

        static void isContactExist(int ID)
        {
            if (clsContact.isContactExist(ID))
            {
                Console.WriteLine("Yes , Contact is Exist");
            }
            else
            {
                Console.WriteLine("No , Contact is Not Exist");
            }

        }

        //-----------------------------------------------------

        static void testFindCountryByID(int ID)

        {
            clsCountry Country1 = clsCountry.FindCountryInfoByID(ID);

            if (Country1 != null)
            {
                
                Console.WriteLine("Country ID : "+Country1.ID);
                Console.WriteLine("Country Name : " + Country1.CountryName);
            }
            else
            {
                Console.WriteLine("Country [" + ID + "] Not found!");
            }
        }

        static void testFindCountryByName(string CoountryName)

        {
            clsCountry Country1 = clsCountry.FindCountryInfoByName(CoountryName);

            if (Country1 != null)
            {

                Console.WriteLine("Country ID : " + Country1.ID);
                Console.WriteLine("Country Name : " + Country1.CountryName);
            }
            else
            {
                Console.WriteLine("Country [" + CoountryName + "] Not found!");
            }
        }

        static void IsCountryExist(int CountryID)
        {
            if (clsCountry.IsCountryExist(CountryID))
            {
                Console.WriteLine("Yes , Country is Exist");
            }
            else
            {
                Console.WriteLine("No , Country is Not Exist");
            }
        }

        static void IsCountryExist(string CoountryName)
        {
            if (clsCountry.IsCountryExist(CoountryName))
            {
                Console.WriteLine("Yes , Country is Exist");
            }
            else
            {
                Console.WriteLine("No , Country is Not Exist");
            }
        }

        static void testAddNewCountry()
        {
            clsCountry country1=new clsCountry();
            country1.CountryName = "Egypt";
            country1.Code = "EGY";
            country1.PhoneCode = "20";

            if (country1.Save())
            {

                Console.WriteLine("Contact Added Successfully with ID=" + country1.ID);
            }
        }

        static void testUpdateCountry(int ID)

        {
            clsCountry Country1 = clsCountry.FindCountryInfoByID(ID);

            if (Country1 != null)
            {
                //update whatever info you want
                Country1.CountryName = "United States";
                Country1.Code = "UK";
                Country1.PhoneCode = "111";

                if (Country1.Save())
                {

                    Console.WriteLine("Country updated Successfully");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void testDeleteCountry(int CountryID)
        {
            if (clsCountry.IsCountryExist(CountryID))
            {
                if (clsCountry.DeleteCountry(CountryID))
                {
                    Console.WriteLine("Country Delete Successfully ");
                }
                else
                {
                    Console.WriteLine("Country Delete Failed ");
                }
            }
            else
            {
                Console.WriteLine("No , Country is ID = " + CountryID + " Not Exist");
            }


        }

        static void ListCountrys()
        {
            DataTable dataTable = clsCountry.GetAllContacts();

            Console.WriteLine("Contacts Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["CountryID"]}, {row["CountryName"]}, {row["Code"]} ,{row["PhoneCode"]} ");
            }
        }

        static void Main(string[] args)
        {
            //testFindContact(1);
            //testAddNewContact();
            //testUpdateContact(1);
            //testDeleteContact(6);
            //ListContacts();
            //isContactExist(1);
            //isContactExist(100);

            //------------------------------

            //testFindCountryByID(1);
            //testFindCountryByName("Germany");
            //IsCountryExist(5);
            //IsCountryExist("Canada");
            //testAddNewCountry();
            //testUpdateCountry(1);
            //testDeleteCountry(2);
            ListCountrys();

            Console.ReadKey();
        }
    }
}
