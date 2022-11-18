using System;
using System.Linq;

namespace GeneticLibrary {
  public class Generation: IGenerationDetails {
    private IChromosome[] _chromosomes;
    private int? _seed;
    public event FitnessEventHandler FitnessEvt; 
    private Random rnd;
    private double _fitnessAvg;
    private double _maxFitness;
    public IGeneticAlgorithm _geneticAlgorithm;

    public Generation(IGeneticAlgorithm _geneticAlgorithm, FitnessEventHandler fitnessEvt, int? seed = null) 
    {
      GeneticAlgorithm = _geneticAlgorithm;
      FitnessEvt = fitnessEvt;
      rnd = new Random(seed.GetValueOrDefault());
      _chromosomes = new IChromosome[GeneticAlgorithm.PopulationSize];
      
      for( int i =0 ; i < _chromosomes.Length;i++) {
        _chromosomes[i] = new Chromosome(GeneticAlgorithm.NumberOfGenes, GeneticAlgorithm.LengthOfGene);
      }
    }

    public Generation(IChromosome[] chromosomes, IGeneticAlgorithm geneticAlgorithm)
    {
      _chromosomes = new Chromosome[chromosomes.Length];
      GeneticAlgorithm = geneticAlgorithm;
      FitnessEvt = _geneticAlgorithm.FitnessCalculation; //
      
      for (int i = 0; i < chromosomes.Length;i++) {
        _chromosomes[i] = new Chromosome(chromosomes[i]);   
      }
    }

    public IGeneticAlgorithm GeneticAlgorithm {get;}
       
    public double AverageFitness 
    {
      get { return _fitnessAvg;
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
        return _chromosomes.Length;
      }
    }

    public IChromosome this[int index] {
      get { return _chromosomes[index]; }
    }

    public IChromosome SelectParent() 
    {
      // int eliterate = (int)(_geneticAlgorithm.PopulationSize * _geneticAlgorithm.EliteRate); //

      // These two are seems to elite rate
      int pointA = rnd.Next(_chromosomes.Length); 
      int pointB = rnd.Next(pointA, _chromosomes.Length);
      
      IChromosome parent = null;
      for (int i =pointA +1 ; i<pointB ;i++) {
        if (_chromosomes[i-1].CompareTo(_chromosomes[i]) > 0) {
          parent = _chromosomes[i-1];
        }
      }
      
      // return  _chromosomes[rnd.Next(20)]; 
      return parent;
    }

    public void EvaluateFitnessOfPopulation() {
      double fitnessEvent = 0;
      for (int i = 0; i < _chromosomes.Length; i++)
      {
        
        for (int j = 0; j < GeneticAlgorithm.NumberOfTrials; j++)
        {
          fitnessEvent += this.FitnessEvt!.Invoke(_chromosomes[j], this); // Potential problem is here
        }
        fitnessEvent = fitnessEvent / GeneticAlgorithm.NumberOfTrials;
        (_chromosomes[i] as Chromosome).Fitness =  fitnessEvent;
        _fitnessAvg+=fitnessEvent;
      }
      _fitnessAvg = _fitnessAvg / _chromosomes.Length;//this would be average Whole chromosome
      Array.Sort(_chromosomes);
      Array.Reverse(_chromosomes);
      _maxFitness = _chromosomes[0].Fitness;
    }
  }
}