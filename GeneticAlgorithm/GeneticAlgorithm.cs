using System;

namespace GeneticLibrary
{
    public class GeneticAlgorithm : IGeneticAlgorithm
    {
        private Random rand;

        private IGeneration _currentGeneration;

        private IGeneration _nextGeneration;
        private IGeneration _previousGeneration;

 
        private static long _generationCount = 0;
        private int? _seed; // What is the seed's value 

        public GeneticAlgorithm(int populationSize, int numberOfGenes, int lengthOfGenes, double mutationRate,
            double eliteRate,int numberOfTrials, FitnessEventHandler fitnessFunc, int? seed = null)
        {
            // maximum number of trials based on her instruction
            if (populationSize > 200)
            {
                throw new ArgumentException("Population size must be less than or equal to 1000.");
            }
            PopulationSize = populationSize;
            NumberOfGenes = numberOfGenes;
            LengthOfGene = lengthOfGenes;
            MutationRate = mutationRate;
            EliteRate = eliteRate;
            NumberOfTrials = numberOfTrials;
            FitnessCalculation = fitnessFunc;
            rand = new Random(seed.GetValueOrDefault());
        }

        public int PopulationSize { get; }

        public int NumberOfGenes { get; }

        public int LengthOfGene { get; }

        public double MutationRate { get; }

        public double EliteRate { get; }

        public int NumberOfTrials { get; }

        public long GenerationCount
        {
            get { return _generationCount; }
        }

        public IGeneration CurrentGeneration
        {
            get { return _currentGeneration; }
        }

        public FitnessEventHandler FitnessCalculation { get; }

        private IGeneration GenerateNextGeneration()
        {
            IChromosome[] newPopulation = new Chromosome[_currentGeneration.NumberOfChromosomes];

            int elites =(int) (EliteRate * PopulationSize);
            if (elites % 2 == 1) elites+=1;
            for (int i = 0; i < elites; i++)
            {
                newPopulation[i] = new Chromosome(((IGenerationDetails)_currentGeneration).SelectParent());
            }

            Random  random = new Random();
            for (int i = elites; i < PopulationSize; i++)
            {
                int indexp1 = random.Next(0, elites);
                int indexp2 = random.Next(0, elites);
                //chk indx1 nad index2
               IChromosome[] tmpChildren  =  newPopulation[indexp1].Reproduce(newPopulation[indexp2],MutationRate);
               newPopulation[i] = tmpChildren[0];
               newPopulation[i+1] = tmpChildren[1];
            }

            _nextGeneration = new Generation(newPopulation);
            (_nextGeneration as Generation)?.EvaluateFitnessOfPopulation();
            return _nextGeneration;

        }

        public IGeneration GenerateGeneration()
        {
            if (_currentGeneration is null)
            {
                Console.WriteLine(_generationCount);
                _nextGeneration = new Generation(this, FitnessCalculation, _seed);
                (_nextGeneration as Generation)?.EvaluateFitnessOfPopulation();
                _generationCount += 1;
            }
            else
            {
                Console.WriteLine(_generationCount);
                _previousGeneration = _currentGeneration;
                _nextGeneration = GenerateNextGeneration();
                _generationCount += 1;
            }

            return _nextGeneration;
        }
    }
}