using System;
using System.Diagnostics.CodeAnalysis;

//??????????????????????????????????????????????????????????????????--> should finish
namespace GeneticLibrary
{
  public class Chromosome : IChromosome
  {
    private int[] _genes;
    private double _fitness;
    private Random rnd;

    public Chromosome(int numberOfGenes, int LengthOfGene, int seed){
      Genes = new int[numberOfGenes];
      rnd = new Random(seed);
      for (int i = 0; i < numberOfGenes; i++)
      {
        int rndInt = rnd.Next(LengthOfGene);
        _genes[i] = rndInt;
      }
      Fitness = 0;
    }

    //deep copy of the _genes
    public Chromosome(IChromosome choromosome){
      this._fitness = choromosome.Fitness;
      this._genes = new int[choromosome.Length];
    }

    //implement indxer
    public int this[int index] {
      get {return _genes[index];}
      set {_genes[index]=value;}
    }

    public long Length {
      get {return Genes.Length;}
    } 

    public double Fitness { 
      get {return this._fitness;}
      set {_fitness = value;}
      }

    public int[] Genes { get{return _genes;} set{_genes = value;}}


    public int CompareTo([AllowNull] IChromosome other)
    {
      if ( this._fitness == other.Fitness){
        return 0;
      }else if(this._fitness > other.Fitness){
        return 1;
      }else{
        return -1;
      }
    }

    public IChromosome[] Reproduce(IChromosome spouse, double mutationProb)
    {
     rnd = new Random();
     int pointA = rnd.Next(Length);
     int pointB = rnd.Next(pointA, Length);
     spouse.Genes[pointA];//p1
     int[] tmp1 = this.Genes.slice[pointA]; //p1

      // mutation of the children
      double rndDouble = rnd.NextDouble(1);
      for (int i = 0; i < Genes.Length; i++) {
        if(mutationProb >= rndDouble){
          rnd = new Random();
          int rndInt = rnd.Next(Length);
        }
      }
      return null;
      
    }

    
  }
}