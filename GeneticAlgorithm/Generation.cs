using System;
using System.Linq;


namespace GeneticLibrary
{
  public class Generation : IGenerationDetails {

    public IGeneticAlgorithm GenericAlgorithm {get; }
    public IChromosome[] Chromosomes { get;  set; }
    private FitnessEventHandler _fitnessEventHandler;

    public Generation( IGeneticAlgorithm geneticAlgorithm,
      FitnessEventHandler fitnessEventHandler, int? seed = null) {
        _fitnessEventHandler = fitnessEventHandler;
        GenericAlgorithm = geneticAlgorithm;
    }

    public Generation(IGeneration generation) : base() {
      Chromosomes = new Chromosome[(int)generation.NumberOfChromosomes];
         for (var i = 0; i < Chromosomes.Length; i++) {
        Chromosomes[i] = generation[i];
        }
    }

    public IChromosome this[int index] {
      get { return Chromosomes[index]; }
      set { Chromosomes[index] = value; }
    }

    public double AverageFitness => Chromosomes.Average(x => x.Fitness);

    public double MaxFitness => Chromosomes.Max(x => x.Fitness);

    public long NumberOfChromosomes => Chromosomes.Length;

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
      double avarage = evaluationFitness /  GenericAlgorithm.NumberOfTrials;
    }
  }
 }

