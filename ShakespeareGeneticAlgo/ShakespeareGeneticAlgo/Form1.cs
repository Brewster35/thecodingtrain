using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShakespeareGeneticTest2
{
    public partial class Form1 : Form
    {
        EvolutionEngine evolutionEngine;
        string target;
        int count;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            DNA dna;

            count++;

            evolutionEngine.Evolve();
            dna = evolutionEngine.Strongest;

            lblBestGuess.Text = "Best guess: " + dna.Phrase;
            lblPercentage.Text = string.Format("Percentage: {0}", dna.Fitness * 100);
            lblGeneration.Text = string.Format("Generations: {0}", count);
            lblTotalFitness.Text = string.Format("Average fitness: {0}", evolutionEngine.TotalFitness / evolutionEngine.population.Count);

            lstBoxPopulation.Items.Insert(0, dna.Phrase);

            if (dna.Phrase == target)
            {
                timer.Stop();
            }
        }

        private void RunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int totalPopulation;
            target = txtSearchPhrase.Text;
            count = 0;

            lstBoxPopulation.Items.Clear();

            totalPopulation = int.Parse(txtPopulation.Text);

            evolutionEngine = new EvolutionEngine(totalPopulation, target)
            {
                mutationRate = 0.01f
            };


            timer.Start();
        }
    }
}
