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
        public string ProductionDate { get; set; }
        public string ExpirationDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
