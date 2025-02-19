using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public abstract class Subscription : ISubscription
    {
        public abstract string Name
        {
            get;
        }
        public abstract decimal MonthlyFee
        {
            get;
        }
        public abstract int MinPeriod
        {
            get;
        }
        public abstract List<string> Channels
        {
            get;
        }

        public virtual void GetInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{Name}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Вартість: {MonthlyFee} грн/місяць");
            Console.WriteLine($"Мінімальний період: {MinPeriod} міс.");
            Console.WriteLine($"Канали: {string.Join(", ", Channels)}");
            Console.ResetColor();
        }
    }
}
