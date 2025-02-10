using System;
using System.Collections.Generic;
using ClassLibrary;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var products = new List<Product>
            {
                new Product("Ноутбук", new Money(899, 99)),
                new Product("Смартфон", new Money(599, 49)),
                new Product("Навушники", new Money(89, 99)),
                new Product("Клавіатура", new Money(49, 99)),
                new Product("Миша", new Money(19, 99)),
                new Product("Монітор", new Money(199, 0)),
                new Product("Планшет", new Money(249, 99)),
                new Product("Розумний годинник", new Money(129, 50)),
                new Product("Зарядний пристрій", new Money(29, 99)),
                new Product("Зовнішній жорсткий диск", new Money(59, 0)),
                new Product("Флешка", new Money(15, 75)),
                new Product("Вебкамера", new Money(45, 49)),
                new Product("Павербанк", new Money(39, 99))
            };

            products[0].DecreasePrice(50); // Ноутбук
            products[2].DecreasePrice(10); // Навушники
            products[4].DecreasePrice(5);  // Миша

            Console.WriteLine("=================================");
            Console.WriteLine("     Зміни цін на продукти:");
            Console.WriteLine("=================================");
            foreach (var product in products)
            {
                Console.WriteLine($"Продукт: {product.Name}");
                Console.Write("Ціна після зменшення: ");
                product.Price.PrintAmount();
                Console.WriteLine("---------------------------------");
            }

            var reportingService = new ReportingService();
            var warehouses = new List<Warehouse>();

            foreach (var product in products)
            {
                var warehouse = new Warehouse(
                    product.Name,
                    "шт.",
                    product.Price,
                    new Random().Next(50, 200),
                    DateTime.Now
                );
                warehouses.Add(warehouse);
            }

            Console.WriteLine("=================================");
            Console.WriteLine("     Операції з товарами:");
            Console.WriteLine("=================================");

            foreach (var warehouse in warehouses)
            {
                Console.WriteLine($"Товар на складі: {warehouse.ProductName}");
                reportingService.RegisterIncome(warehouse, 50);
                reportingService.RegisterExpenditure(warehouse, 30);
                Console.WriteLine($"Прибуток: +50 шт., Витрата: -30 шт.");
                Console.WriteLine("---------------------------------");
            }

            Console.WriteLine("=================================");
            Console.WriteLine("     Звіт по інвентаризації:");
            Console.WriteLine("=================================");

            reportingService.GenerateInventoryReport(warehouses);

            Console.WriteLine("=================================");
        }
    }
}
