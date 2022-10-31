<<<<<<< HEAD
using GeneticLibrary;

namespace GeneticLibrary
{
    public static class GeneticLib

    {
        public static IGeneticAlgorithm CreateGeneticAlgorithm(int populationSize, int numberOfGenes, int lengthOfGene, double mutationRate, double eliteRate, int numberOfTrials, FitnessEventHandler fitnessCalculation, int? seed = null)
        {
            return new GeneticAlgorithm(populationSize, numberOfGenes, lengthOfGene, mutationRate, eliteRate, numberOfTrials, fitnessCalculation, seed);
        }
    }
=======
using GeneticLibrary;

namespace GeneticLibrary
{
    public static class GeneticLib

    {
        // public static IGeneticAlgorithm CreateGeneticAlgorithm(int populationSize, int numberOfGenes, int lengthOfGene, double mutationRate, double eliteRate, int numberOfTrials, FitnessEventHandler fitnessCalculation, int? seed = null)
        // {
        //     return new GeneticAlgorithm(populationSize, numberOfGenes, lengthOfGene, mutationRate, eliteRate, numberOfTrials, fitnessCalculation, seed);
        // }
    }
>>>>>>> 2481884d76448227c2ed73d9c6ca751aec9215f4
}