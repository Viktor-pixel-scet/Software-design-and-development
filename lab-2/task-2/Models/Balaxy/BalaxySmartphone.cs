using ClassLibrary.Models;
using Interfaces;
using System;
using task_2;

namespace ClassLibrary.Models.Balaxy
{
    public class BalaxySmartphone : BaseDevice, ISmartphone
    {
        public BalaxySmartphone()
        {
            brand = "Balaxy";
            price = 999.99m;
            specifications = "Snapdragon 8 Gen 2, 256GB Storage, 6.8\" AMOLED, 108MP Camera";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Smartphone - флагман з найкращою камерою! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}