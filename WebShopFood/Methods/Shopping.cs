using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopFood.Models;

namespace WebShopFood.Methods
{
    internal class Shopping
    {
        public static void Buying(Costumer userId, int productId)
        {
            using (var db = new WebShopFoodContext())
            {
                var shoppingItemsCheck = (from ShoppingItem in db.ShoppingItems
                                          where ShoppingItem.ShoppingCartId == userId.ShoppingCartId && ShoppingItem.ProductId == productId
                                          select ShoppingItem).ToList();

                if (shoppingItemsCheck.Count() == 0)
                {
                    Models.ShoppingItem shoppingItem = new Models.ShoppingItem()
                    {
                        Quantity = 1,
                        Price = db.Products.Where(x => x.Id == productId).Select(x => x.Cost).SingleOrDefault(),
                        ShoppingCartId = userId.ShoppingCartId,
                        ProductId = productId
                    };
                    db.ShoppingItems.Add(shoppingItem);
                    db.SaveChanges();
                }
                else
                {
                    shoppingItemsCheck[0].Quantity = shoppingItemsCheck[0].Quantity + 1;
                    db.SaveChanges();
                }
                Console.WriteLine($"Added one of {db.Products.Where(x => x.Id == productId).Select(x => x.Name).SingleOrDefault()} to your shoppingcart!");
                Console.ReadKey(true);
            }
        }
    }
}
