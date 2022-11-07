using System;
using System.Linq;


namespace GeneticLibrary
{
  public class Generation : IGenerationDetails {

    public IGeneticAlgorithm GenericAlgorithm {get; }
    public IChromosome[] Chromosomes { get;  set; }
    public double AverageFitness => Chromosomes.Average(x => x.Fitness);
    public double MaxFitness => Chromosomes.Max(x => x.Fitness);
    public long NumberOfChromosomes => Chromosomes.Length;
    FitnessEventHandler _fitnessEventHandler;
    public IChromosome this[int index] {
      get { return Chromosomes[index]; }
      set { Chromosomes[index] = value; }
    }

    public Generation(IGeneticAlgorithm geneticAlgorithm, FitnessEventHandler fitnessEventHandler, int? seed = null) {
        _fitnessEventHandler = fitnessEventHandler;
        GenericAlgorithm = geneticAlgorithm;
    }

    public Generation(IChromosome[] newChromosomes){
      newChromosomes  = new Chromosome[Chromosomes.Length];
      for (int i = 0; i < newChromosomes.Length; i++)
      {
       Chromosomes[i] = newChromosomes[i];
      }
    }


    public IChromosome SelectParent()
    {
      Array.Sort(Chromosomes);
      Array.Reverse(Chromosomes);
      return Chromosomes[0];
    }

    public void EvaluateFitnessOfPopulation() {
      double evaluationFitness = 0;
      for (int i = 0; i < Chromosomes.Length; i++)
      {
        double fitnessEvent = _fitnessEventHandler.Invoke(Chromosomes[i], this);
        (Chromosomes[i] as Chromosome).Fitness =  fitnessEvent;
        evaluationFitness += Chromosomes[i].Fitness;
      }
      double avarage = evaluationFitness / GenericAlgorithm.NumberOfTrials;
    }
  }
 }

