using System;
using System.Diagnostics.CodeAnalysis;

namespace GeneticLibrary
{
  public class Chromosome : IChromosome
  {
    private Random rand;

    public Chromosome(int numberOfGenes, int LengthOfGene, int seed){
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

    public IChromosome[] Reproduce(IChromosome spouse, double mutationProb)
        {
            rand = new Random();
            int pointA = rand.Next((int)Length);
            int pointB = rand.Next(pointA, (int)Length);
            int[] p1Tmp = spouse.Genes[pointA..pointB]; //p1
            int[] p2Tmp = this.Genes[pointA..pointB]; //p2


            
            // mutation of the child
            double rndDouble = rand.NextDouble();
            for (int i = 0; i < Genes.Length; i++)
            {
                if (mutationProb >= rndDouble)
                {
                    int rndInt = rand.Next((int)Length);
                }
            }

        }


    public double Fitness { get; set; }

    public int[] Genes { get; }

    // The Length = 243 
    public long Length { get; }

}
}