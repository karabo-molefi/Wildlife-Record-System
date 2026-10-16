using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wildlife_Record_System
{
    internal class DataHandler
    {
        public DataHandler() { }

        public (string status, string housingUnit) ClassifyAnimal(int recoveryScore)
        {
            string status = null;
            string housingUnit = null;

           

            // evaluate recovery score
            if (recoveryScore > 0 && recoveryScore <= 19)
            {
                status = "Critical";
                housingUnit = "Instensive Care Unit";
            }
            else if (recoveryScore >= 20 && recoveryScore <= 39)
            {
                status = "Serious";
                housingUnit = "High Dependency Ward";
            }
            else if (recoveryScore >= 40 && recoveryScore <= 59)
            {
                status = "Stable";
                housingUnit = "Recovery Ward";
            }
            else if (recoveryScore >= 60 && recoveryScore <= 79)
            {
                status = "Recovering";
                housingUnit = "Outdoor Enclosure";
            }
            else if (recoveryScore >= 80 && recoveryScore <= 1000)
            {
                status = "Release-Ready";
                housingUnit = "Pre-Release Camp";
            }

            return (status, housingUnit);


        }
    }
}
