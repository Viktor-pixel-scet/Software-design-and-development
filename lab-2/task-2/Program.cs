using System;
using Interfaces;
using ClassLibrary;
using System.Text;
using task_2;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                var store = new TechStore();
                store.Run();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Критична помилка програми: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}