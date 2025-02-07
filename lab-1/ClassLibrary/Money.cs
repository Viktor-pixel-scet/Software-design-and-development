using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Money
    {
        public int WholeAmount { get; set; } // Головна частина (долари, євро, гривні)
        public int FractionalAmount { get; set; } // Копійки, центи

        public Money(int wholeAmount, int fractionalAmount)
        {
            WholeAmount = wholeAmount;
            FractionalAmount = fractionalAmount;
        }

        public void PrintAmount()
        {
            Console.WriteLine($"{WholeAmount}.{FractionalAmount:D2}"); // Форматуємо копійки двома цифрами
        }

        public void SetWholeAmount(int amount)
        {
            WholeAmount = amount;
        }

        public void SetFractionalAmount(int amount)
        {
            FractionalAmount = amount;
        }
    }
}
