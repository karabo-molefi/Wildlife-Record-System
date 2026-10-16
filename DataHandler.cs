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

        public Boolean validateAnimalID(string animalID)
        {
            // convert to upper case before checking
            animalID.ToUpper();

            if (animalID != null)
            {
                if (animalID.Contains('-'))
                {
                    if (animalID.ToLower().StartsWith("wr"))
                    {
                        // split by "-"
                        string[] splitID = animalID.Split('-');

                        // check length of left string must = 4;
                        if (splitID[1].Length > 0)
                        {
                            // check if all charcters on the left are digits
                            if (splitID[1].All(char.IsDigit))
                            {
                                return true;
                            }
                        }
                        
                    }
                }
                
            }
            // return false all checks not satisfied
            return false;
        }

        public Boolean validateTextFields(string textField)
        {
            // Validates Name & Species Fields

            // not empty
            if (!string.IsNullOrEmpty(textField))
            {
                // within 1 - 30 characters range
                if (textField.Length > 1 && textField.Length <= 30)
                {
                    // no pipe character 
                    if (!textField.Contains('|'))
                    {
                        return true;
                    }
                }
            }
            // return false all checks not satisfied
            return false;
            
        }

        public Boolean validateNumericFields(int numericField)
        {
            // int type
      
            if (numericField.GetType() == typeof(int))
            {
                // range of 0 - 100
                if (numericField > 0 && numericField <= 100)
                {
                    return true;
                }
            }
            // return false all checks not satisfied
            return false;
        }


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
