using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public class PremiumSubscription : Subscription
    {
        public override string Name => "Преміум підписка";
        public override decimal MonthlyFee => 300.00m;
        public override int MinPeriod => 1;
        public override List<string> Channels => new List<string> { "4K Фільми", "Спорт HD", "Ексклюзивні шоу", "Netflix+" };
    }
}
