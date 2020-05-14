using System.Diagnostics;
using System.Text;

namespace FlexibleLoggingLibrary
{
    public class WindowsEventsLogging : ILogger
    {
        public void WriteLog(LogLevel errorLevel, string errorMessage, string additionalInfo = "")
        {
            StringBuilder error = new StringBuilder();
            error.Append(errorLevel);
            error.Append(": ");
            error.Append(errorMessage);

            if (!string.IsNullOrWhiteSpace(additionalInfo))
            {
                error.AppendLine(additionalInfo);
            }

            EventLog.WriteEntry("FlexibleLoggingApp", error.ToString());
        }
    }
}
