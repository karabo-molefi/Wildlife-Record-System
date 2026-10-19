
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wildlife_Record_System
{
    internal class SummaryReport
    {
        public string Generate(List<Animal> animals)
        {
            if (animals == null)
            {
                animals = new List<Animal>();
            }

            int totalAnimals = animals.Count;

            string averageAge = totalAnimals > 0
                ? animals.Average(a => a.age).ToString("F2")
                : "N/A";

            string averageRecoveryScore = totalAnimals > 0
                ? animals.Average(a => a.recoveryScore).ToString("F2")
                : "N/A";

            string[] statuses =
            {
                "Critical",
                "Serious",
                "Stable",
                "Recovering",
                "Release-Ready"
            };

            StringBuilder report = new StringBuilder();

            report.AppendLine("WILDLIFE RECORD SYSTEM - SUMMARY REPORT");
            report.AppendLine("---------------------------------------");
            report.AppendLine($"Total Animals: {totalAnimals}");
            report.AppendLine($"Average Age: {averageAge}");
            report.AppendLine($"Average Recovery Score: {averageRecoveryScore}");
            report.AppendLine();
            report.AppendLine("ANIMALS BY STATUS");

            foreach (string status in statuses)
            {
                int count = animals.Count(a =>
                    string.Equals(
                        a.status,
                        status,
                        StringComparison.OrdinalIgnoreCase));

                report.AppendLine($"{status}: {count}");
            }

            return report.ToString();
        }
    }
}
