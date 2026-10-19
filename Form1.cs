namespace Wildlife_Record_System
{
    public partial class Form1 : Form
    {
        private FileHandler FileHandler = new FileHandler();
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animal.txt");
        public Form1()
        {
            InitializeComponent();

            LoadAnimalsToGrid();
        }


        //load animals to datagrid view
        public void LoadAnimalsToGrid()
        {
            List<Animal> animals = FileHandler.LoadFromFile(filePath);
            dataGridViewAnimals.AutoGenerateColumns = false;


            // 1. Animal ID
            dataGridViewAnimals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Animal ID",
                DataPropertyName = "animalID"
            });

            // 2. Name
            dataGridViewAnimals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colName",
                HeaderText = "Name",
                DataPropertyName = "name"
            });

            // 3. Species
            dataGridViewAnimals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colSpecies",
                HeaderText = "Species",
                DataPropertyName = "species"
            });

            // 4. Age
            dataGridViewAnimals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colAge",
                HeaderText = "Age",
                DataPropertyName = "age"
            });

            // 5. Recovery Score
            dataGridViewAnimals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colScore",
                HeaderText = "Recovery Score",
                DataPropertyName = "recoveryScore"
            });

            // 6. Status
            dataGridViewAnimals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colStatus",
                HeaderText = "Status",
                DataPropertyName = "Status"
            });

            // 7. Housing Unit
            dataGridViewAnimals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colHousing",
                HeaderText = "Housing Unit",
                DataPropertyName = "HousingUnit"
            });

            dataGridViewAnimals.DataSource = null;
            dataGridViewAnimals.DataSource = animals;

            dataGridViewAnimals.AutoGenerateColumns = false;

        }





        private void button1_Click(object sender, EventArgs e)
        {
            AnimalEntryForm addAnimal = new AnimalEntryForm();
            addAnimal.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //  Check if a row is selected in the DataGridView
                if (dataGridViewAnimals.SelectedRows.Count == 0)
                {
                    MessageBox.Show($"Please select an animal record from the grid to delete.",
                        "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //  Get the selected row
                DataGridViewRow selectedRow = dataGridViewAnimals.SelectedRows[0];

                //  Extract the Animal ID and Name
                string animalId = selectedRow.Cells["colId"]?.Value?.ToString()?.Trim() ?? string.Empty;
                string animalName = selectedRow.Cells["colName"]?.Value?.ToString()?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(animalId))
                {
                    MessageBox.Show($"The selected row does not contain a valid Animal ID.",
                        "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //  Show Yes/No confirmation dialog displaying the animal's ID and name
                DialogResult confirmation = MessageBox.Show(
                    $"Delete {animalId} ({animalName})? This cannot be undone.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // Choosing No changes nothing
                if (confirmation == DialogResult.No)
                {
                    return;
                }

                // Call the delete method passing ONLY the animalId (since FileHandler handles its own path)
                bool isDeleted = FileHandler.DeleteAnimal(animalId);

                if (isDeleted)
                {
                    // Automatically refresh the grid to show the updated list
                    LoadAnimalsToGrid();
                }
            }
            catch (Exception ex)
            {
                // Safety net to ensure the application never crashes unhandled
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
