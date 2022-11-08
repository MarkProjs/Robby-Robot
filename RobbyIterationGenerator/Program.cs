using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using GeneticLibrary;

namespace RobbyIterationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
 
            IChromosome chromosome = new Chromosome(20, 6, 6);
            IChromosome spouse = new Chromosome(chromosome);

            IChromosome[] nextGeneration = chromosome.Reproduce(spouse, 100);

            // Chromosome nextGenChromosome = new Chromosome(nextGeneration[1]);
            for (int i = 0; i < nextGeneration.Length; i++)
            {
                Console.WriteLine("Parent "+i);
                for (int j = 0; j < chromosome.Length; j++)
                {
                    Console.WriteLine("Chromosome "+j +" "+nextGeneration[i].Genes[j]);
                    Console.WriteLine("Spouse "+j+" "+spouse.Genes[j]);
                    Console.WriteLine("-----------");
                }
              
            }
            // GeneticLibrary gens = new GeneticLibrary();
            // IGeneticAlgorithm algorithm = new GeneAlgorithm(gens.PopulationSize, gens.NumberOfGenes,gens.LengthOfGene,gens.MutationRate,gens.EliteRate,gens.NumberOfTrials,gens.FitnessEventHandler,0);
            // IGeneration current = new Generation();
            //    Console.WriteLine("Hello World!");
            //
   
        }
    }
}