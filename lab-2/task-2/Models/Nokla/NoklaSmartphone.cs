using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.Nokla
{
    public class NoklaSmartphone : BaseDevice, ISmartphone
    {
        public NoklaSmartphone()
        {
            brand = "Nokla";
            price = 699.99m;
            specifications = "Snapdragon 888, 128GB Storage, 6.5\" AMOLED, Military Grade";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Smartphone - невмирущий телефон! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}