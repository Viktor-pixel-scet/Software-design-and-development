using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.Kiaomi
{
    public class KiaomiNetbook : BaseDevice, INetbook
    {
        public KiaomiNetbook()
        {
            brand = "Kiaomi";
            price = 549.99m;
            specifications = "Intel Celeron, 4GB RAM, 128GB SSD, 11.6\" HD";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Netbook - доступний та практичний! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}