using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    public abstract class SupportHandler : ISupportHandler
    {
        protected ISupportHandler nextHandler;
        protected string handlerName;
        protected readonly ILogger Logger;
        protected Dictionary<string, string> subCategories;

        protected SupportHandler(string name, ILogger logger)
        {
            handlerName = name;
            Logger = logger;
            InitializeSubCategories();
        }

        protected abstract void InitializeSubCategories();

        public void SetNext(ISupportHandler handler)
        {
            nextHandler = handler;
        }

        public abstract void Handle(string request);

        protected void DisplaySubCategories()
        {
            Console.WriteLine($"\n=== {handlerName} ===");
            foreach (var category in subCategories)
            {
                Console.WriteLine($"{category.Key}. {category.Value}");
            }
            Console.WriteLine("0. Повернутися до головного меню");
        }

        public virtual void DisplayMenu()
        {
            Console.WriteLine($"\n=== {handlerName} ===");
            Console.WriteLine("1. Технічні проблеми");
            Console.WriteLine("2. Фінансові питання");
            Console.WriteLine("3. Загальні питання");
            Console.WriteLine("4. Скарги");
            Console.WriteLine("5. Проблеми з мобільним додатком");
            Console.WriteLine("6. Питання безпеки");
            Console.WriteLine("0. Вийти");
            Console.Write("Оберіть опцію: ");
        }

        protected void ShowProcessing()
        {
            Console.Write("Обробка запиту");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }
            Console.WriteLine();
        }

        protected void LogAndDisplayResponse(string category, string subcategory, string response)
        {
            ShowProcessing();
            Console.WriteLine("\n" + response);
            Logger.Log($"Оброблено запит: {category} - {subcategory}");

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
    }

    public class TechnicalSupportHandler : SupportHandler
    {
        public TechnicalSupportHandler(ILogger logger) : base("Технічна підтримка", logger) { }

        protected override void InitializeSubCategories()
        {
            subCategories = new Dictionary<string, string>
            {
                {
                    "1", "Проблеми з інтернетом"
                },
                {
                    "2", "Налаштування обладнання"
                },
                {
                    "3", "Оновлення програмного забезпечення"
                },
                {
                    "4", "Проблеми з електронною поштою"
                }
            };
        }

        public override void Handle(string request)
        {
            if (request == "1")
            {
                DisplaySubCategories();
                string subChoice = Console.ReadLine();

                if (subChoice == "0") return;

                if (subCategories.ContainsKey(subChoice))
                {
                    string response = subChoice switch
                    {
                        "1" => "Спеціаліст з мережевого обладнання зв'яжеться з вами протягом 1 години.",
                        "2" => "Інженер технічної підтримки зв'яжеться з вами протягом 2 годин.",
                        "3" => "Команда розробників розгляне ваш запит протягом 3 годин.",
                        "4" => "Спеціаліст служби підтримки зв'яжеться з вами протягом 30 хвилин.",
                        _ => "Очікуйте на відповідь протягом 2 годин."
                    };

                    LogAndDisplayResponse("Технічна підтримка", subCategories[subChoice], response);
                }
            }
            else if (nextHandler != null)
            {
                nextHandler.Handle(request);
            }
            else
            {
                Console.WriteLine("Не вдалося визначити відповідний відділ. Спробуйте ще раз.");
            }
        }
    }

    public class FinancialSupportHandler : SupportHandler
    {
        public FinancialSupportHandler(ILogger logger) : base("Фінансова підтримка", logger) { }

        protected override void InitializeSubCategories()
        {
            subCategories = new Dictionary<string, string>
            {
                {
                    "1", "Питання по рахунку"
                },
                {
                    "2", "Повернення коштів"
                },
                {
                    "3", "Проблеми з оплатою"
                },
                {
                    "4", "Питання по тарифам"
                }
            };
        }

        public override void Handle(string request)
        {
            if (request == "2")
            {
                DisplaySubCategories();
                string subChoice = Console.ReadLine();

                if (subChoice == "0") return;

                if (subCategories.ContainsKey(subChoice))
                {
                    string response = subChoice switch
                    {
                        "1" => "Фінансовий консультант зв'яжеться з вами протягом 4 годин.",
                        "2" => "Заявка на повернення коштів буде розглянута протягом 24 годин.",
                        "3" => "Спеціаліст платіжного відділу зв'яжеться з вами протягом 2 годин.",
                        "4" => "Менеджер по роботі з клієнтами зв'яжеться з вами протягом 3 годин.",
                        _ => "Очікуйте на відповідь протягом 24 годин."
                    };

                    LogAndDisplayResponse("Фінансова підтримка", subCategories[subChoice], response);
                }
            }
            else if (nextHandler != null)
            {
                nextHandler.Handle(request);
            }
        }
    }

    public class GeneralSupportHandler : SupportHandler
    {
        public GeneralSupportHandler(ILogger logger) : base("Загальна підтримка", logger) { }

        protected override void InitializeSubCategories()
        {
            subCategories = new Dictionary<string, string>
            {
                {
                    "1", "Інформація про послуги"
                },
                {
                    "2", "Загальні питання про компанію"
                },
                {
                    "3", "Партнерська програма"
                },
                {
                    "4", "Документація та інструкції"
                }
            };
        }

        public override void Handle(string request)
        {
            if (request == "3")
            {
                DisplaySubCategories();
                string subChoice = Console.ReadLine();

                if (subChoice == "0") return;

                if (subCategories.ContainsKey(subChoice))
                {
                    string response = subChoice switch
                    {
                        "1" => "Консультант зв'яжеться з вами протягом 4 годин.",
                        "2" => "Інформація буде надіслана на вашу електронну пошту протягом 2 годин.",
                        "3" => "Менеджер партнерської програми зв'яжеться з вами протягом 24 годин.",
                        "4" => "Посилання на документацію буде надіслано протягом 1 години.",
                        _ => "Очікуйте на відповідь протягом 48 годин."
                    };

                    LogAndDisplayResponse("Загальна підтримка", subCategories[subChoice], response);
                }
            }
            else if (nextHandler != null)
            {
                nextHandler.Handle(request);
            }
        }
    }

    public class ComplaintHandler : SupportHandler
    {
        private int complaintPriority;

        public ComplaintHandler(ILogger logger) : base("Обробка скарг", logger) { }

        protected override void InitializeSubCategories()
        {
            subCategories = new Dictionary<string, string>
            {
                {
                    "1", "Скарга на якість послуг"
                },
                {
                    "2", "Скарга на співробітника"
                },
                {
                    "3", "Скарга на технічні проблеми"
                },
                {
                    "4", "Інші скарги"
                }
            };
        }

        public override void Handle(string request)
        {
            if (request == "4")
            {
                DisplaySubCategories();
                string subChoice = Console.ReadLine();

                if (subChoice == "0") return;

                if (subCategories.ContainsKey(subChoice))
                {
                    Console.WriteLine("\nОцініть терміновість скарги від 1 до 3:");
                    Console.WriteLine("1 - Низька терміновість");
                    Console.WriteLine("2 - Середня терміновість");
                    Console.WriteLine("3 - Висока терміновість");

                    while (!int.TryParse(Console.ReadLine(), out complaintPriority) || complaintPriority < 1 || complaintPriority > 3)
                    {
                        Console.WriteLine("Будь ласка, введіть число від 1 до 3");
                    }

                    string response = (subChoice, complaintPriority) switch
                    {
                        ("1", 3) => "Керівник відділу якості зв'яжеться з вами протягом 1 години.",
                        ("1", 2) => "Спеціаліст відділу якості зв'яжеться з вами протягом 3 годин.",
                        ("1", 1) => "Ваша скарга буде розглянута протягом 24 годин.",
                        ("2", 3) => "Керівник HR відділу зв'яжеться з вами протягом 2 годин.",
                        ("2", 2) => "HR менеджер зв'яжеться з вами протягом 4 годин.",
                        ("2", 1) => "Ваша скарга буде розглянута HR відділом протягом 48 годин.",
                        _ => "Ваша скарга буде розглянута протягом 24 годин."
                    };

                    LogAndDisplayResponse("Скарги", $"{subCategories[subChoice]} (Пріоритет: {complaintPriority})", response);
                }
            }
            else if (nextHandler != null)
            {
                nextHandler.Handle(request);
            }
        }
    }

    public class MobileAppSupportHandler : SupportHandler
    {
        public MobileAppSupportHandler(ILogger logger) : base("Підтримка мобільного додатку", logger) { }

        protected override void InitializeSubCategories()
        {
            subCategories = new Dictionary<string, string>
            {
                {
                    "1", "Проблеми з входом"
                },
                {
                    "2", "Помилки в роботі додатку"
                },
                {
                    "3", "Оновлення додатку"
                },
                {
                    "4", "Синхронізація даних"
                }
            };
        }

        public override void Handle(string request)
        {
            if (request == "5")
            {
                DisplaySubCategories();
                string subChoice = Console.ReadLine();

                if (subChoice == "0") return;

                if (subCategories.ContainsKey(subChoice))
                {
                    string response = subChoice switch
                    {
                        "1" => "Спеціаліст з автентифікації зв'яжеться з вами протягом 1 години.",
                        "2" => "Команда розробки мобільного додатку розгляне ваш запит протягом 3 годин.",
                        "3" => "Інструкції з оновлення будуть надіслані протягом 30 хвилин.",
                        "4" => "Спеціаліст технічної підтримки зв'яжеться з вами протягом 2 годин.",
                        _ => "Очікуйте на відповідь протягом 3 годин."
                    };

                    LogAndDisplayResponse("Підтримка мобільного додатку", subCategories[subChoice], response);
                }
            }
            else if (nextHandler != null)
            {
                nextHandler.Handle(request);
            }
        }
    }

    public class SecuritySupportHandler : SupportHandler
    {
        public SecuritySupportHandler(ILogger logger) : base("Підтримка з питань безпеки", logger) { }

        protected override void InitializeSubCategories()
        {
            subCategories = new Dictionary<string, string>
            {
                {
                    "1", "Підозріла активність"
                },
                {
                    "2", "Відновлення доступу"
                },
                {
                    "3", "Налаштування безпеки"
                },
                {
                    "4", "Двофакторна автентифікація"
                }
            };
        }

        public override void Handle(string request)
        {
            if (request == "6")
            {
                DisplaySubCategories();
                string subChoice = Console.ReadLine();

                if (subChoice == "0") return;

                if (subCategories.ContainsKey(subChoice))
                {
                    string response = subChoice switch
                    {
                        "1" => "Команда безпеки перевірить ваш акаунт протягом 30 хвилин.",
                        "2" => "Спеціаліст служби безпеки зв'яжеться з вами протягом 1 години.",
                        "3" => "Інструкції з налаштування безпеки будуть надіслані протягом 2 годин.",
                        "4" => "Технічний спеціаліст допоможе вам налаштувати 2FA протягом 1 години.",
                        _ => "Очікуйте на відповідь від служби безпеки протягом 2 годин."
                    };

                    LogAndDisplayResponse("Підтримка з питань безпеки", subCategories[subChoice], response);
                }
            }
            else if (nextHandler != null)
            {
                nextHandler.Handle(request);
            }
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"\n[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
        }
    }

    public class SupportSystem
    {
        private readonly ISupportHandler firstHandler;
        private readonly ILogger Logger;

        public SupportSystem()
        {
            Logger = new ConsoleLogger();

            var technicalSupport = new TechnicalSupportHandler(Logger);
            var financialSupport = new FinancialSupportHandler(Logger);
            var generalSupport = new GeneralSupportHandler(Logger);
            var complaintHandler = new ComplaintHandler(Logger);
            var mobileAppSupport = new MobileAppSupportHandler(Logger);
            var securitySupport = new SecuritySupportHandler(Logger);

            technicalSupport.SetNext(financialSupport);
            financialSupport.SetNext(generalSupport);
            generalSupport.SetNext(complaintHandler);
            complaintHandler.SetNext(mobileAppSupport);
            mobileAppSupport.SetNext(securitySupport);

            firstHandler = technicalSupport;
        }

        public void ProcessRequest()
        {
            Console.WriteLine("Ласкаво просимо до системи підтримки користувачів!");

            while (true)
            {
                try
                {
                    firstHandler.DisplayMenu();
                    string choice = Console.ReadLine();

                    if (choice == "0")
                    {
                        Console.WriteLine("\nДякуємо за звернення! До побачення!");
                        break;
                    }

                    if (!new[] { "1", "2", "3", "4", "5", "6" }.Contains(choice))
                    {
                        Console.WriteLine("\nНевірний вибір. Будь ласка, оберіть число від 0 до 6.");
                        Thread.Sleep(1500);
                        continue;
                    }

                    firstHandler.Handle(choice);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nВиникла помилка: {ex.Message}");
                    Console.WriteLine("Спробуйте ще раз.");
                    Thread.Sleep(1500);
                }
            }
        }
    }
}