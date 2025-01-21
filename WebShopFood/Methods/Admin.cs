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
                Console.WriteLine("\nWrite name of producer to delete: ");
                //Console.WriteLine($"{producerList[0]} - {producerList[1]} - {producerList[2]} \nWrite name of producer to change:");
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
        public static void AddCostumer()
        {

        }

        public static void AddProductionAndExpirationDate() 
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
    }
}
