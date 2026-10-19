using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Wildlife_Record_System
{
    internal class FileHandler
    {
        public FileHandler() { }

        public void writeAnimalRecord(List<Animal> animals, int skipped)
        {
          
            using (StreamWriter writer = new StreamWriter("animal.txt", append: true))
            {
                foreach (var animal in animals)
                {
                    writer.WriteLine(animal.ToString());

                }
                writer.Flush();
            }
            MessageBox.Show("Complete");
            MessageBox.Show($"Number of lines skipped: {skipped}.");

        }


        //delete the record with the specified ID
        //return true only when the deletion has happend successfully
        public bool DeleteAnimal(string animalID) 
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt");
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"The data file (animals.txt) could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                List<string> updatedLines = new List<string>();
                bool recordFound = false;

                foreach (string line in lines)
                {
                    // If it's not empty, check if it matches the ID
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length > 0 && parts[0].Trim().Equals(animalID, StringComparison.OrdinalIgnoreCase))
                        {
                            recordFound = true;
                            continue; // Skips adding it (deletes it)
                        }
                    }

                    // Keep everything else (blank lines or non-matching records)
                    updatedLines.Add(line);
                }

                if (!recordFound)
                {
                    MessageBox.Show($"No animal record with ID '{animalID}' was found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                File.WriteAllLines(filePath, updatedLines, Encoding.UTF8);
                MessageBox.Show($"Animal record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error deleting animal record: {ex.Message}");
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"Permission denied. Cannot modify animals.txt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
