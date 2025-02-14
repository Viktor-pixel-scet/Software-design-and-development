using System.Text;
using task_4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;

            FileUtils.PrepareTestFiles();

            var logger = new ConsoleLogger();
            var baseReader = new SmartTextReader();
            var checkerProxy = new SmartTextChecker(baseReader, logger);
            var lockerProxy = new SmartTextReaderLocker(baseReader, @".*restricted.*\.txt$", logger);

            var combinedProxy = new SmartTextChecker(
                new SmartTextReaderLocker(baseReader, @".*restricted.*\.txt$", logger),
                logger
            );

            var allowedPath = Path.Combine("test_files", "allowed.txt");
            var restrictedPath = Path.Combine("test_files", "restricted.txt");

            Console.WriteLine("\n=== Тест з базовим читачем ===");
            var result1 = baseReader.ReadFile(allowedPath);
            FileUtils.PrintTextArray(result1);

            Console.WriteLine("\n=== Тест з проксі для логування ===");
            var result2 = checkerProxy.ReadFile(allowedPath);
            FileUtils.PrintTextArray(result2);

            Console.WriteLine("\n=== Тест з проксі для обмеження доступу (дозволений файл) ===");
            var result3 = lockerProxy.ReadFile(allowedPath);
            FileUtils.PrintTextArray(result3);

            Console.WriteLine("\n=== Тест з проксі для обмеження доступу (заборонений файл) ===");
            var result4 = lockerProxy.ReadFile(restrictedPath);
            FileUtils.PrintTextArray(result4);

            Console.WriteLine("\n=== Тест з комбінованим проксі (дозволений файл) ===");
            var result5 = combinedProxy.ReadFile(allowedPath);
            FileUtils.PrintTextArray(result5);

            Console.WriteLine("\n=== Тест з комбінованим проксі (заборонений файл) ===");
            var result6 = combinedProxy.ReadFile(restrictedPath);
            FileUtils.PrintTextArray(result6);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Критична помилка: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }
}