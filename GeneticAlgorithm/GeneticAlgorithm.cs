using System;

namespace GeneticLibrary
{
    public class GeneticAlgorithm : IGeneticAlgorithm
    {
        private Random rand;

        private IGeneration _currentGeneration;
        private IGeneration _lastGeneration;

        private static long  _generationCount = 0;
        private int? _seed; // What is the seed's value 

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
                return _currentGeneration;
            }
        }

        public FitnessEventHandler FitnessCalculation { get; }

        private IGeneration GenerateNextGeneration() 
        {
            IChromosome[] newPopulation = new IChromosome[_currentGeneration.NumberOfChromosomes];
            int tempIndex = 0;
            while(_currentGeneration.NumberOfChromosomes % 2 == 0) {
                IChromosome[] children = _currentGeneration[tempIndex].Reproduce(_currentGeneration[tempIndex+1], MutationRate);
                newPopulation[tempIndex] = children[tempIndex];
                newPopulation[tempIndex+1] = children[tempIndex+1];
                tempIndex += 2;
            }
            IGeneration nextGen = new Generation(newPopulation);
            return nextGen;
        }

        public IGeneration GenerateGeneration()
        {
           if(_currentGeneration == null) 
           {
                _currentGeneration = new Generation(this, FitnessCalculation, _seed); // seed must be generationCount 
                _generationCount +=1;
           }
           else
           {
               _lastGeneration = _currentGeneration;
               _currentGeneration = new Generation(this, FitnessCalculation, _seed);
               _generationCount +=1;
           }
           return _currentGeneration;
        }
    }
}


