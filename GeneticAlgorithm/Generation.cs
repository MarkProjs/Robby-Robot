using System;
using System.Linq;

namespace GeneticLibrary {
  public class Generation: IGenerationDetails {
    private IChromosome[] _populations;
    private int? _seed;
    public event FitnessEventHandler FitnessEvt; 
    private Random rnd;
    private double _fitnessAvg;
    private double _maxFitness;
    IGeneticAlgorithm geneticAlgorithm;

    public Generation(IGeneticAlgorithm _geneticAlgorithm, FitnessEventHandler fitnessEvt, int? seed = null) 
    {
      geneticAlgorithm = _geneticAlgorithm;
      FitnessEvt += fitnessEvt;
      rnd = new Random(seed.GetValueOrDefault());
      _populations = new IChromosome[geneticAlgorithm.PopulationSize];
      
      for( int i =0 ; i < _populations.Length;i++) {
        _populations[i] = new Chromosome(geneticAlgorithm.NumberOfGenes, geneticAlgorithm.LengthOfGene);
      }
    }

    public Generation(Chromosome[] chromosomes, IGeneticAlgorithm geneticAlgorithmpar)
    {
      _populations = new Chromosome[chromosomes.Length];
      geneticAlgorithm = geneticAlgorithmpar;
      FitnessEvt += geneticAlgorithm.FitnessCalculation; 
      
      for (int i = 0; i < chromosomes.Length;i++) {
        _populations[i] = new Chromosome(chromosomes[i]);   
      }
    }

    public IChromosome SelectParent() 
    {
      // int eliterate = (int)(_geneticAlgorithm.PopulationSize * _geneticAlgorithm.EliteRate); //

      // These two are seems to elite rate
      int pointA = rnd.Next(0, geneticAlgorithm.PopulationSize-3); 
      int pointB = rnd.Next(pointA, _populations.Length);
      
      IChromosome parent = null;
      for (int i =pointA +1 ; i<pointB ;i++) {
        if (_populations[i-1].CompareTo(_populations[i]) > 0) {
          parent = _populations[i-1];
        }
      }
      
      return parent;
    }

    public void EvaluateFitnessOfPopulation() {
      double fitnessEvent = 0;
      for (int i = 0; i < geneticAlgorithm.PopulationSize; i++)
      {
        for (int j = 0; j < geneticAlgorithm.NumberOfTrials; j++)
        {
          fitnessEvent += this.FitnessEvt(_populations[j], this); // Potential problem is here
        }
        fitnessEvent = fitnessEvent / GeneticAlgorithm.NumberOfTrials;
        (_populations[i] as Chromosome).Fitness =  fitnessEvent;
        _fitnessAvg+=fitnessEvent;
      }
      _fitnessAvg = _fitnessAvg / _populations.Length;//this would be average Whole chromosome
      Array.Sort(_populations);
      Array.Reverse(_populations);
      _maxFitness = _populations[0].Fitness;
    }
    
    
    public IGeneticAlgorithm GeneticAlgorithm
    {
      get { return geneticAlgorithm; }
    }
       
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
        return _populations.Length;
      }
    }

    public IChromosome this[int index] {
      get { return _populations[index]; }
    }

  }
}