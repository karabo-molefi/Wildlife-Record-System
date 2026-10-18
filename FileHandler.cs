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

        // Updates an existing animal in the file.
        public bool UpdateAnimal(string filePath, string animalID, Animal updatedAnimal)
        {
            try
            {
                // Load all the animals from the file.
                List<Animal> animals = LoadFromFile(filePath);

                // Find the animal that needs to be updated.
                int animalIndex = -1;

                for (int i = 0; i < animals.Count; i++)
                {
                    if (animals[i].AnimalID.Equals(animalID,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        animalIndex = i;
                        break;
                    }
                }

                // Check if the animal was found.
                if (animalIndex == -1)
                {
                    MessageBox.Show("Animal was not found.");
                    return false;
                }

                // Keep the original ID so it cannot be changed.
                string originalID = animals[animalIndex].AnimalID;

                // Get the new status and housing unit from the recovery score.
                DataHandler dataHandler = new DataHandler();
                var result = dataHandler.ClassifyAnimal(updatedAnimal.RecoveryScore);

                // Replace the old animal with the updated information.
                Animal animal = new Animal(
                    originalID,
                    updatedAnimal.Name,
                    updatedAnimal.Species,
                    updatedAnimal.Age,
                    updatedAnimal.RecoveryScore,
                    result.status,
                    result.housingUnit
                );

                animals[animalIndex] = animal;

                // Save all the animals back to the file.
                List<string> lines = new List<string>();

                foreach (Animal a in animals)
                {
                    lines.Add(a.ToString());
                }

                File.WriteAllLines(filePath, lines, Encoding.UTF8);

                MessageBox.Show("Animal updated successfully.");
                return true;
            }
            catch (IOException)
            {
                MessageBox.Show("The file could not be updated. Please check if it is open.");
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to update the file.");
                return false;
            }
        }
    }

}

