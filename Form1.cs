namespace Wildlife_Record_System
{
    public partial class Form1 : Form
    {
        private FileHandler fileHandler = new FileHandler();
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animal.txt");
        public Form1()
        {
            InitializeComponent();

            LoadAnimalsToGrid();
        }


        //load animals to datagrid view
        public void LoadAnimalsToGrid()
        {
            List<Animal> animals = fileHandler.LoadFromFile(filePath);
            dataGridViewAnimals.AutoGenerateColumns = false;
            dataGridViewAnimals.Columns.Clear();

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




        //opens the animal entry and refreshes the grid when it closes
        private void button1_Click(object sender, EventArgs e)
        {
            AnimalEntryForm addAnimal = new AnimalEntryForm();
            addAnimal.ShowDialog();

            LoadAnimalsToGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FileHandler fileHandler = new FileHandler();
            string searchText = searchTXT.Text.Trim();
            List<Animal> animalToShow;

            if (searchText == "")
            {
                //nothing typed, so show all the animal
                animalToShow = fileHandler.LoadFromFile(filePath);

            }

            else
            {
                //show only the animals that match the search text
                animalToShow = fileHandler.SearchAnimals(searchText);

                if (animalToShow.Count == 0)
                {

                    MessageBox.Show("No animals matched your search", "No results", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            dataGridViewAnimals.DataSource = null;
            dataGridViewAnimals.DataSource = animalToShow;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FileHandler fileHandler = new FileHandler();
            //check that a row is selected
            if (dataGridViewAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select the animal record from the grid to update", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            // get the animal that belongs to the selected row
            Animal selectedAnimal = (Animal)dataGridViewAnimals.SelectedRows[0].DataBoundItem;

            //open the Animal entry form in update mode 
            AnimalEntryForm updateForm = new AnimalEntryForm();
            updateForm.SetUpdateMode(selectedAnimal);
            updateForm.ShowDialog();

            //refresh the grid with the latest data from the file
            searchTXT.Text = "";
            dataGridViewAnimals.DataSource = null;
            dataGridViewAnimals.DataSource = fileHandler.LoadFromFile(filePath);

        }
    }
}
