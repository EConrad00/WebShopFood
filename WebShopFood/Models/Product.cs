using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopFood.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public int Amount { get; set; }
        public bool Chosen { get; set; }
        public string ProductionDate { get; set; } = DateTime.Now.ToString();
        public string ExpirationDate { get; set; } = DateTime.Now.AddDays(30).ToString();
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
