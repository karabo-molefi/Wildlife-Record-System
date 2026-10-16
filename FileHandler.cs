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

        public void writeAnimalRecord(Animal animal)
        {
          
            using (StreamWriter writer = new StreamWriter("animal.txt", append: true))
            {
                writer.WriteLine(animal.ToString());
                writer.Flush();
            }

            MessageBox.Show("Complete");

        }


    }
}
