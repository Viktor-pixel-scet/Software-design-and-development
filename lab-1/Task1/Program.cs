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
            // Створення списку продуктів з назвами та цінами
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

            // Зменшення ціни для кількох продуктів
            products[0].DecreasePrice(50); // Ноутбук
            products[2].DecreasePrice(10); // Навушники
            products[4].DecreasePrice(5);  // Миша

            // Виведення ціни продуктів після зменшення
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

            // Створення складів для кожного продукту
            var warehouses = new List<Warehouse>();
            foreach (var product in products)
            {
                var warehouse = new Warehouse(
                    product.Name,
                    "шт.",
                    product.Price,
                    new Random().Next(50, 200), // Випадкова кількість на складі
                    DateTime.Now
                );
                warehouses.Add(warehouse);
            }

            // Реєстрація прибутку та витрат для кожного складу
            Console.WriteLine("=================================");
            Console.WriteLine("     Операції з товарами:");
            Console.WriteLine("=================================");
            foreach (var warehouse in warehouses)
            {
                Console.WriteLine($"Товар на складі: {warehouse.ProductName}");
                Reporting.RegisterIncome(warehouse, 50);
                Reporting.RegisterExpenditure(warehouse, 30);
                Console.WriteLine($"Прибуток: +50 шт., Витрата: -30 шт.");
                Console.WriteLine("---------------------------------");
            }

            // Звіт про інвентаризацію
            Console.WriteLine("=================================");
            Console.WriteLine("     Звіт по інвентаризації:");
            Console.WriteLine("=================================");
            Reporting.InventoryReport(warehouses);
            Console.WriteLine("=================================");
        }
    }
}
