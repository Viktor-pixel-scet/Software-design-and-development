using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.IProne
{
    public class IProneLaptop : BaseDevice, ILaptop
    {
        public IProneLaptop()
        {
            brand = "IProne";
            price = 2499.99m;
            specifications = "Intel i9, 32GB RAM, 1TB SSD";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Laptop - стильний та потужний! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}