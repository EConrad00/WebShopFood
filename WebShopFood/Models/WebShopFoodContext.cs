using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopFood.Models
{
    internal class WebShopFoodContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public DbSet<PurchaseHistory> purchaseHistories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:ecdatabas1.database.windows.net,1433;Initial Catalog=EcDatabase;Persist Security Info=False;User ID=SqlAdmin;Password=248Password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        // @"Server=.\SQLEXPRESS;Database=WebShopFood;Trusted_Connection=True;TrustServerCertificate=True"
        //Server=tcp:ecdatabas1.database.windows.net,1433;Initial Catalog=EcDatabase;Persist Security Info=False;User ID=SqlAdmin;Password=248Password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
    }
}
