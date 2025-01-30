using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopFood.Models;
using WebShopFood.Windows;

namespace WebShopFood.Methods
{
    internal class Menus
    {
        public static void Login()
        {
            using (var db = new WebShopFoodContext())
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Please input your username:");
                    var usernameAttempt = Console.ReadLine();
                    //foreach (var costumer in db.Costumers) 
                    //{

                    //}
                    var userId = (from Costumer in db.Costumers
                                     where Costumer.Id == usernameAttempt
                                     select Costumer).FirstOrDefault();
                    if (userId != null && userId.Id == usernameAttempt) 
                    {
                        Console.WriteLine("Please input your password:");
                        var userPasswordAttempt = Console.ReadLine();
                        if (userPasswordAttempt != null && userPasswordAttempt == userId.Password)
                        {
                            Console.WriteLine($"Welcome back {userId.Name}!");
                            Console.ReadKey(true);
                            Menus.StartMenu(userId);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect password, press any button to try again");
                            Console.ReadKey(true);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect username, press any button to try again");
                        Console.ReadKey(true);
                    }
                }

            }
        }
        public static void StartMenu(Costumer user) 
        {
            Console.Clear();
            List<string> topText = new List<string> { "# Food store #" };
            var windowTop = new Window("", 25, 0, topText);
            windowTop.Draw();
            List<string> topText2 = new List<string> { $"{user.Name}" };
            var windowTop2 = new Window("", 2, 0, topText2);
            windowTop2.Draw();
            Console.ReadKey(true);
        }
    }
}
