using System;
using System.Diagnostics.CodeAnalysis;

namespace GeneticLibrary
{
  public class Chromosome : IChromosome
  {
    private Random rand;

    public double Fitness { get; set; }

    public int[] Genes { get; }

    // The Length = 243 
    public long Length { get; }
    public Chromosome(int numberOfGenes, int LengthOfGene, int seed = 0){
      Genes = new int[numberOfGenes];
      rand = new Random(seed);
      for (int i = 0; i < numberOfGenes; i++)
      {
        int rndInt = rand.Next(LengthOfGene);
        Genes[i] = rndInt;
      }
      Fitness = 0;
    }

    //deep copy of the _genes
    public Chromosome(IChromosome choromosome){
      Fitness = choromosome.Fitness;
      Genes = new int[choromosome.Length];
    }

    //implement indxer
    public int this[int index] {
      get {return Genes[index];}
      set {Genes[index]=value;}
    }

    
    public int CompareTo([AllowNull] IChromosome other) {
      if (Fitness == other.Fitness) {
        return 0;
      }
      else if (Fitness > other.Fitness) {
        return 1;
      }
      else {
        return -1;
      }
    }

    public IChromosome[] Reproduce(IChromosome spouse, double mutationProb){
      rand = new Random();
      int pointA = rand.Next((int)Length);
      int pointB = rand.Next(pointA, (int)Length);
      int[] p1Tmp = spouse.Genes[pointA..pointB]; //p1
      int[] p2Tmp = this.Genes[pointA..pointB]; //p2

      int startingPoint = 0;
            int cuttingPoint = rd.Next(startingPoint+1,a.Length);
            Console.WriteLine(cuttingPoint);
            while (cuttingPoint <a.Length)
            {
                SwapArray(a,b,startingPoint,cuttingPoint);
                startingPoint = cuttingPoint;
                cuttingPoint = rd.Next(cuttingPoint,a.Length-1);   
            }
        }

        public static void SwapArray(int[] p1, int[] p2, int startingPoint, int  cuttingPoint)
        {
            int[] p1RemovedArray = p1[startingPoint..cuttingPoint];
            int[] p2RemovedArray = p2[startingPoint..cuttingPoint];
            int[] p1SourceArray = p1[cuttingPoint..p1.Length];
            int[] p2SourceArray = p2[cuttingPoint..p2.Length];

            int[] c1 = p1SourceArray.Concat(p2RemovedArray).ToArray();
            int[] c2 = p2SourceArray.Concat(p1RemovedArray).ToArray();
            Console.WriteLine("Child One");
            PrintArray(c1);      
            Console.WriteLine("Child Two");
            PrintArray(c2);
   
        }

      

            
      // mutation of the child
      double rndDouble = rand.NextDouble();
      for (int i = 0; i < Genes.Length; i++)
      {
        if (mutationProb >= rndDouble)
        {
          int rndInt = rand.Next((int)Length);
        }
      }
      return null; //??????????

      }
  }
}
