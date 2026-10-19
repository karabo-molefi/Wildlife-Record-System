using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;


namespace Wildlife_Record_System
{
    internal class FileHandler
    {
        public FileHandler() { }

        // Load animal record from animal.txt, validates each line
        // Skips malformed entries
        public List<Animal> LoadFromFile(string filePath)
        {
            List<Animal> animals = new List<Animal>();
            int skippedLinesCount = 0;
            DataHandler dataHandler = new DataHandler();

            try
            {
                // if animal.txt does not exist create a new file
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, string.Empty, Encoding.UTF8);
                    return animals;
                }

                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

                foreach (string line in lines)
                {
                    // not empty 
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split('|');

                    // must have exactly 7 parts
                    if (parts.Length != 7)
                    {
                        skippedLinesCount++;
                        continue;
                    }

                    // trim all the parts
                    string animalID = parts[0].Trim();
                    string name = parts[1].Trim();
                    string species = parts[2].Trim();
                    string status = parts[5].Trim();
                    string housingUnit = parts[6].Trim();

                    // prevent crashes on letters in the numeric field
                    if (!int.TryParse(parts[3].Trim(), out int age) ||
                        !int.TryParse(parts[4].Trim(), out int recoveryScore))
                    {
                        skippedLinesCount++;
                        continue;
                    }

                    // Validate all parts using data handler validation methods
                    bool isValid = dataHandler.validateAnimalID(animalID) &&
                                   dataHandler.validateTextFields(name) &&
                                   dataHandler.validateTextFields(species) &&
                                   dataHandler.validateNumericFields(age) &&
                                   dataHandler.validateNumericFields(recoveryScore);

                    if (!isValid)
                    {
                        // Increment skipped lines and SKIP this iteration[cite: 2]
                        skippedLinesCount++;
                        continue;
                    }

                    // create new animal
                    Animal animal = new Animal(
                        animalID, name, species, age, recoveryScore, status, housingUnit);

                    animals.Add(animal);

                }

                // inform user about lines skipped
                if (skippedLinesCount > 0)
                {
                    MessageBox.Show($"Warning: {skippedLinesCount} malformed line(s) were skipped.",
            "File Load Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"File error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Permission denied access to animals.txt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return animals;

        }



        // writes animal record to the animal.txt by appending them
        public void writeAnimalRecord(Animal animal)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animal.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true, Encoding.UTF8))
                {
                    writer.WriteLine(animal.ToString());
                }
                MessageBox.Show("Successfully Added Animal.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"File error (it may be open in another program): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied. Cannot write to animals.txt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        // search the animal by ID,name, or status
        public List<Animal> SearchAnimals(string searchText)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animal.txt");

            //load every animal first
            List<Animal> allAnimals = LoadFromFile(filePath);
            List<Animal> results = new List<Animal>();

            searchText = searchText.Trim().ToLower();
            foreach (Animal animal in allAnimals)
            {
                // check if the search text is found in any of these fields
                if (animal.animalID.ToLower().Contains(searchText) ||
                    animal.name.ToLower().Contains(searchText) ||
                    animal.species.ToLower().Contains(searchText) ||
                    animal.status.ToLower().Contains(searchText))
                {
                    results.Add(animal);
                }

            }
            return results;
        }


        //repplaces the old recrd that has the same ID with the updated animal

        public bool UpdatedAnimals(Animal updatedAnimal) 
        {

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animal.txt");
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("The data file (animal.txt) could not be found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                bool recordFound = false;

                //goes throught each line and look for the matching ID
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split('|');

                    if (parts[0].Trim().Equals(updatedAnimal.animalID, StringComparison.OrdinalIgnoreCase))
                    {
                        //REPLACES THE OLD LINE WITH THE NEW ANIMAL DETAILS
                        lines[i] = updatedAnimal.ToString();
                        recordFound = true;
                        break; //stops

                    }

                }
                if (!recordFound)
                {
                    MessageBox.Show("Animal record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    return false;
                }
                //save the updated details to the file
                File.WriteAllLines(filePath, lines, Encoding.UTF8);

                MessageBox.Show("Animal record updated successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show($"File error: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return false;

            }
           
        }
    }

}

