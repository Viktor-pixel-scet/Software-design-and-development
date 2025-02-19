using ClassLibrary.Models;
using Interfaces;
using System;
using task_2;

namespace ClassLibrary.Models.Balaxy
{
    public class BalaxyEBook : BaseDevice, IEBook
    {
        public BalaxyEBook()
        {
            brand = "Balaxy";
            price = 299.99m;
            specifications = "6.8\" E-ink Display, 64GB Storage, Pen Support";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] EBook - багатофункціональний! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}
