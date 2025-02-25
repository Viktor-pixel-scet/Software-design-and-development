using Interfaces;
using System;

namespace ClassLibrary
{
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