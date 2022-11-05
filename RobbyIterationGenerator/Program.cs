using System;
using GeneticLibrary;

namespace RobbyIterationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Chromosome chromosome = new Chromosome(20, 6, 6);
            Chromosome spouse = new Chromosome(20, 6, 6);

            IChromosome[] nextGeneration = chromosome.Reproduce(spouse, 0);

            Chromosome nextGenChromosome = new Chromosome(nextGeneration[1]);
            for (int i = 0; i < chromosome.Length; i++)
            {
                Console.WriteLine("Chromosome "+i +" "+chromosome[i]);
                Console.WriteLine("Spouse "+i+" "+spouse[i]);
                Console.WriteLine("-----------");
            }
         //    Console.WriteLine("Hello World!");
         //
         //    int[] list = {98, 23, 97, 36, 77};
         // Console.WriteLine("Original Unsorted List");
         // foreach (int i in list) {
         //    Console.Write(i + " ");
         // }
         // Array.Sort(list);
         // Console.WriteLine("sorted List");
         // for(int i=0; i<list.Length; i++) {
         //    Console.Write(list[i] + " ");
         // }

        }
    }
}
