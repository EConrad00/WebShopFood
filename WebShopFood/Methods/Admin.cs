using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebShopFood.Models;

namespace WebShopFood.Methods
{
    internal class Admin
    {
        public static void AddCategory()
        {
            using (var db = new WebShopFoodContext())
            {
                Console.WriteLine("Write name of category:");
                string categoryNew = Console.ReadLine();
                Models.Category category = new Models.Category()
                {
                    Name = categoryNew
                };
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }
        public static void DeleteCategory() 
        {
            using (var db = new WebShopFoodContext())
            {
                var categoryList = DisplayCategoryNames(db);
                foreach (var category in categoryList)
                {
                    Console.Write(category + " - ");
                }
                Console.WriteLine("\nWrite name of category to delete: ");
                //Console.WriteLine($"{producerList[0]} - {producerList[1]} - {producerList[2]} \nWrite name of producer to change:");
                string productCategory = Console.ReadLine();
                int productCategoryNew = FindCategoryId(db, productCategory);
                db.Remove(db.Categories.Single(c => c.Id == productCategoryNew));
                db.SaveChanges();
            }
        }

        public static void UpdateCategory() 
        {
            using (var db = new WebShopFoodContext())
            {
                var categoryList = DisplayCategoryNames(db);
                Console.WriteLine($"{categoryList[0]} - {categoryList[1]} - {categoryList[2]} \nWrite name of category to change:");
                string productCategory = Console.ReadLine();
                int productCategoryNew = FindCategoryId(db, productCategory);
                var category = db.Categories.First(c => c.Id == productCategoryNew);
                Console.WriteLine("Write new name for category:");
                category.Name = Console.ReadLine();
                db.SaveChanges();
            }
        }

        public static void AddProducer()
        {
            using (var db = new WebShopFoodContext())
            {
                Console.WriteLine("Write name of producer:");
                string producerNew = Console.ReadLine();
                Models.Producer producer = new Models.Producer()
                {
                    Name = producerNew
                };
                db.Producers.Add(producer);
                db.SaveChanges();
            }
        }
        public static void DeleteProducer()
        {
            using (var db = new WebShopFoodContext())
            {
                var producerList = DisplayProducerNames(db);
                foreach (var producer in producerList)
                {
                    Console.Write(producer + " - ");
                }
                //Console.WriteLine($"{producerList[0]} - {producerList[1]} - {producerList[2]} \nWrite name of producer to change:");
                Console.WriteLine("\nWrite name of producer to delete: ");
                string productProducer = Console.ReadLine();
                int productProducerNew = FindProducerId(db, productProducer);
                db.Remove(db.Producers.Single(p => p.Id == productProducerNew));
                db.SaveChanges();
            }
        }
        public static void UpdateProducer()
        {
            using (var db = new WebShopFoodContext())
            {
                var producerList = DisplayProducerNames(db);
                Console.WriteLine($"{producerList[0]} - {producerList[1]} - {producerList[2]} \nWrite name of producer to change:");
                string productProducer = Console.ReadLine();
                int productProducerNew = FindProducerId(db, productProducer);
                var producer = db.Producers.First(p => p.Id == productProducerNew);
                Console.WriteLine("Write new name for producer:");
                producer.Name = Console.ReadLine();
                db.SaveChanges();
            }
        }
        public static void AddProduct()
        {
            using (var db = new WebShopFoodContext())
            {
                Console.WriteLine("Write name of the product:");
                string productName = Console.ReadLine();
                Console.WriteLine("Write a description of the product:");
                string productDesc = Console.ReadLine();
                Console.WriteLine("Write the cost of the product:");
                int productCost = int.Parse(Console.ReadLine());
                Console.WriteLine("Write name of the producer:");
                string productProducer = Console.ReadLine();
                int productProducerNew = FindProducerId(db, productProducer);
                Console.WriteLine("Write name of the category:");
                string productCategory = Console.ReadLine();
                int productCategoryNew = FindCategoryId(db, productCategory);
                
                //string productProAndExpDate = DateTime.Now.ToString();
                Console.WriteLine("Write amount of the products:");
                int productAmount = int.Parse(Console.ReadLine());
                Models.Product product = new Models.Product()
                {
                    Name = productName,
                    Description = productDesc,
                    Cost = productCost,
                    ProducerId = productProducerNew,
                    CategoryId = productCategoryNew,
                    Amount = productAmount
                };
                db.Categories.Single(p => p.Id == productCategoryNew).Products.Add(product);
                db.Products.Add(product);
                db.SaveChanges();
            }

        }
        public static void DeleteProduct() 
        {
            using (var db = new WebShopFoodContext())
            {
                var productList = DisplayProductNames(db);
                foreach (var product in productList)
                {
                    Console.Write(product + " - ");
                }
                Console.WriteLine("\nWrite name of product to delete: ");
                //Console.WriteLine($"{producerList[0]} - {producerList[1]} - {producerList[2]} \nWrite name of producer to change:");
                string productToDelete = Console.ReadLine();
                int productToDeleteNew = FindProducerId(db, productToDelete);
                db.Remove(db.Products.Single(p => p.Id == productToDeleteNew));
                db.SaveChanges();
            }
        }

        public static void UpdateProduct()
        {
            using (var db = new WebShopFoodContext())
            {
                var productList = DisplayProductNames(db);
                foreach (var productGet in productList)
                {
                    Console.Write(productGet + " - ");
                }
                Console.WriteLine("\nWrite name of product to change: ");
                string product = Console.ReadLine();
                int productNew = FindProductId(db, product);
                var productChanged = db.Products.First(pro => pro.Id == productNew);
                var producerName = (from Producer in db.Producers
                                  where Producer.Id == productChanged.ProducerId
                                  select Producer.Name).FirstOrDefault();
                var categoryName = (from Category in db.Categories
                                  where Category.Id == productChanged.CategoryId
                                  select Category.Name).FirstOrDefault();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Press the corresponding number to change that part of the product.");
                    Console.WriteLine($"1: |{productChanged.Name}| 2: |Description {productChanged.Description}| 3: |Cost {productChanged.Cost}| 4: |Amount {productChanged.Amount}| 5: |Chosen {productChanged.Chosen}| 6: |{producerName}| 7: |{categoryName}| 8: To exit");
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.KeyChar)
                    {
                        case '1':
                            Console.WriteLine("Write new name for product:");
                            productChanged.Name = Console.ReadLine();
                            break;
                        case '2':
                            Console.WriteLine("Write new description for product:");
                            productChanged.Description = Console.ReadLine();
                            break;
                        case '3':
                            Console.WriteLine("Write new cost for product:");
                            productChanged.Cost = int.Parse(Console.ReadLine());
                            break;
                        case '4':
                            Console.WriteLine("Write new amount for product:");
                            productChanged.Amount = int.Parse(Console.ReadLine());
                            break;
                        case '5':
                            Console.WriteLine("Write y/n if product is chosen");
                            var tF = Console.ReadLine();
                            if (tF == "y")
                            {
                                productChanged.Chosen = true;
                            }
                            else if (tF == "n")
                            {
                                productChanged.Chosen = false;
                            }
                            break;
                        case '6':
                            var producerList = DisplayProducerNames(db);
                            foreach (var producer in producerList)
                            {
                                Console.Write(producer + " - ");
                            }
                            Console.WriteLine("Write name of the producer to change to:");
                            var producerNew = Console.ReadLine();
                            int productProducerNew = FindProducerId(db, producerNew);
                            productChanged.ProducerId = productProducerNew;
                            break;
                        case '7':
                            var categoryList = DisplayCategoryNames(db);
                            Console.WriteLine($"{categoryList[0]} - {categoryList[1]} - {categoryList[2]} \nWrite name of category to change:");
                            Console.WriteLine("Write name of the category to change to:");
                            var categoryNew = Console.ReadLine();
                            int productCategoryNew = FindCategoryId(db, categoryNew);
                            productChanged.CategoryId = productCategoryNew;
                            break;
                        case '8':
                            return;
                        case '9':
                            int categoryId = FindCategoryId(db, categoryName);
                            db.Categories.Single(p => p.Id == categoryId).Products.Add(productChanged);
                            break;

                    }
                    db.SaveChanges();    
                }
            }
        }
        public static void AddCostumer()
        {
            using (var db = new WebShopFoodContext())
            {
                Models.ShoppingCart shoppingCart = new Models.ShoppingCart(){};
                db.ShoppingCarts.Add(shoppingCart);
                db.SaveChanges();
                //var costumerList = DisplayCostumerNames(db);
                //foreach (var costumerGet in costumerList)
                //{
                //    Console.Write(costumerGet + " - ");
                //}
                Console.WriteLine("Write username of the costumer:");
                string costumerId = Console.ReadLine();
                Console.WriteLine("Write a password:");
                string costumerPassword = Console.ReadLine();
                Console.WriteLine("Write the name of the costumer:");
                string costumerName = Console.ReadLine();
                Console.WriteLine("Write the gender of the costumer:");
                string costumerGender = Console.ReadLine();
                Console.WriteLine("Write the age of the costumer:");
                int costumerAge = int.Parse(Console.ReadLine());
                Console.WriteLine("Write the email of the costumer:");
                string costumerEmail = Console.ReadLine();
                Console.WriteLine("Write the city of the costumer:");
                string costumerCity = Console.ReadLine();
                Console.WriteLine("Write the zipcode of the costumer:");
                string costumerZipcode = Console.ReadLine();
                Console.WriteLine("Write the country of the costumer:");
                string costumerCountry = Console.ReadLine();
                Console.WriteLine("Write the phonenumber of the costumer:");
                string costumerPhonenumber = Console.ReadLine();
                Console.WriteLine("Write y/n if the new user has admin privleges:");
                string yesNo = Console.ReadLine();
                bool adminPrivlege = false;
                if (yesNo == "y")
                {
                    adminPrivlege = true;
                }
                else 
                {
                    adminPrivlege = false;
                }
                Models.Costumer costumer = new Models.Costumer()
                {
                    Id =costumerId,
                    Name = costumerName,
                    Password = costumerPassword,
                    Gender = costumerGender,
                    Age = costumerAge,
                    Email = costumerEmail,
                    City = costumerCity,
                    ZipCode = costumerZipcode,
                    Country = costumerCountry,
                    Phonenumber = costumerPhonenumber,
                    Admin = adminPrivlege,
                    ShoppingCartId = shoppingCart.Id
                    
                };
                db.Costumers.Add(costumer);
                db.SaveChanges();
            }

        }

        public static void DeleteCostumer()
        {
            using (var db = new WebShopFoodContext())
            {
                var costumerList = DisplayCostumerNames(db);
                foreach (var costumer in costumerList)
                {
                    Console.Write(costumer + " - ");
                }
                Console.WriteLine("\nWrite name of costumer to delete: ");
                //Console.WriteLine($"{producerList[0]} - {producerList[1]} - {producerList[2]} \nWrite name of producer to change:");
                string costumerToDelete = Console.ReadLine();
                string costumerToDeleteNew = FindCostumerId(db, costumerToDelete);
                db.Remove(db.Costumers.Single(c => c.Id == costumerToDeleteNew));
                var shoppingcartIdToDelete = (from Costumer in db.Costumers
                                              where Costumer.Id == costumerToDeleteNew
                                              select Costumer.ShoppingCartId).SingleOrDefault();
                db.Remove(db.ShoppingCarts.Single(s => s.Id == shoppingcartIdToDelete));
                db.SaveChanges();
            }
        }

        public static void UpdateCostumer()
        {
            using (var db = new WebShopFoodContext())
            {
                var costumerList = DisplayCostumerNames(db);
                foreach (var costumerGet in costumerList)
                {
                    Console.Write(costumerGet + " - ");
                }
                Console.WriteLine("\nWrite name of user to change: ");
                string costumer = Console.ReadLine();
                string costumerNew = FindCostumerId(db, costumer);
                var costumerChanged = db.Costumers.First(c => c.Id == costumerNew);
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Press the corresponding number or letter to change that part of the users information.");
                    Console.WriteLine($"1: |{costumerChanged.Id}| 2: |Password {costumerChanged.Password}| 3: |Name {costumerChanged.Name}| 4: |Gender {costumerChanged.Gender}| 5: |Age {costumerChanged.Age}| 6: |Email {costumerChanged.Email}| 7: |City {costumerChanged.City}| 8: |Zipcode {costumerChanged.ZipCode}| 9: |Country {costumerChanged.Country}| A: |Admin {costumerChanged.Admin}| B: |Phonenumber {costumerChanged.Phonenumber}| R: To exit");
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.KeyChar)
                    {
                        case '1':
                            Console.WriteLine("Write new username for the user:");
                            costumerChanged.Id = Console.ReadLine();
                            break;
                        case '2':
                            Console.WriteLine("Write new password for the user:");
                            costumerChanged.Password = Console.ReadLine();
                            break;
                        case '3':
                            Console.WriteLine("Write new name for the user:");
                            costumerChanged.Name = Console.ReadLine();
                            break;
                        case '4':
                            Console.WriteLine("Write new gender for the user:");
                            costumerChanged.Gender = Console.ReadLine();
                            break;
                        case '5':
                            Console.WriteLine("Write new age for the user:");
                            costumerChanged.Age = int.Parse(Console.ReadLine());
                            break;
                        case '6':
                            Console.WriteLine("Write new email for the user:");
                            costumerChanged.Email = Console.ReadLine();
                            break;
                        case '7':
                            Console.WriteLine("Write new city for the user:");
                            costumerChanged.City = Console.ReadLine();
                            break;
                        case '8':
                            Console.WriteLine("Write new zipcode for the user:");
                            costumerChanged.ZipCode = Console.ReadLine();
                            break;
                        case '9':
                            Console.WriteLine("Write new country for the user:");
                            costumerChanged.Country = Console.ReadLine();
                            break;
                        case 'a':
                            Console.WriteLine("Write y/n if user is admin");
                            var tF = Console.ReadLine();
                            if (tF == "y")
                            {
                                costumerChanged.Admin = true;
                            }
                            else if (tF == "n")
                            {
                                costumerChanged.Admin = false;
                            }
                            break;
                        case 'b':
                            Console.WriteLine("Write new phonenumber for the user:");
                            costumerChanged.Phonenumber = Console.ReadLine();
                            break;
                        case 'r':
                            return;

                    }
                    db.SaveChanges();
                }
            }
        }


        public static int FindCategoryId(WebShopFoodContext db, string categoryName)
        {
            var categoryId = (from Category in db.Categories
                              where Category.Name == categoryName
                              select Category.Id).FirstOrDefault();
            return categoryId;
        }
        public static int FindProducerId(WebShopFoodContext db, string producerName)
        {
            var producerId = (from Producer in db.Producers
                              where Producer.Name == producerName
                              select Producer.Id).FirstOrDefault();
            return producerId;
        }
        public static int FindProductId(WebShopFoodContext db, string productName)
        {
            var productId = (from Product in db.Products
                              where Product.Name == productName
                              select Product.Id).FirstOrDefault();
            return productId;
        }

        public static string FindCostumerId(WebShopFoodContext db, string costumerName)
        {
            var costumerId = (from Costumer in db.Costumers
                             where Costumer.Name == costumerName
                             select Costumer.Id).FirstOrDefault();
            return costumerId;
        }
        public static List<string> DisplayCategoryNames(WebShopFoodContext db)
        {
            var categoryNames = (from Category in db.Categories
                              select Category.Name).ToList();
            return categoryNames;
        }
        public static List<string> DisplayProducerNames(WebShopFoodContext db)
        {
            var producerNames = (from Producer in db.Producers
                              select Producer.Name).ToList();
            return producerNames;
        }
        public static List<string> DisplayProductNames(WebShopFoodContext db)
        {
            var productNames = (from Product in db.Products
                                 select Product.Name).ToList();
            return productNames;
        }
        public static List<string> DisplayCostumerNames(WebShopFoodContext db)
        {
            var costumerNames = (from Costumer in db.Costumers
                                select Costumer.Name).ToList();
            return costumerNames;
        }

    }
}
