using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wildlife_Record_System
{
    public partial class AnimalEntryForm : Form
    {
        public AnimalEntryForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string animalID = animalIDTxt.Text;
            string name = nameTxt.Text;
            string species = speciesTxt.Text;

            // Prevent decimal places from showing
            AgeNumericUpDown.DecimalPlaces = 0;
            RecScoreNumericUpDown.DecimalPlaces = 0;

            // Set the step interval to whole numbers
            AgeNumericUpDown.Increment = 1;
            RecScoreNumericUpDown.Increment = 0;

            // Set min-max boundaries 
            AgeNumericUpDown.Minimum = 0;
            AgeNumericUpDown.Maximum = 100;
            RecScoreNumericUpDown.Minimum = 0;
            RecScoreNumericUpDown.Maximum = 100;

            int age = (int)AgeNumericUpDown.Value;
            int recoveryScore = (int)RecScoreNumericUpDown.Value;
            
            // classify animal
            DataHandler dataHandler = new DataHandler();

            var (status, housingUnit) = dataHandler.ClassifyAnimal(recoveryScore);

            // create animal 

            Animal animal = new Animal(animalID, name, species, age, recoveryScore, status, housingUnit);

            // save animal 

            FileHandler fileHandler = new FileHandler();

            fileHandler.writeAnimalRecord(animal);

            



        }
    }
}
