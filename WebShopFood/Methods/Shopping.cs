using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopFood.Models;
using WebShopFood.Windows;

namespace WebShopFood.Methods
{
    internal class Shopping
    {
        public static void Buying(Costumer userId, /*int productId*/ Product product)
        {
            using (var db = new WebShopFoodContext())
            {
                List<string> topText2 = new List<string> { $"{product.Description}", "Press X to add shoppingcart" };
                var windowTop2 = new Window($"{product.Name}", 1, (db.Products.Where(x => x.CategoryId == product.CategoryId).Count() + 4), topText2);
                windowTop2.Draw();
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.KeyChar == 'x')
                {
                    var shoppingItemsCheck = (from ShoppingItem in db.ShoppingItems
                                              where ShoppingItem.ShoppingCartId == userId.ShoppingCartId && ShoppingItem.ProductId == product.Id
                                              select ShoppingItem).ToList();

                    if (shoppingItemsCheck.Count() == 0)
                    {
                        Models.ShoppingItem shoppingItem = new Models.ShoppingItem()
                        {
                            Quantity = 1,
                            Price = db.Products.Where(x => x.Id == product.Id).Select(x => x.Cost).SingleOrDefault(),
                            ShoppingCartId = userId.ShoppingCartId,
                            ProductId = product.Id
                        };
                        db.ShoppingItems.Add(shoppingItem);
                        db.SaveChanges();
                    }
                    else
                    {
                        shoppingItemsCheck[0].Quantity = shoppingItemsCheck[0].Quantity + 1;
                        db.SaveChanges();
                    }
                    Console.WriteLine($"Added one of {db.Products.Where(x => x.Id == product.Id).Select(x => x.Name).SingleOrDefault()} to your shoppingcart!                            ");
                    Console.WriteLine("                                               ");
                    Console.ReadKey(true);
                }
                
            }
        }
    }
}
