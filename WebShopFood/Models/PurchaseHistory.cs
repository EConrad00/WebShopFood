using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopFood.Models
{
    internal class PurchaseHistory
    {
        public int Id { get; set; }
        public string CostumerName { get; set; }
        public int CostumerAge { get; set; }
        public string CostumerGender { get; set; }
        public string CostumerCity { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public string ProductName { get; set; }
    }
}
