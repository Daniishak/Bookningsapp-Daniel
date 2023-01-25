
using BokningsApp.Logins;
using BokningsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BokningsApp
{
    public class Methods
    {
        public static void Välkommen()
        {
            while (true)
            { 
            Console.WriteLine("Har du ett konto ja/nej");
            string svar = Console.ReadLine().ToLower();
                switch (svar)
                {
                    case "ja":
                        LogIn();
                        break;
                    case "nej":
                        RegisterAccount();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Fel inmatning");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

        }
        public static void RegisterAccount()
        {
            Console.WriteLine("Skriv in ditt för och efternamn: ");
            string name = Console.ReadLine();
            Console.WriteLine("Skriv in din ålder: (siffror)");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Skriv in ditt mejl: ");
            var mail = Console.ReadLine();
            Console.WriteLine("Skriv in ditt telefonnummer: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Skriv in ett användarnamn");
            string username = Console.ReadLine();
            Console.WriteLine("Skriv in ditt lösenord");
            string password = Console.ReadLine();

            if (username.Contains("@"))
            {

                using (var db = new MyDBContext()) // CREATE / INSER
                {
                    var AdminUser = new User
                    {
                        Name = name,
                        Age = age,
                        Mail = mail,
                        Phone = phone,
                        Username = username,
                        Password = password,
                        IsAdmin = true
                    };

                    var Account = db.Users;
                    Account.Add(AdminUser);
                    db.SaveChanges();
                }
            }
            else
            {

                using (var db = new MyDBContext()) // CREATE / INSERT
                {

                    var User = new User
                    {
                        Name = name,
                        Age = age,
                        Mail = mail,
                        Phone = phone,
                        Username = username,
                        Password = password,
                        IsAdmin = false

                    };

                    var Account = db.Users;
                    Account.Add(User);
                    db.SaveChanges();
                }
            }
        }
        public static void LogIn()
        {
            Console.WriteLine("Skriv in ditt användarnamn");
            string username = Console.ReadLine();
            Console.WriteLine("Skriv in ditt lösenord");
            string password = Console.ReadLine();

            var db = new MyDBContext();
            var user = db.Users.Where(u => u.Username == username).FirstOrDefault();

            if (user.Password == password && user.IsAdmin == true)
            {
                AdminLogin.AdminLogins(user.Name);
            }
            else if (user.Password == password && user.IsAdmin != true)
            {
                KundLogin.UserLogins(username, user.Id);

            }
            else
            {
                Console.WriteLine("Fel lösenord eller användarnamn, försök igen");
            }
        }
    }
}
