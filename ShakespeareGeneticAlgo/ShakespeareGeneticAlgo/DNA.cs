using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShakespeareGeneticTest2
{
    class DNA
    {
        public string genes;
        public string target;
        public Random random;
        public double Probability;

        public double Score
        {
            get
            {
                double score = 0;
                char a, b;

                for (int geneIndex = 0; geneIndex < genes.Length; geneIndex++)
                {
                    a = genes[geneIndex];
                    b = target.ElementAt(geneIndex);

                    if (a == b)
                    {
                        score++;
                    }
                }

                return score;
            }
        }

        public double Fitness
        {
            get
            {
                return Score / target.Length;
            }
        }

        public DNA(Random rand, string phrase)
        {
            char[] tmpGenes = new char[phrase.Length];
            random = rand;
            target = phrase;
            
            for (int i = 0; i < target.Length; i++)
            {
                tmpGenes[i] = (char)random.Next(32, 128);
            }

            genes = new string(tmpGenes);
        }

        public String Phrase
        {
            get
            {
                return genes;
            }
        }

        public DNA Crossover(DNA partner)
        {
            char[] tmpGenes = new char[this.target.Length];
            DNA child = new DNA(this.random, partner.target);

            int midpoint = random.Next(genes.Length);

            for (int geneIndex = 0; geneIndex < genes.Length; geneIndex++)
            {
                if (geneIndex > midpoint)
                {
                    tmpGenes[geneIndex] = partner.genes[geneIndex];
                }
                else
                {
                    tmpGenes[geneIndex] = genes[geneIndex];
                }
            }

            child.genes = new string(tmpGenes);

            return child;
        }

        public void Mutate(double mutationRate)
        {
            Boolean hasMutated = false;
            char[] tmpGenes = genes.ToArray();

            for (int geneIndex = 0; geneIndex < genes.Length; geneIndex++)
            {
                if (random.NextDouble() < mutationRate)
                {
                    tmpGenes[geneIndex] = (char)random.Next(32, 128);

                    hasMutated = true;
                }
            }

            if (hasMutated == true)
            {
                genes = new string(tmpGenes);
            }
        }
    }
}
