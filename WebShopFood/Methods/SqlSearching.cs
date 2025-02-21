using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopFood.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace WebShopFood.Methods
{
    internal class SqlSearching
    {
        static string connString = "data source=.\\SQLEXPRESS; initial catalog=WebShopFood; persist security info=True; Integrated Security=True;TrustServerCertificate=true;";

        public static List<PurchaseHistory> PurchaseHistories(string sql)
        {
            List<PurchaseHistory> purchases = new List<PurchaseHistory>();

            using(var connection = new SqlConnection(connString))
            {
                purchases = connection.Query<PurchaseHistory>(sql).ToList();
            }
            return purchases;
        }

        public static void FreeSearch(Costumer costumer, WebShopFoodContext db)
        {
            Console.WriteLine("Please write to search for a product by its name:");
            string nameToSearchBy = Console.ReadLine();
            string sqlSearch = $"Select Top(1) * From Products Where Name Like '%{nameToSearchBy}%'";
            List<Product> products = new List<Product>();
            using (var connection = new SqlConnection(connString))
            {
                products = connection.Query<Product>(sqlSearch).ToList();
            }

            Shopping.Buying(costumer, products[0]);
        }
    }
}
