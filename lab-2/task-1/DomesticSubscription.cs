using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public class DomesticSubscription : Subscription
    {
        public override string Name => "Домашня підписка";
        public override decimal MonthlyFee => 160.00m;
        public override int MinPeriod => 3;
        public override List<string> Channels => new List<string> { "Новини", "Спорт", "Фільми", "Музика" };
    }
}
