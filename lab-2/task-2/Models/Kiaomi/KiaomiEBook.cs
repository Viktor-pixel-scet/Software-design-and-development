using ClassLibrary.Models;
using Interfaces;
using System;

namespace ClassLibrary.Models.Kiaomi
{
    public class KiaomiEBook : BaseDevice, IEBook
    {
        public KiaomiEBook()
        {
            brand = "Kiaomi";
            price = 199.99m;
            specifications = "6\" E-ink Display, 16GB Storage, Built-in Light";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] EBook - бюджетна електронна книга! Ціна: ${price}\nХарактеристики: {specifications}");
    }
}
