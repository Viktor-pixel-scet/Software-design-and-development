using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task_4
{
    public class SmartTextReader : ITextReader
    {
        public virtual char[][] ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл не знайдено: {filePath}");
            }

            var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            var result = new char[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();
            }

            return result;
        }
    }

    public abstract class TextReaderProxy : ITextReader
    {
        protected readonly ITextReader Reader;

        protected TextReaderProxy(ITextReader reader)
        {
            Reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        public abstract char[][] ReadFile(string filePath);
    }
    public class SmartTextChecker : TextReaderProxy
    {
        private readonly ILogger Logger;

        public SmartTextChecker(ITextReader reader, ILogger logger = null) : base(reader)
        {
            Logger = logger ?? new ConsoleLogger();
        }

        public override char[][] ReadFile(string filePath)
        {
            Logger.Log($"Відкриття файлу: {filePath}");

            try
            {
                var result = Reader.ReadFile(filePath);

                int totalRows = result.Length;
                int totalChars = result.Sum(row => row.Length);

                Logger.Log("Файл успішно прочитано");
                Logger.Log($"Загальна кількість рядків: {totalRows}");
                Logger.Log($"Загальна кількість символів: {totalChars}");

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Помилка при читанні файлу: {ex.Message}");
                throw;
            }
            finally
            {
                Logger.Log($"Закриття файлу: {filePath}");
            }
        }
    }

    public class SmartTextReaderLocker : TextReaderProxy
    {
        private readonly Regex RestrictedFilesPattern;
        private readonly ILogger Logger;

        public SmartTextReaderLocker(ITextReader reader, string restrictedPattern, ILogger logger = null)
            : base(reader)
        {
            RestrictedFilesPattern = new Regex(restrictedPattern, RegexOptions.IgnoreCase);
            Logger = logger ?? new ConsoleLogger();
        }

        public override char[][] ReadFile(string filePath)
        {
            if (RestrictedFilesPattern.IsMatch(filePath))
            {
                Logger.LogWarning("Access denied!");
                return Array.Empty<char[]>();
            }

            return Reader.ReadFile(filePath);
        }
    }
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[INFO] {message}");
            Console.ResetColor();
        }

        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {message}");
            Console.ResetColor();
        }

        public void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARNING] {message}");
            Console.ResetColor();
        }
    }

    public static class FileUtils
    {
        public static void PrepareTestFiles()
        {
            var testDir = "test_files";
            if (!Directory.Exists(testDir))
            {
                Directory.CreateDirectory(testDir);
            }

            string publicContent = @"Звіт про виконану роботу
Відділ: Розробки програмного забезпечення
Дата: 14 лютого 2025 року

За звітний період виконано:
1. Завершення розробки модуля авторизації користувачів
2. Оптимізація запитів до бази даних
3. Впровадження нової системи логування помилок
4. Оновлення документації API

Загальна ефективність роботи відділу зросла на 12% порівняно з минулим кварталом😎
Заплановані задачі на наступний місяць включають інтеграцію з системою аналітики та розробку нових звітів!";

            string confidentialContent = @"КОНФІДЕНЦІЙНО
Звіт відділу безпеки
Дата: 12 лютого 2025 року

Виявлені вразливості:
1. Критична вразливість у системі авторизації (CVE-2025-7891)
2. Потенційний витік даних через незахищений API-ендпоінт
3. Слабкі паролі виявлені у 17% користувачів системи

План виправлення:
- Негайне оновлення авторизаційного модуля до версії 2.1.5
- Впровадження додаткової автентифікації для критичних ендпоінтів
- Запуск кампанії з оновлення паролів для всіх співробітників

Інцидент №458: Спроба несанкціонованого доступу з IP 192.168.1.45
Час: 10.02.2025, 03:15
Статус: Заблоковано, проводиться розслідування";

            File.WriteAllText(Path.Combine(testDir, "allowed.txt"), publicContent, Encoding.UTF8);
            File.WriteAllText(Path.Combine(testDir, "restricted.txt"), confidentialContent, Encoding.UTF8);
        }
        public static void PrintTextArray(char[][] array)
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Масив порожній або не визначений");
                return;
            }

            Console.WriteLine("\n--- Прочитаний текст ---");
            foreach (var row in array)
            {
                Console.WriteLine(new string(row));
            }
            Console.WriteLine("----------------------\n");
        }
    }
}