using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Log: {message}");
            Console.ResetColor();
        }
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }
        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Warning: {message}");
            Console.ResetColor();
        }
    }

    public class FileWriter : IfileWriter
    {
        private readonly string filePath;

        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }
        public void Write(string content)
        {
            File.AppendAllText(filePath, content);
        }
        public void WriteLine(string content)
        {
            File.AppendAllText(filePath, content + Environment.NewLine);
        }
    }
    public class FileLoggerAdapter : ILogger
    {
        private readonly ILogger ConsoleLogger;
        private readonly IfileWriter FileWriter;

        public FileLoggerAdapter(string filePath)
        {
            ConsoleLogger = new Logger();
            FileWriter = new FileWriter(filePath);
        }
        public void Log(string message)
        {
            ConsoleLogger.Log(message);
            FileWriter.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
        public void Error(string message)
        {
            ConsoleLogger.Error(message);
            FileWriter.WriteLine($"[ERROR] {DateTime.Now}: {message}");
        }
        public void Warn(string message)
        {
            ConsoleLogger.Warn(message);
            FileWriter.WriteLine($"[WARNING] {DateTime.Now}: {message}");
        }
    }
}
