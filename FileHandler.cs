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


        //updates one existing animal without changing its ID
        public bool UpdateAnimal()
        {
            try
            {

            }
            catch (Exception ex) 
            {
            MessageBox.Show($"Error updating animal record: {ex.Message}");
                return false;
            }

        }

        //delete the record with thr specified ID
        //return true only when the deletion has happende successfully
        public bool DeleteAnimal(string animalID) 
        {
            try
            {
            
            }
            catch (Exception ex)
            { 
             MessageBox.Show($"Error deleting animal record: {ex.Message}");
                return false;
            }
        }

    }
}
