using System;
using System.Text.RegularExpressions;

namespace task_4
{
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
}