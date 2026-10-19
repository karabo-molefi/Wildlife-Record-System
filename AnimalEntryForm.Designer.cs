namespace Wildlife_Record_System
{
    partial class AnimalEntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            animalIDTxt = new TextBox();
            nameTxt = new TextBox();
            speciesTxt = new TextBox();
            btnAddAnimal = new Button();
            AgeNumericUpDown = new NumericUpDown();
            RecScoreNumericUpDown = new NumericUpDown();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)AgeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RecScoreNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 61);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 0;
            label1.Text = "Animal ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 119);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 169);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 3;
            label3.Text = "Species";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 227);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 2;
            label4.Text = "Age";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 285);
            label5.Name = "label5";
            label5.Size = new Size(110, 20);
            label5.TabIndex = 5;
            label5.Text = "Recovery Score";
            // 
            // animalIDTxt
            // 
            animalIDTxt.Location = new Point(165, 61);
            animalIDTxt.Margin = new Padding(3, 4, 3, 4);
            animalIDTxt.Name = "animalIDTxt";
            animalIDTxt.Size = new Size(137, 27);
            animalIDTxt.TabIndex = 7;
            // 
            // nameTxt
            // 
            nameTxt.Location = new Point(165, 115);
            nameTxt.Margin = new Padding(3, 4, 3, 4);
            nameTxt.Name = "nameTxt";
            nameTxt.Size = new Size(137, 27);
            nameTxt.TabIndex = 8;
            // 
            // speciesTxt
            // 
            speciesTxt.Location = new Point(165, 165);
            speciesTxt.Margin = new Padding(3, 4, 3, 4);
            speciesTxt.Name = "speciesTxt";
            speciesTxt.Size = new Size(137, 27);
            speciesTxt.TabIndex = 9;
            // 
            // btnAddAnimal
            // 
            btnAddAnimal.Location = new Point(46, 363);
            btnAddAnimal.Margin = new Padding(3, 4, 3, 4);
            btnAddAnimal.Name = "btnAddAnimal";
            btnAddAnimal.Size = new Size(117, 31);
            btnAddAnimal.TabIndex = 14;
            btnAddAnimal.Text = "Add  Animal";
            btnAddAnimal.UseVisualStyleBackColor = true;
            btnAddAnimal.Click += btnAddAnimal_Click;
            // 
            // AgeNumericUpDown
            // 
            AgeNumericUpDown.Location = new Point(165, 224);
            AgeNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            AgeNumericUpDown.Name = "AgeNumericUpDown";
            AgeNumericUpDown.Size = new Size(137, 27);
            AgeNumericUpDown.TabIndex = 15;
            // 
            // RecScoreNumericUpDown
            // 
            RecScoreNumericUpDown.Location = new Point(165, 275);
            RecScoreNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            RecScoreNumericUpDown.Name = "RecScoreNumericUpDown";
            RecScoreNumericUpDown.Size = new Size(137, 27);
            RecScoreNumericUpDown.TabIndex = 16;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(189, 363);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(113, 31);
            btnExit.TabIndex = 17;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // AnimalEntryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 431);
            Controls.Add(btnExit);
            Controls.Add(RecScoreNumericUpDown);
            Controls.Add(AgeNumericUpDown);
            Controls.Add(btnAddAnimal);
            Controls.Add(speciesTxt);
            Controls.Add(nameTxt);
            Controls.Add(animalIDTxt);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AnimalEntryForm";
            Text = "AnimalEntryForm";
            Load += AnimalEntryForm_Load;
            ((System.ComponentModel.ISupportInitialize)AgeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RecScoreNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox animalIDTxt;
        private TextBox nameTxt;
        private TextBox speciesTxt;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Button btnAddAnimal;
        private NumericUpDown AgeNumericUpDown;
        private NumericUpDown RecScoreNumericUpDown;
        private Button btnExit;
    }
}