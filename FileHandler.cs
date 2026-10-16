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


    }
}
