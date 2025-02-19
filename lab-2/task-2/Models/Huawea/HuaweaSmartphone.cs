using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.Huawea
{
    public class HuaweaSmartphone : BaseDevice, ISmartphone
    {
        public HuaweaSmartphone()
        {
            brand = "Huawea";
            price = 799.99m;
            specifications = "Kirin 9000, 256GB Storage, 6.8\" OLED, 108MP Camera";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Smartphone - фотофлагман! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}