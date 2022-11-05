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
          _fitnessAvg += chromosome.Fitness;
        }
        return _fitnessAvg / Chromosomes.Length;
      }
    }

    public double MaxFitness {
      get {
        double _maxFitness = 0;
        for (int i = 0; i < Chromosomes.Length; i++) {

        }
        _maxFitness = Chromosomes[0].Fitness;

        return _maxFitness;
      }
    }

    public long NumberOfChromosomes {
      get {
        return Chromosomes.Length;
      }
    }
  }
}