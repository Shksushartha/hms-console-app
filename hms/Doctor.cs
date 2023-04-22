using System;
using System.Data.SqlClient;

namespace hms
{
	class Doctor
	{
		
		public string name;
		public string email;
		public string faculty;
		public bool available;
		public int patientId;

        public Doctor()
		{
			available = true;
			patientId = 0;
		}
		public Doctor(string n, string e, string f)
		{
			name = n;
			email = e;
			faculty = f;
			available = true;
			patientId = 0;
		}

		public void viewDoc(List<Doctor> d)
		{
			Console.Clear();
            foreach (var Doctor in d)
            {
                Console.WriteLine(Doctor.name + " " + Doctor.email + " " + Doctor.faculty);

            }
            Console.ReadLine();
            Console.WriteLine("doctors viewed");
        }

        public void viewAvailableDoc(ref List<Doctor> d)
        {
            Console.Clear();
            Console.WriteLine("These are all the available doctors: ");
            foreach (var Doctor in d)
            {
                if (Doctor.available)
                    Console.WriteLine(Doctor.name + " " + Doctor.email + " " + Doctor.faculty);

            }
            Console.ReadLine();           
        }

        public Doctor addDoctor()
		{
            string dname;
            string demail;
            string dfaculty;           
            Console.Clear();
            Console.WriteLine("enter the doctor's name.");
            dname = Console.ReadLine();
            Console.WriteLine("enter the doctor's email");
            demail = Console.ReadLine();
            Console.WriteLine("enter the doctor's faculty");
            dfaculty = Console.ReadLine();
            Doctor d = new Doctor(dname,demail,dfaculty);
            return d;
        }
	}
}

