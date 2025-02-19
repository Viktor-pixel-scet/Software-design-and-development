using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public class EducationalSubscription : Subscription
    {
        public override string Name => "Освітня підписка";
        public override decimal MonthlyFee => 100.00m;
        public override int MinPeriod => 6;
        public override List<string> Channels => new List<string> { "Наука", "Документальні", "Історія", "Техніка" };
    }
}
