using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopFood.Models
{
    internal class ProductionAndExpirationDate
    {
        public int Id { get; set; }
        public string ProductionDate { get; set; } = DateTime.Now.ToString();
        public string ExpirationDate { get; set; } = DateTime.Now.AddDays(30).ToString();
        public virtual ICollection<Product> Products { get; set; }

    }
}
