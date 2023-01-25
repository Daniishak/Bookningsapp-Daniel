using BokningsApp.Migrations;
using BokningsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BokningsApp.Logins
{
    public class KundLogin
    {
        enum MenuListAdmin
        {
            Måndag = 1,
            Tisdag,
            Onsdag,
            Torsdag,
            Fredag,
            Lördag,
            Logga_ut = 9
        }
        public static void UserLogins(string username, int userid)
        {
            using (var db = new MyDBContext()) // READ
            {
                bool loop = true;
                while (loop)
                {
                    var list = db.Users;
                    int val;
                    Console.WriteLine("Välkommen in " + username);
                    Console.WriteLine("[1] För att boka"); 
                    Console.WriteLine("[2] För att se vilka dagar som är bokade");
                    Console.WriteLine("[3] Logga ut");
                    
                    if (int.TryParse(Console.ReadLine(), out val)) // gör det så man inte kan skriva bokstäver
                    { 
                            switch (val)
                            {

                               case 1:
                                try
                                {
                                    Console.WriteLine("Hej! Välkommen till huset. ");
                                    Console.WriteLine("Vilken vecka vill du boka huset?");
                                    int week = int.Parse(Console.ReadLine());
                                    if (week < 1)
                                    {
                                        Console.WriteLine("fel inmatning, det är mellan vecka 1-52");
                                    }
                                    else if (week > 52)
                                    {
                                        Console.WriteLine("Fel inmatning, det är mellan vecka 1-52");
                                    }
                                    else
                                    {
                                        foreach (int i in Enum.GetValues(typeof(MenuListAdmin)))
                                        {
                                            Console.WriteLine($"{i}. {Enum.GetName(typeof(MenuListAdmin), i).Replace('_', ' ')}");
                                        }
                                        var Bookningar = new Booking
                                        {

                                        };
                                        while (week != Bookningar.Vecka)
                                        {

                                            int nr;
                                            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                                            {
                                                MenuListAdmin menu = (MenuListAdmin)99; // Default

                                                var Account = db.Bookings;
                                                menu = (MenuListAdmin)nr;
                                                Console.Clear();
                                                switch (menu)
                                                {
                                                    case MenuListAdmin.Måndag:
                                                        if (Bookningar.Vecka == week && Bookningar.dag == "Måndag")
                                                        {
                                                            Console.WriteLine("Det är redan bokat");
                                                        }
                                                        else
                                                        {
                                                            Bookningar = new Booking
                                                            {
                                                                UserId = userid,
                                                                Vecka = week,
                                                                dag = "Måndag",
                                                                bokade = "Måndag" + week
                                                            };

                                                            Console.WriteLine($"Du har bokat måndag, vecka {week} ");
                                                            Account = db.Bookings;
                                                            Account.Add(Bookningar);
                                                            db.SaveChanges();
                                                        }
                                                        //Console.WriteLine($"Du har bokat måndag, vecka {week} ");
                                                        Console.ReadKey();

                                                        break;
                                                    case MenuListAdmin.Tisdag:
                                                        Bookningar = new Booking
                                                        {
                                                            UserId = userid,
                                                            Vecka = week,
                                                            dag = "Tisdag",
                                                            bokade = "Tisdag" + week
                                                        };

                                                        Account = db.Bookings;
                                                        Account.Add(Bookningar);
                                                        db.SaveChanges();
                                                        Console.WriteLine($"Du har bokat tisdag, vecka {week} ");
                                                        Console.ReadKey();
                                                        break;
                                                    case MenuListAdmin.Onsdag:
                                                        Bookningar = new Booking
                                                        {
                                                            UserId = userid,
                                                            Vecka = week,
                                                            dag = "Onsdag",
                                                            bokade = "Onsdag" + week
                                                        };

                                                        Account = db.Bookings;
                                                        Account.Add(Bookningar);
                                                        db.SaveChanges();
                                                        Console.WriteLine($"Du har bokat onsdag, vecka {week} ");
                                                        Console.ReadKey();
                                                        break;
                                                    case MenuListAdmin.Torsdag:
                                                        Bookningar = new Booking
                                                        {
                                                            UserId = userid,
                                                            Vecka = week,
                                                            dag = "Torsdag",
                                                            bokade = "Torsdag" + week
                                                        };

                                                        Account = db.Bookings;
                                                        Account.Add(Bookningar);
                                                        db.SaveChanges();
                                                        Console.WriteLine($"Du har bokat torsdag, vecka {week} ");
                                                        Console.ReadKey();
                                                        break;
                                                    case MenuListAdmin.Fredag:
                                                        Bookningar = new Booking
                                                        {
                                                            UserId = userid,
                                                            Vecka = week,
                                                            dag = "Fredag",
                                                            bokade = "Fredag" + week
                                                        };

                                                        Account = db.Bookings;
                                                        Account.Add(Bookningar);
                                                        db.SaveChanges();
                                                        Console.WriteLine($"Du har bokat fredag, vecka {week} ");
                                                        Console.ReadKey();
                                                        break;
                                                    case MenuListAdmin.Lördag:
                                                        Bookningar = new Booking
                                                        {
                                                            UserId = userid,
                                                            Vecka = week,
                                                            dag = "Lördag",
                                                            bokade = "Lördag" + week
                                                        };

                                                        Account = db.Bookings;
                                                        Account.Add(Bookningar);
                                                        db.SaveChanges();
                                                        Console.WriteLine($"Du har bokat lördag, vecka {week} ");
                                                        Console.ReadKey();
                                                        break;

                                                        break;
                                                    case MenuListAdmin.Logga_ut:
                                                        loop = false;
                                                        Console.Clear();
                                                        Console.WriteLine("Du har precis loggat ut");
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                        break;
                                                }
                                                if (week == Bookningar.Vecka)
                                                {
                                                    Console.WriteLine("Det är redan bokat");
                                                }

                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Fel inmatning");
                                                    Console.ReadKey();
                                                    Console.Clear();

                                                }
                                            }
                                        }
                                    }
                                    
                                }
                                catch
                                {
                                    Console.WriteLine("Det är redan bokat testa en annan tid");
                                }
                                break;
                            case 2:
                                        var datelist = db.Bookings;

                                        foreach (var date in datelist)
                                        {
                                            Console.WriteLine("Vecka: " + date.Vecka + " Dag: " + date.dag);
                                        }
                                Console.WriteLine("Dessa datum är bokade och du kan därför inte boka dessa datum");
                                break;
                                case 3:
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
