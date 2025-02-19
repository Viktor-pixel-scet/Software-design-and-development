using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.IProne
{
    public class IProneTablet : BaseDevice, ITablet
    {
        public IProneTablet()
        {
            brand = "IProne";
            price = 899.99m;
            specifications = "M1 Chip, 128GB Storage, 11\" Liquid Retina";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Tablet - високопродуктивний! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}