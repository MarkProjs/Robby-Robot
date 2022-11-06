using System;

namespace GeneticLibrary
{
    class GeneticAlgorithm : IGeneticAlgorithm
    {
        private Random rand;

        private IGeneration _generation;

        private long _generationCount = 0;
        private int? _seed;

        public GeneticAlgorithm(int populationSize, int numberOfGenes, int lengthOfGenes, double mutationRate, double eliteRate,
            int numberOfTrials, FitnessEventHandler fitnessFunc, int? seed = null)
        {
            PopulationSize = populationSize;
            NumberOfGenes = numberOfGenes;
            LengthOfGene = lengthOfGenes;
            MutationRate = mutationRate;
            EliteRate = eliteRate;
            NumberOfTrials = numberOfTrials;
            FitnessCalculation = fitnessFunc;
            _seed = seed;
            rand = new Random(_seed.GetValueOrDefault());
        }

        public int PopulationSize { get; }

        public int NumberOfGenes { get; }

        public int LengthOfGene { get; }

        public double MutationRate { get; }

        public double EliteRate { get; }

        public int NumberOfTrials { get; }

        public long GenerationCount 
        { 
            get {
                return _generationCount;
            }
        }

        public IGeneration CurrentGeneration 
        { 
            get 
            {
                return _generation;
            }
        }

        public FitnessEventHandler FitnessCalculation { get; }

        private IGeneration GenerateNextGeneration() 
        {
            

        }

        public IGeneration GenerateGeneration()
        {
           if(_generation == null) 
           {
                _generation = new Generation(this, FitnessCalculation, _seed);
           }
           else 
           {
                _generation = GenerateGeneration();
           }
           return _generation;
        }
    }
}

