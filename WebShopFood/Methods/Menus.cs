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
                    var userId = (from Costumer in db.Costumers
                                     where Costumer.Id == usernameAttempt
                                     select Costumer).FirstOrDefault();
                    //var chosenList = (from Product in db.Products
                    //                  where Product.Chosen == true
                    //                  select Product).ToList();
                    if (userId != null && userId.Id == usernameAttempt) 
                    {
                        Console.WriteLine("Please input your password:");
                        var userPasswordAttempt = Console.ReadLine();
                        if (userPasswordAttempt != null && userPasswordAttempt == userId.Password)
                        {
                            Console.WriteLine($"Welcome back {userId.Name}!");
                            Console.WriteLine("Press enter to continue to the home page!");
                            Console.ReadKey(true);
                            Menus.StartMenu(userId,ChosenGet());
                            while (true)
                            {

                                ConsoleKeyInfo key = Console.ReadKey(true);
                                switch (key.KeyChar)
                                {
                                    case '1':
                                        Menus.StartMenu(userId, ChosenGet());
                                        break;
                                    case '2':
                                        break;
                                    case '3':
                                        break;
                                    case '4':
                                        if (userId.Admin == true)
                                        {
                                            AdminMenu(userId);
                                        }
                                        break;
                                    case 'a':
                                        break;
                                    case 'b':
                                        break;
                                    case 'c':
                                        break;
                                    case 'q':
                                        Console.WriteLine($"We hope to see you soon again {userId.Name}");
                                        return;
                                } 
                            }
                            
                            //return;
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
        public static void StartMenu(Costumer user, List<Product> chosenProducts) 
        {
            Console.Clear();
            List<string> topText = new List<string> { "# Food store #" };
            var windowTop = new Window("", 42, 0, topText);
            windowTop.Draw();
            List<string> topText2 = new List<string> { $"{user.Name}" };
            var windowTop2 = new Window("", 7, 0, topText2);
            windowTop2.Draw();
            var product1 = chosenProducts[0];
            var product2 = chosenProducts[1];
            var product3 = chosenProducts[2];
            List<string> topText3 = new List<string> { $"{product1.Name}", $"{product1.Description}", $"Pris:{product1.Cost}", "Press A to add to shoppingcart" };
            var windowTop3 = new Window("Offer 1", 2, 8, topText3);
            windowTop3.Draw();
            List<string> topText4 = new List<string> { $"{product2.Name}", $"{product2.Description}", $"Pris:{product2.Cost}", "Press B to add to shoppingcart" };
            var windowTop4 = new Window("Offer 2", 37, 8, topText4);
            windowTop4.Draw();
            List<string> topText5 = new List<string> { $"{product3.Name}", $"{product3.Description}", $"Pris:{product3.Cost}", "Press C to add to shoppingcart" };
            var windowTop5 = new Window("Offer 3", 72, 8, topText5);
            windowTop5.Draw();
            if (user.Admin == true)
            {
                List<string> topText6 = new List<string> { "1. Start menu", "2. Shoppen", "3. Shoppingcart", "4. Admin page" };
                var windowTop6 = new Window("Menu options", 77, 0, topText6);
                windowTop6.Draw();

            }
            else 
            {
                List<string> topText6 = new List<string> { "1. Start menu", "2. Shoppen", "3. Shoppingcart" };
                var windowTop6 = new Window("Menu options", 77, 0, topText6);
                windowTop6.Draw();
            }

            //ConsoleKeyInfo key = Console.ReadKey(true);
            //switch (key.KeyChar)
            //{
            //    case '1':
            //        break;
            //    case '2':
            //        break;
            //    case '3':
            //        break;
            //    case '4':
            //        if (user.Admin == true) 
            //        {
            //            AdminMenu(user);
            //        }
            //        break;
            //    case 'A':
            //        break;
            //    case 'B':
            //        break;
            //    case 'C':
            //        break;
            //}
            //Console.ReadKey(true);
        }

        public static void AdminMenu(Costumer user)
        {
            Console.Clear();
            List<string> topText2 = new List<string> { $"{user.Name}" };
            var windowTop2 = new Window("", 7, 0, topText2);
            windowTop2.Draw();
            List<string> topText = new List<string> { "# Food store #" };
            var windowTop = new Window("", 42, 0, topText);
            windowTop.Draw();
            List<string> topText3 = new List<string> { "1. Products", "2. Categories", "3. Users", "4. Statistics" };
            var windowTop3 = new Window("Admin funktions", 7, 8, topText3);
            windowTop3.Draw();

        }

        public static List<Product> ChosenGet()
        {
            using (var db = new WebShopFoodContext())
            {
                var chosenList = (from Product in db.Products
                                  where Product.Chosen == true
                                  select Product).ToList();
                return chosenList;
            }
        }
    }
}
