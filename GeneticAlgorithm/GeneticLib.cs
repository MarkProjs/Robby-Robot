using GeneticLibrary;
using System;
namespace GeneticLibrary
{
    public static class GeneticLib

    {
         public static IGeneticAlgorithm CreateGeneticAlgorithm( FitnessEventHandler fitnessCalculation, int populationSize =200, int numberOfGenes =243, 
         int lengthOfGene = 7, double mutationRate =.5, double eliteRate= .5, int numberOfTrials=200, 
         int? seed = null) {
            return new GeneticAlgorithm(populationSize, numberOfGenes, lengthOfGene, 
            mutationRate, eliteRate, numberOfTrials, fitnessCalculation, seed);
        }
    }
}