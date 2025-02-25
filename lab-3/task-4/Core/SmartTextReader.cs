using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
}