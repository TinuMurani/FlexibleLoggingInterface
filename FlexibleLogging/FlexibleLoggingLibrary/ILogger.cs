namespace FlexibleLoggingLibrary
{
    public interface ILogger
    {
        void WriteLog(LogLevel errorLevel, string errorMessage, string additionalInfo = "");
    }
}
