using ClassLibrary.Factories;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace task_2
{
    public class TechStore
    {
        private readonly Dictionary<string, ITechFactory> factories;
        private readonly Dictionary<string, List<IDevice>> inventoryByBrand;
        private ITechFactory currentFactory;

        public TechStore()
        {
            factories = new Dictionary<string, ITechFactory>
            {
                { "IProne", new IProneFactory() },
                { "Kiaomi", new KiaomiFactory() },
                { "Nokla", new NoklaFactory() },
                { "Huawea", new HuaweaFactory() },
                { "Balaxy", new BalaxyFactory() }
            };

            inventoryByBrand = new Dictionary<string, List<IDevice>>();
            foreach (var brand in factories.Keys)
            {
                inventoryByBrand[brand] = new List<IDevice>();
            }
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                running = ShowMainMenu();
            }
        }

        private bool ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== TECH STORE MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. Переглянути продукти за брендом");
                Console.WriteLine("2. Показати статистику магазину");
                Console.WriteLine("3. Порівняти ціни між брендами");
                Console.WriteLine("4. Очистити інвентар");
                Console.WriteLine("0. Вийти");
                Console.WriteLine("===================================");
                Console.ResetColor();

                Console.Write("\nВиберіть опцію: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowBrandSelection();
                        return true;
                    case "2":
                        ShowStoreStatistics();
                        return true;
                    case "3":
                        ComparePrices();
                        return true;
                    case "4":
                        ClearAllInventory();
                        return true;
                    case "0":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nДякуємо за використання Tech Store Management System!\n");
                        return false;
                    default:
                        Console.WriteLine("\nНеправильний вибір. Спробуйте ще раз.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowBrandSelection()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Виберіть бренд ===");
                int i = 1;
                foreach (var brand in factories.Keys)
                {
                    Console.WriteLine($"{i}. {brand}");
                    i++;
                }
                Console.WriteLine("0. Повернутися назад");

                Console.Write("\nВаш вибір: ");
                string choice = Console.ReadLine();

                if (choice == "0")
                    break;

                if (int.TryParse(choice, out int brandChoice) &&
                    brandChoice > 0 &&
                    brandChoice <= factories.Count)
                {
                    var brand = factories.Keys.ElementAt(brandChoice - 1);
                    currentFactory = factories[brand];
                    ShowProducts(brand);
                    break;
                }

                Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                Console.ReadKey();
            }
        }

        private void ShowProducts(string brand)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"=== Продукти бренду {brand} ===");
            Console.ResetColor();

            try
            {
                var devices = new List<IDevice>();

                try { devices.Add(currentFactory.CreateLaptop()); } catch (NotImplementedException) { }
                try { devices.Add(currentFactory.CreateSmartphone()); } catch (NotImplementedException) { }
                try { devices.Add(currentFactory.CreateTablet()); } catch (NotImplementedException) { }
                try { devices.Add(currentFactory.CreateNetbook()); } catch (NotImplementedException) { }
                try { devices.Add(currentFactory.CreateEBook()); } catch (NotImplementedException) { }

                if (devices.Count == 0)
                {
                    Console.WriteLine("Жодних доступних продуктів цього бренду наразі немає.");
                }

                foreach (var device in devices)
                {
                    Console.WriteLine("\n----------------------------------------");
                    device.ShowInfo();
                    inventoryByBrand[brand].Add(device);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }

        private void ShowStoreStatistics()
        {
            Console.Clear();
            Console.WriteLine("=== Статистика магазину ===\n");

            foreach (var brand in inventoryByBrand.Keys)
            {
                var inventory = inventoryByBrand[brand];
                Console.WriteLine($"Бренд: {brand}");
                Console.WriteLine($"Кількість товарів: {inventory.Count}");
                Console.WriteLine($"Загальна вартість: ${inventory.Sum(d => d.Price):F2}");
                if (inventory.Any())
                    Console.WriteLine($"Середня ціна: ${inventory.Average(d => d.Price):F2}");
                Console.WriteLine();
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }

        private void ComparePrices()
        {
            Console.Clear();
            Console.WriteLine("=== Порівняння цін ===\n");

            Console.WriteLine("Ноутбуки:");
            CompareDeviceTypes(factory => factory.CreateLaptop());

            Console.WriteLine("\nСмартфони:");
            CompareDeviceTypes(factory => factory.CreateSmartphone());

            Console.WriteLine("\nПланшети:");
            CompareDeviceTypes(factory => factory.CreateTablet());

            Console.WriteLine("\nНетбуки:");
            CompareDeviceTypes(factory => factory.CreateNetbook());

            Console.WriteLine("\nЕлектронні книги:");
            CompareDeviceTypes(factory => factory.CreateEBook());

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }

        private void CompareDeviceTypes(Func<ITechFactory, IDevice> creator)
        {
            foreach (var factory in factories.Values)
            {
                try
                {
                    var device = creator(factory);
                    Console.WriteLine($"{factory.BrandName}: ${device.Price:F2}");
                }
                catch (NotImplementedException)
                {

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{factory.BrandName}: Помилка - {ex.Message}");
                }
            }
        }

        private void ClearAllInventory()
        {
            foreach (var inventory in inventoryByBrand.Values)
            {
                inventory.Clear();
            }
            Console.WriteLine("\nІнвентар очищено!");
            Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
    }
}