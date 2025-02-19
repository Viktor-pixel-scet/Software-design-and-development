using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.Huawea
{
    public class HuaweaLaptop : BaseDevice, ILaptop
    {
        public HuaweaLaptop()
        {
            brand = "Huawea";
            price = 1099.99m;
            specifications = "Kirin 9000, 16GB RAM, 1TB SSD, 14\" 2K Display";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Laptop - інноваційний та стильний! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}