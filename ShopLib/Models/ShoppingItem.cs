using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLib.Models
{
    public class ShoppingItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}. Name: {this.Name}. Price: {this.Price}. Quantity: {this.Quantity}.";
        }
    }
}
