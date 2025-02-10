using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class BaseDevice : IDevice
    {
        protected string brand;
        protected decimal price;
        protected string specifications;

        public string Brand => brand;
        public decimal Price => price;
        public string Specifications => specifications;

        public abstract void ShowInfo();
    }

    public class IProneLaptop : BaseDevice
    {
        public IProneLaptop()
        {
            brand = "IProne";
            price = 2499.99m;
            specifications = "Intel i9, 32GB RAM, 1TB SSD";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Laptop - стильний та потужний! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class IProneSmartphone : BaseDevice
    {
        public IProneSmartphone()
        {
            brand = "IProne";
            price = 1299.99m;
            specifications = "A16 Bionic, 256GB Storage, 6.7\" OLED";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Smartphone - продуктивний та дорогий! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class IProneTablet : BaseDevice
    {
        public IProneTablet()
        {
            brand = "IProne";
            price = 899.99m;
            specifications = "M1 Chip, 128GB Storage, 11\" Liquid Retina";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Tablet - високопродуктивний! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class IProneNetbook : BaseDevice
    {
        public IProneNetbook()
        {
            brand = "IProne";
            price = 999.99m;
            specifications = "M1 Chip, 8GB RAM, 256GB SSD, 11\" Display";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Netbook - компактний та потужний! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class IProneEBook : BaseDevice
    {
        public IProneEBook()
        {
            brand = "IProne";
            price = 399.99m;
            specifications = "7\" E-ink Display, 32GB Storage, Waterproof";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] EBook - преміум читалка! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class KiaomiLaptop : BaseDevice
    {
        public KiaomiLaptop()
        {
            brand = "Kiaomi";
            price = 899.99m;
            specifications = "AMD Ryzen 7, 16GB RAM, 512GB SSD";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Laptop - бюджетний і надійний! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class KiaomiSmartphone : BaseDevice
    {
        public KiaomiSmartphone()
        {
            brand = "Kiaomi";
            price = 499.99m;
            specifications = "Snapdragon 8 Gen 1, 128GB Storage, 6.67\" AMOLED";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Smartphone - популярний і недорогий! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class KiaomiNetbook : BaseDevice
    {
        public KiaomiNetbook()
        {
            brand = "Kiaomi";
            price = 549.99m;
            specifications = "Intel Celeron, 4GB RAM, 128GB SSD, 11.6\" HD";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Netbook - доступний та практичний! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class KiaomiEBook : BaseDevice
    {
        public KiaomiEBook()
        {
            brand = "Kiaomi";
            price = 199.99m;
            specifications = "6\" E-ink Display, 16GB Storage, Built-in Light";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] EBook - бюджетна електронна книга! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class NoklaLaptop : BaseDevice
    {
        public NoklaLaptop()
        {
            brand = "Nokla";
            price = 1299.99m;
            specifications = "Intel i7, 16GB RAM, 512GB SSD, Business Class";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Laptop - надійний бізнес-ноутбук! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class NoklaSmartphone : BaseDevice
    {
        public NoklaSmartphone()
        {
            brand = "Nokla";
            price = 699.99m;
            specifications = "Snapdragon 888, 128GB Storage, 6.5\" AMOLED, Military Grade";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Smartphone - невмирущий телефон! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class HuaweaLaptop : BaseDevice
    {
        public HuaweaLaptop()
        {
            brand = "Huawea";
            price = 1099.99m;
            specifications = "Kirin 9000, 16GB RAM, 1TB SSD, 14\" 2K Display";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Laptop - інноваційний та стильний! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class HuaweaSmartphone : BaseDevice
    {
        public HuaweaSmartphone()
        {
            brand = "Huawea";
            price = 799.99m;
            specifications = "Kirin 9000, 256GB Storage, 6.8\" OLED, 108MP Camera";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Smartphone - фотофлагман! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class BalaxyLaptop : BaseDevice
    {
        public BalaxyLaptop()
        {
            brand = "Balaxy";
            price = 1799.99m;
            specifications = "AMD Ryzen 9, 32GB RAM, 1TB SSD, RTX 3080";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Laptop - ігровий монстр! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class BalaxyNetbook : BaseDevice
    {
        public BalaxyNetbook()
        {
            brand = "Balaxy";
            price = 799.99m;
            specifications = "AMD Ryzen 5, 8GB RAM, 256GB SSD, 12\" Display";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Netbook - оптимальне рішення! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class BalaxyEBook : BaseDevice
    {
        public BalaxyEBook()
        {
            brand = "Balaxy";
            price = 299.99m;
            specifications = "6.8\" E-ink Display, 64GB Storage, Pen Support";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] EBook - багатофункціональний! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class BalaxySmartphone : BaseDevice
    {
        public BalaxySmartphone()
        {
            brand = "Balaxy";
            price = 999.99m;
            specifications = "Snapdragon 8 Gen 2, 256GB Storage, 6.8\" AMOLED, 108MP Camera";
        }

        public override void ShowInfo() =>
            Console.WriteLine($"[{brand}] Smartphone - флагман з найкращою камерою! Ціна: ${price}\nХарактеристики: {specifications}");
    }

    public class IProneFactory : ITechFactory
    {
        public string BrandName => "IProne";

        public IDevice CreateLaptop() => new IProneLaptop();
        public IDevice CreateSmartphone() => new IProneSmartphone();
        public IDevice CreateTablet() => new IProneTablet();
        public IDevice CreateNetbook() => new IProneNetbook();
        public IDevice CreateEBook() => new IProneEBook();
        public IDevice CreateSmartwatch() => throw new NotImplementedException();
        public IDevice CreateTV() => throw new NotImplementedException();
        public IDevice CreateSpeaker() => throw new NotImplementedException();
        public IDevice CreateCamera() => throw new NotImplementedException();
        public IDevice CreateAccessory() => throw new NotImplementedException();
    }

    public class KiaomiFactory : ITechFactory
    {
        public string BrandName => "Kiaomi";

        public IDevice CreateLaptop() => new KiaomiLaptop();
        public IDevice CreateSmartphone() => new KiaomiSmartphone();
        public IDevice CreateNetbook() => new KiaomiNetbook();
        public IDevice CreateEBook() => new KiaomiEBook();
        public IDevice CreateTablet() => throw new NotImplementedException();
        public IDevice CreateSmartwatch() => throw new NotImplementedException();
        public IDevice CreateTV() => throw new NotImplementedException();
        public IDevice CreateSpeaker() => throw new NotImplementedException();
        public IDevice CreateCamera() => throw new NotImplementedException();
        public IDevice CreateAccessory() => throw new NotImplementedException();
    }

    public class NoklaFactory : ITechFactory
    {
        public string BrandName => "Nokla";

        public IDevice CreateLaptop() => new NoklaLaptop();
        public IDevice CreateSmartphone() => new NoklaSmartphone();
        public IDevice CreateEBook() => throw new NotImplementedException();
        public IDevice CreateNetbook() => throw new NotImplementedException();
        public IDevice CreateTablet() => throw new NotImplementedException();
        public IDevice CreateSmartwatch() => throw new NotImplementedException();
        public IDevice CreateTV() => throw new NotImplementedException();
        public IDevice CreateSpeaker() => throw new NotImplementedException();
        public IDevice CreateCamera() => throw new NotImplementedException();
        public IDevice CreateAccessory() => throw new NotImplementedException();
    }

    public class HuaweaFactory : ITechFactory
    {
        public string BrandName => "Huawea";

        public IDevice CreateLaptop() => new HuaweaLaptop();
        public IDevice CreateSmartphone() => new HuaweaSmartphone();
        public IDevice CreateEBook() => throw new NotImplementedException();
        public IDevice CreateNetbook() => throw new NotImplementedException();
        public IDevice CreateTablet() => throw new NotImplementedException();
        public IDevice CreateSmartwatch() => throw new NotImplementedException();
        public IDevice CreateTV() => throw new NotImplementedException();
        public IDevice CreateSpeaker() => throw new NotImplementedException();
        public IDevice CreateCamera() => throw new NotImplementedException();
        public IDevice CreateAccessory() => throw new NotImplementedException();
    }

    public class BalaxyFactory : ITechFactory
    {
        public string BrandName => "Balaxy";

        public IDevice CreateLaptop() => new BalaxyLaptop();
        public IDevice CreateSmartphone() => new BalaxySmartphone();
        public IDevice CreateNetbook() => new BalaxyNetbook();
        public IDevice CreateEBook() => new BalaxyEBook();
        public IDevice CreateTablet() => throw new NotImplementedException();
        public IDevice CreateSmartwatch() => throw new NotImplementedException();
        public IDevice CreateTV() => throw new NotImplementedException();
        public IDevice CreateSpeaker() => throw new NotImplementedException();
        public IDevice CreateCamera() => throw new NotImplementedException();
        public IDevice CreateAccessory() => throw new NotImplementedException();
    }

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
                var devices = new List<IDevice>
                {
                    currentFactory.CreateLaptop(),
                    currentFactory.CreateSmartphone()
                };

                foreach (var device in devices.Where(d => d != null))
                {
                    Console.WriteLine("\n----------------------------------------");
                    device.ShowInfo();
                    inventoryByBrand[brand].Add(device);
                }
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Деякі продукти ще не реалізовані.");
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
            foreach (var factory in factories.Values)
            {
                try
                {
                    var laptop = factory.CreateLaptop();
                    Console.WriteLine($"{factory.BrandName}: ${laptop.Price:F2}");
                }
                catch { }
            }

            Console.WriteLine("\nСмартфони:");
            foreach (var factory in factories.Values)
            {
                try
                {
                    var phone = factory.CreateSmartphone();
                    Console.WriteLine($"{factory.BrandName}: ${phone.Price:F2}");
                }
                catch { }
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
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