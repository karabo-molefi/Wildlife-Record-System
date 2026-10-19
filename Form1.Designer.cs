namespace Wildlife_Record_System
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            dataGridViewAnimals = new DataGridView();
            btnSearch = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnExit = new Button();
            lblHeader = new Label();
            label1 = new Label();
            searchTXT = new TextBox();
            btnGenerateSummary2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAnimals).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 359);
            button1.Name = "button1";
            button1.Size = new Size(126, 23);
            button1.TabIndex = 0;
            button1.Text = "Add Animal";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridViewAnimals
            // 
            dataGridViewAnimals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAnimals.Location = new Point(27, 73);
            dataGridViewAnimals.Name = "dataGridViewAnimals";
            dataGridViewAnimals.RowHeadersWidth = 51;
            dataGridViewAnimals.Size = new Size(763, 259);
            dataGridViewAnimals.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(185, 359);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(126, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(351, 359);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(126, 23);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(496, 359);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(126, 23);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(648, 359);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(126, 23);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 20F);
            lblHeader.Location = new Point(12, 19);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(287, 37);
            lblHeader.TabIndex = 6;
            lblHeader.Text = "Wildlife Record System";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 421);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 7;
            label1.Text = "Animal ID :";
            // 
            // searchTXT
            // 
            searchTXT.Location = new Point(101, 416);
            searchTXT.Margin = new Padding(3, 2, 3, 2);
            searchTXT.Name = "searchTXT";
            searchTXT.Size = new Size(182, 23);
            searchTXT.TabIndex = 8;
            // 
            // btnGenerateSummary2
            // 
            btnGenerateSummary2.Location = new Point(648, 416);
            btnGenerateSummary2.Name = "btnGenerateSummary2";
            btnGenerateSummary2.Size = new Size(126, 23);
            btnGenerateSummary2.TabIndex = 9;
            btnGenerateSummary2.Text = "Generate Summary";
            btnGenerateSummary2.UseVisualStyleBackColor = true;
            btnGenerateSummary2.Click += btnGenerateSummary_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 464);
            Controls.Add(btnGenerateSummary2);
            Controls.Add(searchTXT);
            Controls.Add(label1);
            Controls.Add(lblHeader);
            Controls.Add(btnExit);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSearch);
            Controls.Add(dataGridViewAnimals);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Wildlife Record System";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAnimals).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridViewAnimals;
        private Button btnSearch;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnExit;
        private Label lblHeader;
        private Label label1;
        private TextBox searchTXT;
        private Button btnGenerateSummary2;
    }
}
