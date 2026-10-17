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
            label1.Location = new Point(40, 46);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Animal ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 89);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 127);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 3;
            label3.Text = "Species";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 170);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 2;
            label4.Text = "Age";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 214);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 5;
            label5.Text = "Recovery Score";
            // 
            // animalIDTxt
            // 
            animalIDTxt.Location = new Point(144, 46);
            animalIDTxt.Name = "animalIDTxt";
            animalIDTxt.Size = new Size(120, 23);
            animalIDTxt.TabIndex = 7;
            // 
            // nameTxt
            // 
            nameTxt.Location = new Point(144, 86);
            nameTxt.Name = "nameTxt";
            nameTxt.Size = new Size(120, 23);
            nameTxt.TabIndex = 8;
            // 
            // speciesTxt
            // 
            speciesTxt.Location = new Point(144, 124);
            speciesTxt.Name = "speciesTxt";
            speciesTxt.Size = new Size(120, 23);
            speciesTxt.TabIndex = 9;
            // 
            // btnAddAnimal
            // 
            btnAddAnimal.Location = new Point(40, 272);
            btnAddAnimal.Name = "btnAddAnimal";
            btnAddAnimal.Size = new Size(102, 23);
            btnAddAnimal.TabIndex = 14;
            btnAddAnimal.Text = "Add  Animal";
            btnAddAnimal.UseVisualStyleBackColor = true;
            btnAddAnimal.Click += btnAddAnimal_Click;
            // 
            // AgeNumericUpDown
            // 
            AgeNumericUpDown.Location = new Point(144, 168);
            AgeNumericUpDown.Name = "AgeNumericUpDown";
            AgeNumericUpDown.Size = new Size(120, 23);
            AgeNumericUpDown.TabIndex = 15;
            // 
            // RecScoreNumericUpDown
            // 
            RecScoreNumericUpDown.Location = new Point(144, 206);
            RecScoreNumericUpDown.Name = "RecScoreNumericUpDown";
            RecScoreNumericUpDown.Size = new Size(120, 23);
            RecScoreNumericUpDown.TabIndex = 16;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(165, 272);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(99, 23);
            btnExit.TabIndex = 17;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // AnimalEntryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 323);
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
            Name = "AnimalEntryForm";
            Text = "AnimalEntryForm";
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