using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.Kiaomi
{
    public class KiaomiSmartphone : BaseDevice, ISmartphone
    {
        public KiaomiSmartphone()
        {
            brand = "Kiaomi";
            price = 499.99m;
            specifications = "Snapdragon 8 Gen 1, 128GB Storage, 6.67\" AMOLED";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Smartphone - популярний і недорогий! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}