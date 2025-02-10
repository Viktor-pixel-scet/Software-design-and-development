using System;
using System.Collections.Generic;
using System.Text;

public interface ISubscription
{
    string Name { 
        get; 
    }
    decimal MonthlyFee { 
        get; 
    }
    int MinPeriod { 
        get; 
    }
    List<string> Channels { 
        get; 
    }
    void GetInfo();
}

public abstract class Subscription : ISubscription
{
    public abstract string Name { 
        get; 
    }
    public abstract decimal MonthlyFee { 
        get; 
    }
    public abstract int MinPeriod { 
        get; 
    }
    public abstract List<string> Channels { 
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

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nЛасково просимо до сервісу підписок!");
        Console.ResetColor();

        Console.WriteLine("\nОберіть спосіб оформлення підписки: ");
        Console.WriteLine("1 - ВебСайт");
        Console.WriteLine("2 - Мобільний додаток");
        Console.WriteLine("3 - Дзвінок менеджера");
        Console.Write("\nВаш вибір: ");

        string choice = Console.ReadLine();

        Dictionary<string, SubscriptionFactory> factories = new Dictionary<string, SubscriptionFactory>
        {
            {
                "1", new WebSiteFactory()
            },

            {
                "2", new MobileAppFactory()
            },

            {
                "3", new ManagerCallFactory()
            }
        };

        if (factories.TryGetValue(choice, out SubscriptionFactory factory))
        {
            ISubscription subscription = factory.CreateSubscription();
            Console.ForegroundColor= ConsoleColor.Green;
            Console.ResetColor();
            subscription.GetInfo();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nНевірний вибір! Спробуйте будь-ласка ще раз...\n");
            Console.ResetColor();
        }
    }
}