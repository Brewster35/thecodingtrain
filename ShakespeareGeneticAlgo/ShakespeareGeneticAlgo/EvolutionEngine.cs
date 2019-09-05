using System;
using System.Collections.Generic;
using System.Linq;

namespace ShakespeareGeneticTest2
{
    class EvolutionEngine
    {
        readonly DNA dna;
        public Single mutationRate;
        public List<DNA> population = new List<DNA>();
        Random rand = new Random();

        /// <summary>
        /// returns the total fitness of the population
        /// </summary>
        public double TotalFitness
        {
            get
            {
                return population.Sum(x => x.Fitness);
            }
        }

        /// <summary>
        /// returns the strongest DNA object in the population
        /// </summary>
        public DNA Strongest
        {
            get
            {
                return population.OrderByDescending(x => x.Fitness).First();
            }
        }

        /// <summary>
        /// constructor for the EvolutionEngine class
        /// </summary>
        /// <param name="size">the size of the population</param>
        /// <param name="target">the string which the evolution engine will try to guess</param>
        public EvolutionEngine(int size, string target)
        {
            for (int i = 0; i < size; i++)
            {
                dna = new DNA(rand, target);

                population.Add(dna);
            }

            SetProbability();
        }
        
        /// <summary>
        /// method to calculate the probability of each DNA object in the population based on the fitness
        /// of each DNA object. This is used in the Evolve method to determine which DNA objects to "mate" with each other
        /// </summary>
        private void SetProbability()
        {
            double probability;

            for (int i = 0; i < population.Count; i++)
            {
                probability = population[i].Fitness / TotalFitness;
                population[i].Probability = probability;
            }
        }

        /// <summary>
        /// method to "mate" the strongest DNA objects in the population and produce a new generation of DNA objects
        /// </summary>
        public void Evolve()
        {
            DNA parentA;
            DNA parentB;
            DNA child;
            List<DNA> newPopulation = new List<DNA>();

            for (int i = 0; i < population.Count; i++)
            {
                parentA = Pick();
                parentB = Pick();

                while (parentA.Phrase == parentB.Phrase)
                {
                    parentB = Pick();
                }

                child = parentA.Crossover(parentB);
                child.Mutate(mutationRate);

                newPopulation.Add(child);
            }

            population = newPopulation;

            SetProbability();
        }

        /// <summary>
        /// method to randomly pick a DNA object from the population based on it's probability
        /// </summary>
        /// <returns>a DNA object</returns>
        private DNA Pick()
        {
            int index = 0;
            double randomNumber = rand.NextDouble();

            while (randomNumber > 0)
            {
                randomNumber -= population[index].Probability;
                index++;
            }

            return population[index - 1];
        }
    }
}
