namespace ShakespeareGeneticTest2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblBestGuess = new System.Windows.Forms.Label();
            this.lblGeneration = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lstBoxPopulation = new System.Windows.Forms.ListBox();
            this.lblTotalFitness = new System.Windows.Forms.Label();
            this.txtSearchPhrase = new System.Windows.Forms.TextBox();
            this.txtPopulation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // lblBestGuess
            // 
            this.lblBestGuess.AutoSize = true;
            this.lblBestGuess.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBestGuess.Location = new System.Drawing.Point(15, 38);
            this.lblBestGuess.Name = "lblBestGuess";
            this.lblBestGuess.Size = new System.Drawing.Size(131, 21);
            this.lblBestGuess.TabIndex = 1;
            this.lblBestGuess.Text = "Best guess:";
            // 
            // lblGeneration
            // 
            this.lblGeneration.AutoSize = true;
            this.lblGeneration.Location = new System.Drawing.Point(16, 99);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(67, 13);
            this.lblGeneration.TabIndex = 2;
            this.lblGeneration.Text = "Generations:";
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(16, 142);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(65, 13);
            this.lblPercentage.TabIndex = 3;
            this.lblPercentage.Text = "Percentage:";
            // 
            // lstBoxPopulation
            // 
            this.lstBoxPopulation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBoxPopulation.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxPopulation.FormattingEnabled = true;
            this.lstBoxPopulation.ItemHeight = 14;
            this.lstBoxPopulation.Location = new System.Drawing.Point(468, 38);
            this.lstBoxPopulation.Name = "lstBoxPopulation";
            this.lstBoxPopulation.Size = new System.Drawing.Size(320, 382);
            this.lstBoxPopulation.TabIndex = 4;
            // 
            // lblTotalFitness
            // 
            this.lblTotalFitness.AutoSize = true;
            this.lblTotalFitness.Location = new System.Drawing.Point(16, 192);
            this.lblTotalFitness.Name = "lblTotalFitness";
            this.lblTotalFitness.Size = new System.Drawing.Size(83, 13);
            this.lblTotalFitness.TabIndex = 5;
            this.lblTotalFitness.Text = "Average fitness:";
            // 
            // txtSearchPhrase
            // 
            this.txtSearchPhrase.Location = new System.Drawing.Point(19, 282);
            this.txtSearchPhrase.Name = "txtSearchPhrase";
            this.txtSearchPhrase.Size = new System.Drawing.Size(269, 20);
            this.txtSearchPhrase.TabIndex = 6;
            this.txtSearchPhrase.Text = "To be or not to be";
            // 
            // txtPopulation
            // 
            this.txtPopulation.Location = new System.Drawing.Point(19, 349);
            this.txtPopulation.Name = "txtPopulation";
            this.txtPopulation.Size = new System.Drawing.Size(100, 20);
            this.txtPopulation.TabIndex = 7;
            this.txtPopulation.Text = "200";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Population size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Phrase to evolve to:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPopulation);
            this.Controls.Add(this.txtSearchPhrase);
            this.Controls.Add(this.lblTotalFitness);
            this.Controls.Add(this.lstBoxPopulation);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.lblGeneration);
            this.Controls.Add(this.lblBestGuess);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblBestGuess;
        private System.Windows.Forms.Label lblGeneration;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.ListBox lstBoxPopulation;
        private System.Windows.Forms.Label lblTotalFitness;
        private System.Windows.Forms.TextBox txtSearchPhrase;
        private System.Windows.Forms.TextBox txtPopulation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

