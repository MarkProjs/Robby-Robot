using System;

namespace GeneticLibrary
{
    class GeneticAlgorithm : IGeneticAlgorithm
    {
        public GeneticAlgorithm(){
            
        }

        public int PopulationSize => throw new NotImplementedException();

        public int NumberOfGenes => throw new NotImplementedException();

        public int LengthOfGene => throw new NotImplementedException();

        public double MutationRate => throw new NotImplementedException();

        public double EliteRate => throw new NotImplementedException();

        public int NumberOfTrials => throw new NotImplementedException();

        public long GenerationCount => throw new NotImplementedException();

        public IGeneration CurrentGeneration => throw new NotImplementedException();

        public FitnessEventHandler FitnessCalculation => throw new NotImplementedException();

        public IGeneration GenerateGeneration()
        {
            throw new NotImplementedException();
        }
    }
}
