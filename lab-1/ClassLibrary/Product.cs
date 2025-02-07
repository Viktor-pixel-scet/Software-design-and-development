using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Product
    {
        public string Name { get; set; }
        public Money Price { get; set; }

        public Product(string name, Money price)
        {
            Name = name;
            Price = price;
        }

        public void DecreasePrice(int amount)
        {
            int newWholeAmount = Price.WholeAmount - amount;
            if (newWholeAmount < 0) newWholeAmount = 0;
            Price.SetWholeAmount(newWholeAmount);
        }
    }
}
