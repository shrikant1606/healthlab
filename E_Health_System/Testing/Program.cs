using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BOL;
using DAL;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Laboratory laboratory = new Laboratory();
            //laboratory.Username = "abc";
            //laboratory.Password = "abc123";
            //laboratory.Laboratoryname = "ABC";
            //laboratory.Inchargename = "DEF";
            //laboratory.Address = "asdfg";
            //laboratory.City = "pune";
            //laboratory.State = "Maha";
            //laboratory.Pincode = 411057;
            //laboratory.Mobile = "8569898";
            //laboratory.Email = "asd@af.cc";
            //laboratory.Licence = "asd123sgas";

            //if(LaboratoryDAL.ValidateUser("abc", "abc123")==true)
            //    Console.WriteLine("User verified.......");
            //else
            //    Console.WriteLine("Invalid..");

            //Doctor doctor = new Doctor();
            //doctor = DoctorDAL.Get("ABC");
            //Console.WriteLine(doctor.Firstname);
            //Console.WriteLine(doctor.Lastname);
            //Console.WriteLine(doctor.Fees);
            //Console.ReadLine();

            DoctorDAL.Reset();

        }
    }
}
