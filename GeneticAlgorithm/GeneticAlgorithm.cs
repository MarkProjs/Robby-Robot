using System;

namespace GeneticLibrary
{
    class GeneticAlgorithm : IGeneticAlgorithm
    {
        private Random rand;

        public GeneticAlgorithm(int populationSize, int numberOfGenes, int lengthOfGenes, double mutationRate, double eliteRate,
            int numberOfTrials, FitnessEventHandler fitnessFunc,int? seed = null)
        {
            PopulationSize = populationSize;
            NumberOfGenes = numberOfGenes;
            LengthOfGene = lengthOfGenes;
            MutationRate = mutationRate;
            EliteRate = eliteRate;
            NumberOfTrials = numberOfTrials;
            //GenerationCount = ??;
            FitnessCalculation = fitnessFunc;
            rand = new Random(seed.GetValueOrDefault());
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
            rand
        }
    }
}

