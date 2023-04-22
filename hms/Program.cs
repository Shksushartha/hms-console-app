using System.Data.SqlClient;

namespace hms;
class Program
{
    static bool toExit = false;
    static bool log = false;
    static bool aSigned = false;
    static bool pLog = false;
    static void Main(string[] args)
    {
        Admin a1 = new ();
        Doctor d1 = new Doctor();
        Patient p1 = new Patient();
        sConnection s1 = new();

        SqlConnection con = new SqlConnection("Data Source=localhost;initial catalog=hms;persist security info=True;user id=SA;password=Shakyadallu123.;MultipleActiveResultSets=True;");


        while (!toExit)
             {
            Console.Clear();
            Console.WriteLine("Hospital Management System");
            int c; 
            Console.WriteLine("1.  Admin");            
            Console.WriteLine("2.  Patient");            
            Console.WriteLine("3.  Exit");
            c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1:
                    Console.Clear();
                    string qstring = "select * from admin";
                    SqlCommand com = new SqlCommand(qstring, con);
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    List<Admin> adminList = new List<Admin>();
                    while (rdr.Read())
                    {
                        adminList.Add(new Admin()
                        {
                            name = rdr["name"].ToString(),
                            email = rdr["email"].ToString(),
                            password = rdr["password"].ToString()
                        });
                    }
                    con.Close();
                    log = a1.login(adminList);
                    while (log)
                    {
                        Console.Clear();
                        Console.WriteLine("1.  Add new doctors.");
                        Console.WriteLine("2.  View all doctors.");
                        Console.WriteLine("3.  Create new admin");
                        Console.WriteLine("4.  Logout");
                                
                        int aIC = Convert.ToInt32(Console.ReadLine());
                        switch (aIC)
                        {
                            case 1:
                                Console.Clear();
                                Doctor d = new Doctor();
                                d = d1.addDoctor();
                                string dinsertQ = "insert into doctor(name, email, faculty) values('"+d.name+"','"+d.email+"','"+d.faculty+"')";
                                con.Open();
                                SqlCommand doctorCom = new SqlCommand(dinsertQ, con);
                                doctorCom.ExecuteNonQuery();
                                con.Close();


                                break;
                                //}
                                
                            case 2:
                                Console.Clear();
                                string qAstring = "select * from doctor";
                                SqlCommand aCom = new SqlCommand(qAstring, con);
                                con.Open();
                                SqlDataReader aRdr = aCom.ExecuteReader();
                                List<Doctor> docList = new List<Doctor>();
                                while (aRdr.Read())
                                {
                                    docList.Add(new Doctor()
                                    {
                                        name = aRdr["name"].ToString(),
                                        email = aRdr["email"].ToString(),
                                        faculty = aRdr["faculty"].ToString()
                                    });
                                }
                                con.Close();
                                d1.viewDoc(docList);
                                break;
                                //}
                            case 3:                             
                                Console.Clear();
                                Admin a = new Admin();
                                bool flag;
                                flag = a1.setAdmin(a);
                                if (flag)
                                {
                                    string qString = "insert into admin(name,email,password) values('" + a.name + "','" + a.email + "','" + a.password + "')";
                                    con.Open();
                                    SqlCommand com1 = new SqlCommand(qString, con);
                                    com1.ExecuteNonQuery();
                                    con.Close();
                                    
                                }
                                break;


                            case 4:
                                log = false;
                                break;
                            default:
                                break;
                        }                       
                    }
                    break;
                           
                   
                

                case 2:
                    Console.Clear();
                    List<Patient> patList = new List<Patient>();
                    string pGetQuery = "select * from patient";
                    con.Open();
                    SqlCommand p1Com = new SqlCommand(pGetQuery, con);
                    SqlDataReader pRdr = p1Com.ExecuteReader();
                    while (pRdr.Read())
                    {
                        patList.Add(new Patient()
                        {
                            name = pRdr["name"].ToString(),
                            email = pRdr["email"].ToString(),
                            number = Convert.ToInt32(pRdr["contact"]),
                            password = pRdr["password"].ToString()
                        });
                    }
                    con.Close();
                    Console.WriteLine("1. Sign Up");
                    Console.WriteLine("2. Login");
                    int pC = Convert.ToInt32(Console.ReadLine());

                    switch (pC)
                    {
                        case 1:
                            Patient p = new Patient();
                            p1.addPatient(p);
                            string pInsertQ = "insert into patient(name, email, contact, password) values('"+p.name+"','"+p.email+"','"+p.number+"','"+p.password+"')";
                            SqlCommand pCom = new SqlCommand(pInsertQ, con);
                            con.Open();
                            pCom.ExecuteNonQuery();
                            con.Close();
                            break;
                        case 2:                            
                            pLog = p1.authenPatient(patList);
                            if (pLog)
                            {
                                Console.Clear();
                                Console.WriteLine("patient logged in");
                                Console.ReadLine();
                                string qAstring = "select * from doctor";
                                SqlCommand aCom = new SqlCommand(qAstring, con);
                                con.Open();
                                SqlDataReader aRdr = aCom.ExecuteReader();
                                List<Doctor> docList = new List<Doctor>();
                                while (aRdr.Read())
                                {
                                    docList.Add(new Doctor()
                                    {
                                        name = aRdr["name"].ToString(),
                                        email = aRdr["email"].ToString(),
                                        faculty = aRdr["faculty"].ToString()
                                    });
                                }
                                con.Close();
                                while (pLog)
                                {
                                    Console.Clear();                                    
                                    Console.WriteLine("1.  Make an appoinment.");
                                    Console.WriteLine("2.  View all the doctors.");
                                    Console.WriteLine("3.  View all the available doctors");
                                    Console.WriteLine("4.  Logout");
                                    int idC = Convert.ToInt32(Console.ReadLine());
                                    switch (idC)
                                    {
                                        case 1:
                                            Console.Clear();                                            
                                            d1.viewAvailableDoc(ref docList);                                            
                                            Console.WriteLine("");
                                            p1.appoint(ref docList);
                                            break;
                                        case 2:
                                            Console.Clear();                                           
                                            d1.viewDoc(docList);
                                            break;
                                        case 3:
                                            d1.viewAvailableDoc(ref docList);
                                            break;
                                        case 4:
                                            pLog = false;
                                            break;
                                    }
                                }
                            }
                           
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Incorrect credentials.");
                                Console.ReadLine();
                            }
                            break;
                    }                  
                    break;
                case 3:
                    toExit = true;
                    Console.Clear();
                    break;
                default:
                    break;
            }
        }
        
    }
}

