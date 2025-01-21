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
        
        }
        public static void UpdateProducer()
        {
        
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
                //db.SaveChanges();
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
    }
}
