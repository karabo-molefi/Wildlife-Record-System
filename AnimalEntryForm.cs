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
        //remeber if the form is being used to update an animal
        private bool isUpdating  =false;
        public AnimalEntryForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            // Form input settings
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


            FileHandler fileHandler = new FileHandler();
            DataHandler dataHandler = new DataHandler();


            string animalID = animalIDTxt.Text;
            string name = nameTxt.Text;
            string species = speciesTxt.Text;
            int age = (int)AgeNumericUpDown.Value;
            int recoveryScore = (int)RecScoreNumericUpDown.Value;

            // classify animal, calculate satus and housing unit
            var (status, housingUnit) = dataHandler.ClassifyAnimal(recoveryScore);

            // create animal 


            // Validate all parts using data handler validation methods
            bool isValid = dataHandler.validateAnimalID(animalID) &&
                           dataHandler.validateTextFields(name) &&
                           dataHandler.validateTextFields(species) &&
                           dataHandler.validateNumericFields(age) &&
                           dataHandler.validateNumericFields(recoveryScore);

            if (isValid)
            {
                Animal animal = new Animal(animalID, name, species, age, recoveryScore, status, housingUnit);
                fileHandler.writeAnimalRecord(animal);
            }
            else
            {
                MessageBox.Show("Unable to save. The animal entered was not in the correct format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AnimalEntryForm_Load(object sender, EventArgs e)
        {
            
        }

        internal  void SetUpdateMode(Animal animalToUpdate) 
        {
            isUpdating = true;

            // change the form title and the button text
            this.Text = "Update Animal";
            btnAddAnimal.Text = "Update";

            // fill the boxes with the animal's current details
            animalIDTxt.Text = animalToUpdate.animalID;
            nameTxt.Text = animalToUpdate.name;
            speciesTxt.Text = animalToUpdate.species;
            AgeNumericUpDown.Value = animalToUpdate.age;
            RecScoreNumericUpDown.Value = animalToUpdate.recoveryScore;

            // the ID must not change because it is used to find the record
            animalIDTxt.ReadOnly = true;
        }
    }
}
