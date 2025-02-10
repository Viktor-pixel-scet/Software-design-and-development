using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using ClassLibrary;

class Program
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