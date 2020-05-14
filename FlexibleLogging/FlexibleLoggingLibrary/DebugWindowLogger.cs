using System;

namespace FlexibleLoggingLibrary
{
    public class DebugWindowLogger : ILogger
    {
        public void WriteLog(LogLevel errorLevel, string errorMessage, string additionalInfo = "")
        {
            System.Diagnostics.Debug.WriteLine($"{ errorLevel }: { errorMessage }");

            if (!string.IsNullOrWhiteSpace(additionalInfo))
            {
                System.Diagnostics.Debug.WriteLine(additionalInfo);
            }
        }
    }
}
