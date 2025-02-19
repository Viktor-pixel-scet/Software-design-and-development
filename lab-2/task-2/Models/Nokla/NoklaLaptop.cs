using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.Nokla
{
    public class NoklaLaptop : BaseDevice, ILaptop
    {
        public NoklaLaptop()
        {
            brand = "Nokla";
            price = 1299.99m;
            specifications = "Intel i7, 16GB RAM, 512GB SSD, Business Class";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Laptop - надійний бізнес-ноутбук! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}