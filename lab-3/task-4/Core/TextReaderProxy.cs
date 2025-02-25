using System;

namespace task_4
{
    public abstract class TextReaderProxy : ITextReader
    {
        protected readonly ITextReader Reader;

        protected TextReaderProxy(ITextReader reader)
        {
            Reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        public abstract char[][] ReadFile(string filePath);
    }
}