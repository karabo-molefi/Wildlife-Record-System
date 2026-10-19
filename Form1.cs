namespace Wildlife_Record_System
{
    public partial class Form1 : Form
    {
        private FileHandler FileHandler = new FileHandler();
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animal.txt");
        public Form1()
        {
            InitializeComponent();
            
            InitializeSummaryControls();
            LoadAnimalsToGrid();
        }


        //load animals to datagrid view
        public void LoadAnimalsToGrid()
        {
            List<Animal> animals = FileHandler.LoadFromFile(filePath);
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
                animalToShow = fileHandler.LoadFromFile(filePath);
            }
            else
            {
                animalToShow = fileHandler.SearchAnimals(searchText);

                if (animalToShow.Count == 0)
                {
                    MessageBox.Show(
                        "No animals matched your search",
                        "No results",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

            dataGridViewAnimals.DataSource = null;
            dataGridViewAnimals.DataSource = animalToShow;
        } 
        
        // Creates the summary button and on-screen report area.
        private void InitializeSummaryControls()
        {
            this.ClientSize = new System.Drawing.Size(907, 800);

            System.Windows.Forms.Button btnGenerateSummary =
                new System.Windows.Forms.Button();

            btnGenerateSummary.Name = "btnGenerateSummary";
            btnGenerateSummary.Text = "Generate Summary";
            btnGenerateSummary.Location =
                new System.Drawing.Point(741, 510);
            btnGenerateSummary.Size =
                new System.Drawing.Size(144, 31);

            btnGenerateSummary.Click += btnGenerateSummary_Click;
            this.Controls.Add(btnGenerateSummary);

            System.Windows.Forms.TextBox txtSummary =
                new System.Windows.Forms.TextBox();

            txtSummary.Name = "txtSummary";
            txtSummary.Multiline = true;
            txtSummary.ReadOnly = true;
            txtSummary.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;
            txtSummary.Location =
                new System.Drawing.Point(14, 620);
            txtSummary.Size =
                new System.Drawing.Size(872, 150);

            this.Controls.Add(txtSummary);
        }

        // Calculates and displays the summary and saves summary.txt.
        private void btnGenerateSummary_Click(object sender, EventArgs e)
        {
            try
            {
                // Read the current saved animal records.
                List<Animal> animals =
                    FileHandler.LoadFromFile(filePath);

                string reportPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "summary.txt");

                string reportText =
                    SummaryReport.Generate(animals, reportPath);

                // Display the results on the main form.
                System.Windows.Forms.Control[] matches =
                    this.Controls.Find("txtSummary", true);

                if (matches.Length > 0)
                {
                    matches[0].Text = reportText;
                }

                MessageBox.Show(
                    "Summary generated successfully.",
                    "Summary Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show(
                    "The report could not be written. " +
                    "Check whether the file is open or unavailable.",
                    "File Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                    "Permission denied. Check access to the report file.",
                    "Permission Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FileHandler fileHandler = new FileHandler();

            if (dataGridViewAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select the animal record from the grid to update",
                    "No selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Animal selectedAnimal =
                (Animal)dataGridViewAnimals.SelectedRows[0].DataBoundItem;

            AnimalEntryForm updateForm = new AnimalEntryForm();
            updateForm.SetUpdateMode(selectedAnimal);
            updateForm.ShowDialog();

            searchTXT.Text = "";
            dataGridViewAnimals.DataSource = null;
            dataGridViewAnimals.DataSource =
                fileHandler.LoadFromFile(filePath);
        }
    }
}

    

