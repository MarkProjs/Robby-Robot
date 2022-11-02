using System;
using System.Linq;


namespace GeneticLibrary
{
  public class Generation : IGeneration {
    public IChromosome[] Chromosomes { get; protected set; }

    public IChromosome this[int index] {
      get { return Chromosomes[index]; }
      set { Chromosomes[index] = value; }
    }

    public double AverageFitness => Chromosomes.Average(x => x.Fitness);

    public double MaxFitness => Chromosomes.Max(x => x.Fitness);

    public long NumberOfChromosomes => Chromosomes.Length;
  }

  internal class GenerationDetails : Generation {
    public GenerationDetails( IGeneticAlgorithm geneticAlgorithm,
      FitnessEventHandler fitnessEventHandler, int seed = 0) {

        //??????????????? to do this constructor

    }

    //deep copy 
    public GenerationDetails(IGeneration generation) : base() {
      Chromosomes = new Chromosome[(int)generation.NumberOfChromosomes];
        for (var i = 0; i < Chromosomes.Length; i++) {
        Chromosomes[i] = generation[i];
        }
    }


    public IChromosome SelectParent() {
      //??????????????? to do this constructor
      
    }

    public void EvaluateFitnessOfPopulation() {
      //??????????????? to do this constructor
    }
  }
}