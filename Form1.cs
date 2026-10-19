
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Wildlife_Record_System
{
    public partial class Form1 : Form
    {
        private FileHandler FileHandler = new FileHandler();

        private string filePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "animal.txt");

       

        public Form1()
        {
            InitializeComponent();
        
            LoadAnimalsToGrid();
        }




        public void LoadAnimalsToGrid()
        {
            List<Animal> animals = FileHandler.LoadFromFile(filePath);

            dataGridViewAnimals.AutoGenerateColumns = false;
            dataGridViewAnimals.Columns.Clear();

            dataGridViewAnimals.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "Animal ID",
                    DataPropertyName = "animalID"
                });

            dataGridViewAnimals.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colName",
                    HeaderText = "Name",
                    DataPropertyName = "name"
                });

            dataGridViewAnimals.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colSpecies",
                    HeaderText = "Species",
                    DataPropertyName = "species"
                });

            dataGridViewAnimals.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colAge",
                    HeaderText = "Age",
                    DataPropertyName = "age"
                });

            dataGridViewAnimals.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colScore",
                    HeaderText = "Recovery Score",
                    DataPropertyName = "recoveryScore"
                });

            dataGridViewAnimals.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "Status",
                    DataPropertyName = "status"
                });

            dataGridViewAnimals.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colHousing",
                    HeaderText = "Housing Unit",
                    DataPropertyName = "housingUnit"
                });

            dataGridViewAnimals.DataSource = null;
            dataGridViewAnimals.DataSource = animals;
            dataGridViewAnimals.AutoGenerateColumns = false;
        }

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
                if (dataGridViewAnimals.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Please select an animal record from the grid to delete.",
                        "No Selection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DataGridViewRow selectedRow =
                    dataGridViewAnimals.SelectedRows[0];

                string animalId =
                    selectedRow.Cells["colId"]?.Value?.ToString()?.Trim()
                    ?? string.Empty;

                string animalName =
                    selectedRow.Cells["colName"]?.Value?.ToString()?.Trim()
                    ?? string.Empty;

                if (string.IsNullOrEmpty(animalId))
                {
                    MessageBox.Show(
                        "The selected row does not contain a valid Animal ID.",
                        "Invalid Selection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                DialogResult confirmation = MessageBox.Show(
                    $"Delete {animalId} ({animalName})? This cannot be undone.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation == DialogResult.No)
                {
                    return;
                }

                bool isDeleted = FileHandler.DeleteAnimal(animalId);

                if (isDeleted)
                {
                    LoadAnimalsToGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An unexpected error occurred: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = searchTXT.Text.Trim();
            List<Animal> animalsToShow;

            if (searchText == "")
            {
                animalsToShow = FileHandler.LoadFromFile(filePath);
            }
            else
            {
                animalsToShow = FileHandler.SearchAnimals(searchText);

                if (animalsToShow.Count == 0)
                {
                    MessageBox.Show(
                        "No animals matched your search.",
                        "No Results",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

            dataGridViewAnimals.DataSource = null;
            dataGridViewAnimals.DataSource = animalsToShow;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an animal record from the grid to update.",
                    "No Selection",
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
            LoadAnimalsToGrid();
        }

        private void btnGenerateSummary_Click(object sender, EventArgs e)
        {
            try
            {
                List<Animal> animals =
                    FileHandler.LoadFromFile(filePath);

                SummaryReport summaryReport = new SummaryReport();

                string reportText = summaryReport.Generate(animals);

                MessageBox.Show(
                    reportText,
                    "Wildlife Record System - Summary Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not generate the summary report: {ex.Message}",
                    "Summary Report Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
