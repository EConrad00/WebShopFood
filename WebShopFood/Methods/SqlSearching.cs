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

        public static List<PurchaseHistory> PurchaseHistories()
        {
            string sql = "SELECT ProductName,SUM(Quantity) AS Amount FROM PurchaseHistories GROUP BY ProductName ORDER BY SUM(Quantity) DESC";
            string sql2 = "SELECT TOP(2) ProductName, SUM(Quantity), CostumerGender FROM PurchaseHistories GROUP BY CostumerGender,ProductName ORDER BY SUM(Quantity) DESC";
            //string sql3 = "WITH RankedProducts AS (SELECT ProductName AS Product, SUM(Quantity) AS Amount, CostumerGender AS Gender, ROW_NUMBER() OVER (PARTITION BY CostumerGender ORDER BY SUM(Quantity) DESC) AS Rank FROM PurchaseHistories GROUP BY CostumerGender, ProductName SELECT Product, Amount, Gender FROM RankedProducts WHERE Rank = 1;";
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
