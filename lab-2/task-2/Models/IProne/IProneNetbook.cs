using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.IProne
{
    public class IProneNetbook : BaseDevice, INetbook
    {
        public IProneNetbook()
        {
            brand = "IProne";
            price = 999.99m;
            specifications = "M1 Chip, 8GB RAM, 256GB SSD, 11\" Display";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Netbook - компактний та потужний! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}