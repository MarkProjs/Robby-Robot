using System;


namespace GeneticLibrary
{
  public class Generation : IGeneration
  {
    public IChromosome this[int index] => throw new NotImplementedException();

    public double AverageFitness => throw new NotImplementedException();

    public double MaxFitness => throw new NotImplementedException();

    public long NumberOfChromosomes => throw new NotImplementedException();
  }
}