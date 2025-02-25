using System;
using System.Linq;

namespace task_4
{
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
}