using System;

namespace GeneticLibrary
{
    public class GeneticAlgorithm : IGeneticAlgorithm
    {
        private Random rand;
        private Random random;

        private IGeneration _currentGeneration;

        // private IGeneration _nextGeneration;

        private static long _generationCount = 0;
        private int? _seed; // What is the seed's value 

        public GeneticAlgorithm(int populationSize, int numberOfGenes, int lengthOfGenes, double mutationRate,
            double eliteRate,int numberOfTrials, FitnessEventHandler fitnessFunc, int? seed = null)
        {
            // maximum number of trials based on her instruction
            if (populationSize > 200)
            {
                throw new ArgumentException("Population size must be less than or equal to 200.");
            }
            PopulationSize = populationSize;
            NumberOfGenes = numberOfGenes;
            LengthOfGene = lengthOfGenes;
            MutationRate = mutationRate;
            EliteRate = eliteRate;
            NumberOfTrials = numberOfTrials;
            FitnessCalculation = fitnessFunc;
            random = new Random();
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

        private Generation GenerateNextGeneration()
        {
            Chromosome[] newPopulation = new Chromosome[_currentGeneration.NumberOfChromosomes];

            int elites =(int) (EliteRate * PopulationSize);
            if (elites % 2 == 1) elites+=1;

            for (int i = 0, z = PopulationSize - 1; i < elites; i++)
            {
                newPopulation[i] = new Chromosome(_currentGeneration[z--] as Chromosome);
            }

            
            for (int i = elites; i < PopulationSize; i++)
            {
                int indexp1 = random.Next(0, elites);
                int indexp2 = random.Next(0, elites);
                
                //chk indx1 nad index2
               Chromosome[] tmpChildren  = ( newPopulation[indexp1].Reproduce(newPopulation[indexp2],MutationRate) as Chromosome[]);
               newPopulation[i] = tmpChildren[0] ;
            }

            return new Generation(newPopulation,this);
        }

        public IGeneration GenerateGeneration()
        {
            Console.WriteLine(_generationCount);
            if (_currentGeneration is null)
            {
                _currentGeneration = new Generation(this, FitnessCalculation, _seed);
                (_currentGeneration as Generation)!.EvaluateFitnessOfPopulation();
                _generationCount += 1;
            }
            else
            {
                 Console.WriteLine(_generationCount);
 
                 _currentGeneration = GenerateNextGeneration();
                (_currentGeneration as Generation).EvaluateFitnessOfPopulation();
                _generationCount += 1;
            }

            return _currentGeneration;
        }
    }
}