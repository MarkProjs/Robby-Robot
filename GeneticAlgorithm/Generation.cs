using System;
using System.Linq;

namespace GeneticLibrary {
  public class TempGeneration: IGenerationDetails, IGeneration {
    private IChromosome[] Chromosomes;
    private int? _seed;
    public event FitnessEventHandler _fitnessEvt; 
    private Random rnd;

    private double _fitnessAvg;
    private double _maxFitness;

    public TempGeneration(IGeneticAlgorithm _geneticAlgorithm, FitnessEventHandler FitnessEvt, int? seed = null) 
    {
      GeneticAlgorithm = _geneticAlgorithm;
      _fitnessEvt = FitnessEvt;
      rnd = new Random(seed.GetValueOrDefault());

      Chromosomes = new IChromosome[GeneticAlgorithm.PopulationSize];
      //loading the Chromosome array
      for( int i =0 ; i < Chromosomes.Length;i++) {
        Chromosomes[i] = new Chromosome(GeneticAlgorithm.NumberOfGenes, GeneticAlgorithm.LengthOfGene);
      }
    }

    public TempGeneration(IChromosome[] _chromosomes) {
      Chromosomes = new IChromosome[_chromosomes.Length];
      for (int i = 0; i < _chromosomes.Length;i++) {
        Chromosomes[i] = _chromosomes[i];
      }
    }

    public IGeneticAlgorithm GeneticAlgorithm {get;}

      
    public double AverageFitness 
    {
      get {
        // double _fitnessAvg = 0;
        // foreach (var chromosome in Chromosomes) {
        //   _fitnessAvg += (chromosome as Chromosome).Fitness;
        // }
        // return _fitnessAvg / Chromosomes.Length;
       return _fitnessAvg;
         
      }
    }

    public double MaxFitness 
    {
      get 
      {
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

    public IChromosome SelectParent() 
    {
      int pointA = rnd.Next(Chromosomes.Length);
      int pointB = rnd.Next(pointA, Chromosomes.Length);

      IChromosome parent = null;
      for (int i =pointA +1 ; i<pointB ;i++) {
        if (Chromosomes[i-1].CompareTo(Chromosomes[i]) > 0) {
          parent = Chromosomes[i-1];
        }
      }
      return parent;
    }

    public void EvaluateFitnessOfPopulation() {
      for (int i = 0; i < Chromosomes.Length; i++)
      {
         double fitnessEvent = 0;
        for (int j = 0; j < GeneticAlgorithm.NumberOfTrials; j++)
          {
          fitnessEvent += this._fitnessEvt.Invoke(Chromosomes[i], this);
          // evaluationFitness += Chromosomes[j].Fitness; dont need for now 
          }
        fitnessEvent = fitnessEvent / GeneticAlgorithm.NumberOfTrials;
        (Chromosomes[i] as Chromosome).Fitness =  fitnessEvent;
        _fitnessAvg+=fitnessEvent;
      }
      _fitnessAvg = _fitnessAvg / Chromosomes.Length;
      Array.Sort(Chromosomes);
      Array.Reverse(Chromosomes);
      _maxFitness = Chromosomes[0].Fitness;//this would be average Whole chromosome
    }
  }
}