
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Wildlife_Record_System
{
    internal class SummaryReport
    {
        // Generates the statistics and writes the report to a text file.
        public static string Generate(
            List<Animal> animals, string reportPath)
        {
            string[] statuses =
            {
                "Critical",
                "Serious",
                "Stable",
                "Recovering",
                "Release-Ready"
            };

            int total = animals.Count;

            string averageAge = total == 0
                ? "N/A"
                : animals.Average(a => a.age)
                    .ToString("F2", CultureInfo.InvariantCulture);

            string averageScore = total == 0
                ? "N/A"
                : animals.Average(a => a.recoveryScore)
                    .ToString("F2", CultureInfo.InvariantCulture);

            var report = new StringBuilder();

            report.AppendLine(
                "BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE");
            report.AppendLine("ANIMAL SUMMARY REPORT");
            report.AppendLine(
                $"Generated: {DateTime.Now.ToString(
                    "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)}");
            report.AppendLine("----------------------------------------");
            report.AppendLine(
                $"Total animals:            {total}");
            report.AppendLine(
                $"Average age (years):      {averageAge}");
            report.AppendLine(
                $"Average recovery score:   {averageScore}");
            report.AppendLine("----------------------------------------");
            report.AppendLine("Animals per status:");

            foreach (string status in statuses)
            {
                int count = animals.Count(a =>
                    string.Equals(
                        a.status, status,
                        StringComparison.OrdinalIgnoreCase));

                report.AppendLine($"  {status + ":",-24}{count}");
            }

            string reportText = report.ToString();

            // Overwrite the previous report instead of appending.
            File.WriteAllText(
                reportPath, reportText, new UTF8Encoding(false));

            return reportText;
        }
    }
}
