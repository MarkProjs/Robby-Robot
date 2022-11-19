using GeneticLibrary;
using System;
namespace GeneticLibrary
{
    public static class GeneticLib

    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="populationSize"></param>
        /// <param name="numberOfGenes"></param>
        /// <param name="lengthOfGene"></param>
        /// <param name="mutationRate"></param>
        /// <param name="eliteRate"></param>
        /// <param name="numberOfTrials"></param>
        /// <param name="fitnessCalculation"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
         public static IGeneticAlgorithm CreateGeneticAlgorithm(int populationSize , int numberOfGenes, 
         int lengthOfGene, double mutationRate, double eliteRate, int numberOfTrials, FitnessEventHandler fitnessCalculation,
         int? seed = null) {
            return new GeneticAlgorithm(populationSize, numberOfGenes, lengthOfGene, 
            mutationRate, eliteRate, numberOfTrials, fitnessCalculation, seed);
        }
    }
}