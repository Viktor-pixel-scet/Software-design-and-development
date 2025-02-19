using ClassLibrary.Models;
using Interfaces;
using System;
using task_2;

namespace ClassLibrary.Models.Balaxy
{
    public class BalaxyLaptop : BaseDevice, ILaptop
    {
        public BalaxyLaptop()
        {
            brand = "Balaxy";
            price = 1799.99m;
            specifications = "AMD Ryzen 9, 32GB RAM, 1TB SSD, RTX 3080";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Laptop - ігровий монстр! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}