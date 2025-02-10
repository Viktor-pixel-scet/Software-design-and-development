using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Money : IMoneyOperation
    {
        public int WholeAmount { get; set; }
        public int FractionalAmount { get; set; }

        public Money(int wholeAmount, int fractionalAmount)
        {
            WholeAmount = wholeAmount;
            FractionalAmount = fractionalAmount;
        }

        public void PrintAmount()
        {
            Console.WriteLine($"{WholeAmount}.{FractionalAmount:D2}");
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
