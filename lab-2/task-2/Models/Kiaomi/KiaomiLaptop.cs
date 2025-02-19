using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.Kiaomi
{
    public class KiaomiLaptop : BaseDevice, ILaptop
    {
        public KiaomiLaptop()
        {
            brand = "Kiaomi";
            price = 899.99m;
            specifications = "AMD Ryzen 7, 16GB RAM, 512GB SSD";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Laptop - бюджетний і надійний! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}