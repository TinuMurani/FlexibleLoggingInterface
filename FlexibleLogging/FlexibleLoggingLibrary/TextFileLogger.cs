using System;
using System.IO;
using System.Text;

namespace FlexibleLoggingLibrary
{
    public class TextFileLogger : ILogger
    {
        private string FolderPath { get; }

        public TextFileLogger(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                folderPath = Path.GetTempPath();
            }

            FolderPath = folderPath;
        }

        public void WriteLog(LogLevel errorLevel, string errorMessage, string additionalInfo = "")
        {
            DateTime date = DateTime.Now;
            string fileName = $"err-{date.Year}{date.Month.ToString().PadLeft(2, '0')}{date.Day.ToString().PadLeft(2, '0')}.txt";
            string fullFilePath = Path.Combine(FolderPath, fileName);

            using (StreamWriter sw = File.AppendText(fullFilePath))
            {
                StringBuilder error = new StringBuilder();
                error.AppendLine($"{errorLevel}: {errorMessage}");

                if (!string.IsNullOrWhiteSpace(additionalInfo))
                {
                    error.AppendLine(additionalInfo);
                }

                sw.WriteLine(error);
            }
        }
    }
}
