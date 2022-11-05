using System;
using System.Linq;

namespace GeneticLibrary {
  public class TempGeneration: IGenerationDetails, IGeneration {
    private IChromosome[] Chromosomes;
    private int? _seed;
    private Random rnd;

    public TempGeneration(IGeneticAlgorithm _geneticAlgorithm, FitnessEventHandler _fitnessEvt, int? seed = null) {
      GeneticAlgorithm = _geneticAlgorithm;
      FitnessEventHandler = _fitnessEvt;
      rnd = new Random(seed.GetValueOrDefault());
    }

    public TempGeneration(IChromosome[] _chromosomes) {
      Chromosomes = new Chromosome[_chromosomes.Length];
      for (int i = 0; i < _chromosomes.Length;i++) {
        Chromosomes[i] = _chromosomes[i];
      }
    }

    public IGeneticAlgorithm GeneticAlgorithm {get;}

    public FitnessEventHandler FitnessEventHandler {get;}

    public double AverageFitness {
      get {
        double _fitnessAvg = 0;
        foreach (var chromosome in Chromosomes) {
          _fitnessAvg += (chromosome as Chromosome).Fitness;
        }
        return _fitnessAvg / Chromosomes.Length;
      }
    }

    public double MaxFitness {
      get {
        double _maxFitness = (Chromosomes[0] as Chromosome).Fitness;
        for (int i = 1; i < Chromosomes.Length; i++) {
          if (_maxFitness < (Chromosomes[i] as Chromosome).Fitness) {
            _maxFitness = (Chromosomes[i] as Chromosome).Fitness;
          }
        }
        return _maxFitness;
      }
    }

    public long NumberOfChromosomes {
      get {
        return Chromosomes.Length;
      }
    }

    public IChromosome this[int index] {
      get { return Chromosomes[index]; }
      set { Chromosomes[index] = value; }
    }

    public IChromosome SelectParent() {
      
    }

    public void EvaluateFitnessOfPopulation() {
      double evaluationFitness = 0;
      for (int i = 0; i < Chromosomes.Length; i++)
      {
        double fitnessEvent = FitnessEventHandler.Invoke(Chromosomes[i], this);
        (Chromosomes[i] as Chromosome).Fitness =  fitnessEvent;
        evaluationFitness += Chromosomes[i].Fitness;
      }
      double avarage = evaluationFitness /  GeneticAlgorithm.NumberOfTrials;
    }
  }
}