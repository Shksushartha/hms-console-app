using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace hms
{
	class Admin
	{
		public string name;
		public string email;
		public string password;
		public static bool isLoggedIn;
        public Admin()
		{
			
		}

		public Admin(string n,string e, string p)
		{
			name = n;
			email = e;
			password = p;
		}

		public bool setAdmin(Admin a)
		{
				string n, e;
				
                Console.WriteLine("enter your name");
                n = Console.ReadLine();
                Console.WriteLine("enter your email");
                e = Console.ReadLine();
                string confirmp;
                string p;
                Console.WriteLine("enter your new password");
                p = Console.ReadLine();
                Console.WriteLine("confirm your new password");
                confirmp = Console.ReadLine();			

            if (p == confirmp)
                {
					
					a.password = confirmp;
					a.name = n;
					a.email = e;
					Console.Clear();
					Console.WriteLine("Signed Up!");
					Console.ReadLine();
					return true;
				}
				else
				{
					Console.WriteLine("Try again.");
					Console.ReadLine();
					
				return false;
					
				}
            
			
        }

		public void getAdmin()
		{
			Console.Clear();
			Console.WriteLine("Admin name: " + name);
			Console.WriteLine("Admin Email: "+ email);			
			Console.ReadLine();
		}

		public bool login(List<Admin> a)
		{
            Console.Clear();			
            Console.WriteLine("enter the admin's email");
            string cEmail = Console.ReadLine();
            Console.WriteLine("enter the admin's password");
            string cPass = Console.ReadLine();
            foreach (var Admin in a)
            {
                if (cEmail == Admin.email && cPass == Admin.password)
                {
                    return true;                  

                }

            }
            return false;
        }
	}
}

