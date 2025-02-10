using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
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

    public class DomesticSubscription : Subscription
    {
        public override string Name => "Домашня підписка";
        public override decimal MonthlyFee => 160.00m;
        public override int MinPeriod => 3;
        public override List<string> Channels => new List<string> { "Новини", "Спорт", "Фільми", "Музика" };
    }

    public class EducationalSubscription : Subscription
    {
        public override string Name => "Освітня підписка";
        public override decimal MonthlyFee => 100.00m;
        public override int MinPeriod => 6;
        public override List<string> Channels => new List<string> { "Наука", "Документальні", "Історія", "Техніка" };
    }

    public class PremiumSubscription : Subscription
    {
        public override string Name => "Преміум підписка";
        public override decimal MonthlyFee => 300.00m;
        public override int MinPeriod => 1;
        public override List<string> Channels => new List<string> { "4K Фільми", "Спорт HD", "Ексклюзивні шоу", "Netflix+" };
    }

    public abstract class SubscriptionFactory
    {
        public abstract ISubscription CreateSubscription();
    }

    public class WebSiteFactory : SubscriptionFactory
    {
        public override ISubscription CreateSubscription() => new DomesticSubscription();
    }

    public class MobileAppFactory : SubscriptionFactory
    {
        public override ISubscription CreateSubscription() => new EducationalSubscription();
    }

    public class ManagerCallFactory : SubscriptionFactory
    {
        public override ISubscription CreateSubscription() => new PremiumSubscription();
    }

}
