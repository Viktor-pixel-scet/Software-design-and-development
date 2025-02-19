using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.IProne
{
    public class IProneEBook : BaseDevice, IEBook
    {
        public IProneEBook()
        {
            brand = "IProne";
            price = 399.99m;
            specifications = "7\" E-ink Display, 32GB Storage, Waterproof";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] EBook - преміум читалка! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}