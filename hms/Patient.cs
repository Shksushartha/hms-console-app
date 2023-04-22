using System;
using System.Text.RegularExpressions;
using System.Data.SqlClient;


namespace hms
{
    class Patient
    {
        public int patientSn;
        public string name;
        public string email;
        public int number;
        public string password;
        public Patient()
        {
        }

        public Patient(string n, string e, int no, string p)
        {
            name = n;
            email = e;
            number = no;
            patientSn = 0;
            password = p;
        }

        public void addPatient(Patient p)
        {
            string pname;
            string pemail;
            int pnumber;
            Console.Clear();
            Console.WriteLine("enter the patient's name.");
            pname = Console.ReadLine();
            Console.WriteLine("enter the patient's email");
            pemail = Console.ReadLine();
            Console.WriteLine("enter the patient's contact number ");
            pnumber = Convert.ToInt32(Console.ReadLine());
            string confirmp;
            string pP;
            Console.WriteLine("enter your new password");
            pP = Console.ReadLine();
            Console.WriteLine("confirm your new password");
            confirmp = Console.ReadLine();

            if (pP == confirmp)
            {
                p.name = pname;
                p.email = pemail;
                p.number = pnumber;
                p.password = confirmp;
                Console.Clear();
                Console.WriteLine("Patient signed in.");
                Console.ReadLine();

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Try again.");
                Console.ReadLine();
               
            }
            

        }
        public void viewPat(List<Patient> p)
        {
            Console.Clear();
            foreach (var Patient in p)
            {
                Console.WriteLine(Patient.name + " " + Patient.email + " " + Patient.number + " " + Patient.password);

            }
            Console.ReadLine();

        }
        //private static bool IsValid(string email)
        //{
        //    string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

        //    return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        //}

        public bool authenPatient(List<Patient> p)
        {
            Console.Clear();
            bool emailCheck = false;           
            Console.WriteLine("enter patient's email");
            string pEmail = Console.ReadLine();
            Console.WriteLine("enter patient's password");
            string pPass = Console.ReadLine();
            foreach (var Patient in p)
            {
                if (pEmail == Patient.email && pPass == Patient.password)
                {
                    return true;                   
                    
                }             

            }
            return false;

        }

        public void appoint(ref List<Doctor> d)
        {
            Console.WriteLine("Enter the doctor's name you want to appoint.");
            string aDname = Console.ReadLine();            
            foreach (var Doctor in d)
            {
                if (aDname == Doctor.name)
                {
                    Doctor.available = false;
                    Console.WriteLine("");
                    Console.WriteLine(Doctor.name + " " + Doctor.email + " is appointed");
                    Console.ReadLine();
                }
                    

            }
        }


    }
}

