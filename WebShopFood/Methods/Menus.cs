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
                            //Menus.StartMenu(userId,ChosenGet());
                            while (true)
                            {
                                Menus.StartMenu(userId, ChosenGet());
                                ConsoleKeyInfo key = Console.ReadKey(true);
                                switch (key.KeyChar)
                                {
                                    case '1':
                                        Menus.StartMenu(userId, ChosenGet());
                                        break;
                                    case '2':
                                        break;
                                    case '3':
                                        Menus.ShoppingCartView(userId);
                                        break;
                                    case '4':
                                        if (userId.Admin == true)
                                        {
                                            AdminMenu(userId);
                                        }
                                        break;
                                    case 'a':
                                        var shoppingItemsCheck = (from ShoppingItem in db.ShoppingItems
                                                                  where ShoppingItem.ShoppingCartId == userId.ShoppingCartId && ShoppingItem.ProductId == ChosenGet()[0].Id
                                                                  select ShoppingItem).ToList();

                                        if (shoppingItemsCheck.Count() == 0)
                                        {
                                            Models.ShoppingItem shoppingItem = new Models.ShoppingItem()
                                            {
                                                Quantity = 1,
                                                Price = ChosenGet()[0].Cost,
                                                ShoppingCartId = userId.ShoppingCartId,
                                                ProductId = ChosenGet()[0].Id
                                            };
                                            db.ShoppingItems.Add(shoppingItem);
                                            db.SaveChanges();
                                        }
                                        else
                                        {
                                            shoppingItemsCheck[0].Quantity = shoppingItemsCheck[0].Quantity + 1;
                                            db.SaveChanges();
                                        }
                                        Console.WriteLine("Added one of offer 1 to your shoppingcart!");
                                        Console.ReadKey(true);
                                        break;
                                    case 'b':
                                        var shoppingItemsCheck2 = (from ShoppingItem in db.ShoppingItems
                                                                   where ShoppingItem.ShoppingCartId == userId.ShoppingCartId && ShoppingItem.ProductId == ChosenGet()[1].Id
                                                                   select ShoppingItem).ToList();

                                        if (shoppingItemsCheck2.Count() == 0)
                                        {
                                            Models.ShoppingItem shoppingItem = new Models.ShoppingItem()
                                            {
                                                Quantity = 1,
                                                Price = ChosenGet()[1].Cost,
                                                ShoppingCartId = userId.ShoppingCartId,
                                                ProductId = ChosenGet()[1].Id
                                            };
                                            db.ShoppingItems.Add(shoppingItem);
                                            db.SaveChanges();
                                        }
                                        else
                                        {
                                            shoppingItemsCheck2[0].Quantity = shoppingItemsCheck2[0].Quantity + 1;
                                            db.SaveChanges();
                                        }
                                        Console.WriteLine("Added one of offer 2 to your shoppingcart!");
                                        Console.ReadKey(true);
                                        break;
                                    case 'c':

                                        var shoppingItemsCheck3 = (from ShoppingItem in db.ShoppingItems
                                                                   where ShoppingItem.ShoppingCartId == userId.ShoppingCartId && ShoppingItem.ProductId == ChosenGet()[2].Id
                                                                   select ShoppingItem).ToList();

                                        if (shoppingItemsCheck3.Count() == 0)
                                        {
                                            Models.ShoppingItem shoppingItem = new Models.ShoppingItem()
                                            {
                                                Quantity = 1,
                                                Price = ChosenGet()[2].Cost,
                                                ShoppingCartId = userId.ShoppingCartId,
                                                ProductId = ChosenGet()[2].Id
                                            };
                                            db.ShoppingItems.Add(shoppingItem);
                                            db.SaveChanges();
                                        }
                                        else
                                        {
                                            shoppingItemsCheck3[0].Quantity = shoppingItemsCheck3[0].Quantity + 1;
                                            db.SaveChanges();
                                        }
                                        Console.WriteLine("Added one of offer 3 to your shoppingcart!");
                                        Console.ReadKey(true);
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
        }

        public static void AdminMenu(Costumer user)
        {

            while (true)
            {
                Console.Clear();
                List<string> topText2 = new List<string> { $"{user.Name}" };
                var windowTop2 = new Window("", 7, 0, topText2);
                windowTop2.Draw();
                List<string> topText = new List<string> { "# Food store #" };
                var windowTop = new Window("", 42, 0, topText);
                windowTop.Draw();
                List<string> topText3 = new List<string> { "1. Products", "2. Categories", "3. Users", "4. Producers", "5. Statistics", "Q is return" };
                var windowTop3 = new Window("Admin funktions", 7, 8, topText3);
                windowTop3.Draw();
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':

                        while (true)
                        {
                            Console.Clear();
                            List<string> topText4 = new List<string> { "1. Add new product", "2. Update existing product", "3. Delete existing product", "4. Return" };
                            var windowTop4 = new Window("Admin funktions", 7, 8, topText4);
                            windowTop4.Draw();
                            ConsoleKeyInfo key2 = Console.ReadKey(true);
                            switch (key2.KeyChar)
                            {
                                case '1':
                                    Methods.Admin.AddProduct();
                                    break;
                                case '2':
                                    Methods.Admin.UpdateProduct();
                                    break;
                                case '3':
                                    Methods.Admin.DeleteProduct();
                                    break;
                                case '4':
                                    return;
                            }
                        }
                    //break;
                    case '2':
                        while (true)
                        {
                            Console.Clear();
                            List<string> topText4 = new List<string> { "1. Add new category", "2. Update existing category", "3. Delete existing category", "4. Return" };
                            var windowTop4 = new Window("Admin funktions", 7, 8, topText4);
                            windowTop4.Draw();
                            ConsoleKeyInfo key2 = Console.ReadKey(true);
                            switch (key2.KeyChar)
                            {
                                case '1':
                                    Methods.Admin.AddCategory();
                                    break;
                                case '2':
                                    Methods.Admin.UpdateCategory();
                                    break;
                                case '3':
                                    Methods.Admin.DeleteCategory();
                                    break;
                                case '4':
                                    return;
                            }
                        }
                    //break;
                    case '3':
                        while (true)
                        {
                            Console.Clear();
                            List<string> topText4 = new List<string> { "1. Add new users", "2. Update existing users", "3. Delete existing users", "4. Return" };
                            var windowTop4 = new Window("Admin funktions", 7, 8, topText4);
                            windowTop4.Draw();
                            ConsoleKeyInfo key2 = Console.ReadKey(true);
                            switch (key2.KeyChar)
                            {
                                case '1':
                                    Methods.Admin.AddCostumer();
                                    break;
                                case '2':
                                    Methods.Admin.UpdateCostumer();
                                    break;
                                case '3':
                                    Methods.Admin.DeleteCostumer();
                                    break;
                                case '4':
                                    return;
                            }
                        }
                    //break;
                    case '4':
                        while (true)
                        {
                            Console.Clear();
                            List<string> topText4 = new List<string> { "1. Add new producer", "2. Update existing producer", "3. Delete existing producer", "4. Return" };
                            var windowTop4 = new Window("Admin funktions", 7, 8, topText4);
                            windowTop4.Draw();
                            ConsoleKeyInfo key2 = Console.ReadKey(true);
                            switch (key2.KeyChar)
                            {
                                case '1':
                                    Methods.Admin.AddProducer();
                                    break;
                                case '2':
                                    Methods.Admin.UpdateProducer();
                                    break;
                                case '3':
                                    Methods.Admin.DeleteProducer();
                                    break;
                                case '4':
                                    return;
                            }
                        }
                    //break;
                    case '5':
                        break;
                    case 'q':
                        Menus.StartMenu(user, ChosenGet());
                        return;
                }
            }
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

        public static void ShoppingCartView(Costumer costumer)
        {
            using (var db = new WebShopFoodContext())
            {
                Console.Clear();
                var shoppingItemsList = (from ShoppingItem in db.ShoppingItems
                                         where ShoppingItem.ShoppingCartId == costumer.ShoppingCartId
                                         select ShoppingItem).ToList();
                List<string> shoppingItemNamesNoDups = new();
                foreach (var item in shoppingItemsList)
                {
                    var shoppingItemNames = (from Product in db.Products
                                             where item.ProductId == Product.Id
                                             select Product.Name).SingleOrDefault();
                    shoppingItemNamesNoDups.Add(shoppingItemNames);
                }
                shoppingItemNamesNoDups = shoppingItemNamesNoDups.Distinct().ToList();
                int i = 0;
                Console.WriteLine("Your shoppingcart\n");
                foreach (var itemName in shoppingItemNamesNoDups)
                {
                    Console.WriteLine($"{itemName} Amount: {shoppingItemsList[i].Quantity}");
                    i++;

                }
                Console.WriteLine("|Press 1 to add or subtract from chosen products| Press 2 to remove a product completely form the shoppingcart| Press 3 to return  | Press x to checkout|");
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Write the name of the product you want to alter the amount of");
                        string productToAlterAmount = Console.ReadLine();
                        var productId = Methods.Admin.FindProductId(db, productToAlterAmount);
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine(productToAlterAmount);
                            Console.WriteLine("Press 1 to add| Press 2 to subtract| Press 3 to return");
                            ConsoleKeyInfo key2 = Console.ReadKey(true);
                            switch (key2.KeyChar)
                            {
                                case '1':
                                    var shoppingItemsCheck3 = (from ShoppingItem in db.ShoppingItems
                                                               where ShoppingItem.ShoppingCartId == costumer.ShoppingCartId && ShoppingItem.ProductId == productId
                                                               select ShoppingItem).ToList();
                                    shoppingItemsCheck3[0].Quantity = shoppingItemsCheck3[0].Quantity + 1;
                                    db.SaveChanges();
                                    break;
                                case '2':
                                    var shoppingItemsCheck4 = (from ShoppingItem in db.ShoppingItems
                                                               where ShoppingItem.ShoppingCartId == costumer.ShoppingCartId && ShoppingItem.ProductId == productId
                                                               select ShoppingItem).ToList();
                                    shoppingItemsCheck4[0].Quantity = shoppingItemsCheck4[0].Quantity - 1;
                                    db.SaveChanges();
                                    break;
                                case '3':
                                    return;
                            }
                        }
                        //break;
                    case '2':
                        Console.WriteLine("Write the name of the product you want to remove");
                        productToAlterAmount = Console.ReadLine();
                        productId = Methods.Admin.FindProductId(db, productToAlterAmount);

                        var shoppingItemsCheck5 = (from ShoppingItem in db.ShoppingItems
                                                   where ShoppingItem.ShoppingCartId == costumer.ShoppingCartId && ShoppingItem.ProductId == productId
                                                   select ShoppingItem).SingleOrDefault();
                        db.Remove(shoppingItemsCheck5);
                        db.SaveChanges();
                        break;
                    case '3':
                        break;
                    case 'r':
                        return;

                        //Console.ReadKey(true);
                }
            }
        }
    }
}
