using System;
using System.Collections.Generic;
using System.Linq;
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
                    Console.WriteLine($"1 : |{productChanged.Name}| 2 : |Description{productChanged.Description}| 3 : |Cost {productChanged.Cost}| 4 : |Amount {productChanged.Amount}| 5 : |Chosen {productChanged.Chosen}| 6 : |{producerName}| 7 : |{categoryName}| 8 : To exit");
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
                            int productCategoryNew = FindProducerId(db, categoryNew);
                            productChanged.CategoryId = productCategoryNew;
                            break;
                        case '8':
                            return;

                    }
                    db.SaveChanges();    
                }
            }
        }
        public static void AddCostumer()
        {

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
    }
}
