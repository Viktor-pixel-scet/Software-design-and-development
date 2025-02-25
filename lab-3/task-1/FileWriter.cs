using Interfaces;
using System;
using System.IO;

namespace ClassLibrary
{
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
}