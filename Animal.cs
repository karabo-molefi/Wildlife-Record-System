using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wildlife_Record_System
{
    internal class Animal
    {
        public Animal(string animalID, string name, string species, int age, int recoveryScore, string status, string housingUnit)
        {
            this.animalID = animalID;
            this.name = name;
            this.species = species;
            this.age = age;
            this.recoveryScore = recoveryScore;
            this.status = status;
            this.housingUnit = housingUnit;
        }

        string animalID { get; set; }
        string name { get; set; }
        string species { get; set; }
        int age { get; set; }
        public int recoveryScore { get; set; }
        public string status { get; set; }
        public string housingUnit { get; set; }

        public override string? ToString()
        {
            return $"Animal ID: {animalID}| Species: {species} | Age: {age} | Recovery Score: {recoveryScore} | Status: {status} | Housing Unit: {housingUnit}";
        }


    }
}
