using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopFood.Models
{
    internal class ShoppingCart
    {
        public int Id { get; set; }
        public int? TotalSum { get; set; }
        public virtual ICollection<ShoppingItem> ShoppingItems { get; set; }
    }
}
