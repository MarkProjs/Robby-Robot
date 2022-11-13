using System;
using GeneticLibrary;
using RobbyTheRobot;

namespace RobbyIterationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            IRobbyTheRobot rtr = Robby.CreateRobby(500, 200, 200);
            rtr.GeneratePossibleSolutions("yooo");
            
            
            
            //   Chromosome ch1 = new Chromosome(20, 7,6);
            //   Chromosome ch2 = new Chromosome(20, 7,6);
            //   IChromosome[] childrenArr = ch1.Reproduce(ch2, 0);
            //   // Generation generation =  new Generation(childrenArr);
            
            // for (int i = 0; i < childrenArr[0].Genes.Length; i++)
            // {
            //    if(ch1.Genes[i] == childrenArr[0].Genes[i])
            //    {
            //        Console.WriteLine(ch1.Genes[i]);
            //        Console.WriteLine(childrenArr[0].Genes[i]);
            //    }
            // }
            // IChromosome chromosome = new Chromosome(20, 7, 6);
            // IChromosome chromosome1 = new Chromosome(20, 7, 6);
            // IChromosome spouse = new Chromosome(chromosome);
            //
            // IChromosome[] nextGeneration = chromosome.Reproduce(chromosome1, 100);
            //
            // // Chromosome nextGenChromosome = new Chromosome(nextGeneration[1]);
            // for (int i = 0; i < nextGeneration.Length; i++)
            // {
            //     Console.WriteLine("Parent "+i);
            //     for (int j = 0; j < nextGeneration.Length; j++)
            //     {
            //         if (nextGeneration[i] == null)
            //         {
            //             break;
            //         }
            //         Console.WriteLine("Chromosome "+j +" "+nextGeneration[i].Genes[j]);
            //         // Console.WriteLine("Spouse "+j+" "+spouse.Genes[j]);
            //         Console.WriteLine("-----------");
            //     }
            // }
            
            // IGeneticAlgorithm test = GeneticLib.CreateGeneticAlgorithm(200, 243, 7, 0, 0.2, 100,, 1);

            //

        }
    }
}