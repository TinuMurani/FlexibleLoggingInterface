using System;

namespace FlexibleLoggingLibrary
{
    public class ConsoleLogger : ILogger
    {
        public void WriteLog(LogLevel errorLevel, string errorMessage, string additionalInfo = "")
        {
            Console.WriteLine($"{ errorLevel }: { errorMessage }", Console.ForegroundColor = ConsoleColor.Red);

            if (!string.IsNullOrWhiteSpace(additionalInfo))
            {
                Console.WriteLine(additionalInfo, Console.ForegroundColor = ConsoleColor.DarkRed);
            }

            Console.ResetColor();
        }
    }
}
