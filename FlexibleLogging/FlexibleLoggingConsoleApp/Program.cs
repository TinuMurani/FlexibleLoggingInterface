using FlexibleLoggingLibrary;
using System;

namespace FlexibleLoggingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationLog.ConfigureLogger(new WindowsEventsLogging());

            try
            {
                int i = 2;
                int j = 0;

                int result = i / j;

                Console.WriteLine($"Result: { result }");
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteLog(LogLevel.High, ex.Message, ex.StackTrace);
            }

            Console.ReadLine();
        }
    }
}
