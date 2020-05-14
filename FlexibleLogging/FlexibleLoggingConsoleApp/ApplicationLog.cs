using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using FlexibleLoggingLibrary;

namespace FlexibleLoggingConsoleApp
{
    public static class ApplicationLog
    {
        private static ILogger configuredLogger;
        private static ILogger Logger 
        {
            get
            {
                if (configuredLogger is null)
                {
                    return new ConsoleLogger();
                }

                return configuredLogger;
            }
        }

        public static void ConfigureLogger(ILogger logger)
        {
            if (logger is WindowsEventsLogging)
            {
                RequireAdministratorPrivileges();
                configuredLogger = logger;
            }

            configuredLogger = logger;
        }

        public static void WriteLog(LogLevel errorLevel, string errorMessage, string additionalInfo)
        {
            Logger.WriteLog(errorLevel, errorMessage, additionalInfo);
        }

        private static void RequireAdministratorPrivileges()
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
                    {
                        WindowsPrincipal principal = new WindowsPrincipal(identity);

                        if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                        {
                            throw new InvalidOperationException($"Application must be run as Administrator." +
                                $"Right click the '{ AppDomain.CurrentDomain.FriendlyName }.exe' file and select 'Run as administrator'.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteLog(LogLevel.Critical, ex.Message, ex.StackTrace);
            }
        }
    }
}
