using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.IProne
{
    public class IProneSmartphone : BaseDevice, ISmartphone
    {
        public IProneSmartphone()
        {
            brand = "IProne";
            price = 1299.99m;
            specifications = "A16 Bionic, 256GB Storage, 6.7\" OLED";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Smartphone - продуктивний та дорогий! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}