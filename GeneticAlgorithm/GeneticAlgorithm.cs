using System;

namespace GeneticLibrary
{
    class GeneticAlgorithm : IGeneticAlgorithm
    {
     

        private Random rand;

        public GeneticAlgorithm(int populationSize, int numberOfGenes, int lengthOfGenes, double mutationRate, double eliteRate,
            int numberOfTrials, FitnessEventHandler fitnessFunc, int? seed = null)
        {
            // maximum number of trials based on her instruction
            if(populationSize>=1000){
                throw new ArgumentException("Population size must be less than or equal to 1000.");
            }else
            {
                PopulationSize = populationSize;
                NumberOfGenes = numberOfGenes;
                LengthOfGene = lengthOfGenes;
                MutationRate = mutationRate;
                EliteRate = eliteRate;
                NumberOfTrials = numberOfTrials;
                FitnessCalculation = fitnessFunc;
                rand = new Random(seed.GetValueOrDefault());
            }
        }

        public int PopulationSize { get; }

        public int NumberOfGenes { get; }

        public int LengthOfGene { get; }

        public double MutationRate { get; }

        public double EliteRate { get; }

        public int NumberOfTrials { get; }

        public long GenerationCount { get; }

        public IGeneration CurrentGeneration { get; }

        public FitnessEventHandler FitnessCalculation { get; }

        public IGeneration GenerateGeneration()
        {
            rand = new Random();
            Generation previousGeneration;
            if (GenerationCount == 0)
            {
                return CurrentGeneration;
            }
            else
            {
                for (int i = 0; i < PopulationSize; i++)
                {
                    EvalChromosomeFitness();
                }              
            }

        
            return null;
        }
        public void EvalChromosomeFitness(){

        }

    }
}

