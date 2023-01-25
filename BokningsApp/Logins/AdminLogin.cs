using BokningsApp.Models;

namespace BokningsApp.Logins
{
    public class AdminLogin
    {
        public static void AdminLogins(string username)
        {
            using (var db = new MyDBContext()) // READ
            {
                bool loop = true;
                while (loop)
                {
                    var list = db.Users;
                        int val;
                        Console.WriteLine("Välkommen in " + username);
                        Console.WriteLine("[1] För att kolla vem som bokat");
                        Console.WriteLine("[2] För att ta bort användare");
                        Console.WriteLine("[0] logga ut");
                    
                    if (int.TryParse(Console.ReadLine(), out val)) // gör det så man inte kan skriva bokstäver
                    {
                        switch (val)
                        {
                            case 1:
                                var datelist = db.Bookings;

                                foreach (var date in datelist)
                                {
                                    Console.WriteLine("Vecka: " + date.Vecka + " Dag: " + date.dag);
                                }
                                Console.WriteLine("Ditt hus har blivit bokat i dessa tillfällenä");
                                break;
                            case 2:

                                foreach (var u in list)
                                {
                                    Console.WriteLine($"{u.Id}  -  {u.Name}  -  {u.Username}  -  {u.Password}  -  {u.Mail}  -  {u.Age}  -  {u.Phone}  -  {u.IsAdmin}");

                                }
                                Console.WriteLine("[0] gå tillbaka");
                                Console.WriteLine("Vilken användare vill du ta bort? (Id)");
                                int Choise = int.Parse(Console.ReadLine());
                                var deleteuser = (from c in db.Users
                                                  where c.Id == Choise
                                                  select c).SingleOrDefault();
                                if (deleteuser != null)
                                {
                                    db.Users.Remove((User)deleteuser);
                                    db.SaveChanges();
                                }
                                break;
                            case 0:
                                Console.Clear();
                                Console.WriteLine("Du har loggat ut");
                                Console.WriteLine("Tryck vart som helst för att gå vidare");
                                loop = false;
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Du har angett fel inmatning tryck nånstans på tagentbordet för att gå vidare");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }
    }
}
