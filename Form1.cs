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


            // 1. Animal ID
            dataGridViewAnimals.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colId",
                HeaderText = "Animal ID",
                DataPropertyName = "animalID" // Must match your Animal class property name
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
    }
}
