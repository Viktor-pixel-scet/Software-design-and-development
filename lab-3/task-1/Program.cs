using Interfaces;
using ClassLibrary;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        ILogger logger = new FileLoggerAdapter("log.txt");

        logger.Log("Звичайний запис у лог.");
        logger.Error("Помилка: щось пішло не так!");
        logger.Warn("Попередження: зверніть увагу на цей момент.");

        Console.WriteLine("\nЛоги записано у файл log.txt.");
        Console.WriteLine("Перевірте шлях: lab-3\\task-1\\bin\\Debug\\net8.0\\log.txt");
        Console.ReadLine();
    }
}
