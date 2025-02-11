using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Увага: Я використав стиль віруса для дісплея, тому ОБЕРЕЖНО ОЧІ!\n");
            Console.ForegroundColor = ConsoleColor.Black;

            try
            {
                DemonstrateVirusPrototype();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Сталася помилка: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.ResetColor();
        }

        private static void DemonstrateVirusPrototype()
        {
            Console.WriteLine("=== Створення оригінального сімейства вірусів ===\n");
            var ancestor = new Virus("Alpha-SuperMegaGigant", "COVID", 0.1, 100);
            var child1 = new Virus("Beta-Ultra", "COVID", 0.08, 50);
            var child2 = new Virus("Beta-Super", "COVID", 0.09, 45);
            var grandChild1 = new Virus("Gamma-Ultra", "COVID", 0.07, 20);
            var grandChild2 = new Virus("Gamma-Mega", "COVID", 0.075, 18);
            var grandChild3 = new Virus("Gamma-Super", "COVID", 0.085, 15);

            BuildFamilyTree(ancestor, child1, child2, grandChild1, grandChild2, grandChild3);

            Console.WriteLine("Оригінальне сімейство вірусів:");
            ancestor.PrintFamilyTree();

            DemonstrateCloning(ancestor);
        }

        private static void BuildFamilyTree(
            Virus ancestor,
            Virus child1,
            Virus child2,
            Virus grandChild1,
            Virus grandChild2,
            Virus grandChild3)
        {
            ancestor.AddChild(child1);
            ancestor.AddChild(child2);
            child1.AddChild(grandChild1);
            child1.AddChild(grandChild2);
            child2.AddChild(grandChild3);
        }

        private static void DemonstrateCloning(Virus ancestor)
        {
            Console.WriteLine("\n=== Клонування сімейства вірусів ===\n");
            var clonedFamily = (Virus)ancestor.Clone();
            Console.WriteLine("Клоноване сімейство вірусів:");
            clonedFamily.PrintFamilyTree();

            VerifyCloning(ancestor, clonedFamily);
        }

        private static void VerifyCloning(Virus original, Virus clone)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n=== Перевірка коректності клонування ===");
            Console.WriteLine($"Оригінал і клон - різні об'єкти: {!ReferenceEquals(original, clone)}");

            if (original.Children.Count > 0 && clone.Children.Count > 0)
            {
                Console.WriteLine($"Діти оригіналу і клону - різні об'єкти: " +
                                $"{!ReferenceEquals(original.Children[0], clone.Children[0])}\n");
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}