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
                return _generation;
            }
        }

        public FitnessEventHandler FitnessCalculation { get; }

        private IGeneration GenerateNextGeneration() 
        {    
            
            IChromosome[] newPopulation = new IChromosome[_generation.NumberOfChromosomes];
            int tempIndex = 0;
            while(_generation.NumberOfChromosomes % 2 == 0) {
                IChromosome[] children = _generation[tempIndex].Reproduce(_generation[tempIndex+1], MutationRate);
                newPopulation[tempIndex] = children[tempIndex];
                newPopulation[tempIndex+1] = children[tempIndex+1];
                tempIndex += 2;
            }
            IGeneration nextGen = new Generation(newPopulation);
            return nextGen;
        }

        public IGeneration GenerateGeneration()
        {
           if(_generation == null) 
           {
                _generation = new Generation(this, FitnessCalculation, _seed);
           }
           else 
           {
                _generation = GenerateNextGeneration();
           }
           _generationCount +=1;
           return _generation;
        }
        public void EvalChromosomeFitness(){

        }

    }
}


