using ClassLibrary.Models;
using Interfaces;
using System;
using task_2;

namespace ClassLibrary.Models.Balaxy
{
    public class BalaxyNetbook : BaseDevice, INetbook
    {
        public BalaxyNetbook()
        {
            brand = "Balaxy";
            price = 799.99m;
            specifications = "AMD Ryzen 5, 8GB RAM, 256GB SSD, 12\" Display";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Netbook - оптимальне рішення! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}