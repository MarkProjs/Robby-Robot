using System;
using System.Linq;


namespace GeneticLibrary
{
  public class Generation : IGeneration {

    private IGeneticAlgorithm _genericAlgorithm;
    public IChromosome[] Chromosomes { get;  set; }
    //private 

    public IChromosome this[int index] {
      get { return Chromosomes[index]; }
      set { Chromosomes[index] = value; }
    }

    public double AverageFitness => Chromosomes.Average(x => x.Fitness);

    public double MaxFitness => Chromosomes.Max(x => x.Fitness);

    public long NumberOfChromosomes => Chromosomes.Length;
    

    // public IGeneticAlgorithm  
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
        // Chromosomes[i] = (Chromosome)generation;
        Chromosomes[i] = generation[i];
        // generation[i] = Chromosomes[i];
        }
    }


    // public IChromosome SelectParent() {
      //??????????????? to do this constructor
      // for (int i = 0; i < Chromosomes.Length; i++)
      // {
      //   Chromosome[] temp = null;
      //   if (Chromosomes[i].Fitness < Chromosomes[i+1].Fitness){
      //     temp = Chromosomes[i];
      //     Chromosomes[i] = Chromosomes [i + 1];
      //     Chromosomes[i + 1] = temp;

      //   }
      // return Chromosomes; //for genaration
      
    // }
    // }

    public void EvaluateFitnessOfPopulation() {
      double evaluationFitness = 0;
      for (int i = 0; i < Chromosomes.Length; i++)
      {
        Chromosomes[i].Fitness = _genericAlgorithm.FitnessCalculation;
        
        evaluationFitness += Chromosomes[i].Fitness;
      }

      for (int i = 0; i < Chromosomes.Length; i++)
      {
        Chromosome[] temp = null;
        if (Chromosomes[i].Fitness < Chromosomes[i+1].Fitness){
          temp = Chromosomes[i];
          Chromosomes[i] = Chromosomes [i + 1];
          Chromosomes[i + 1] = temp;

        }


        double avarage = evaluationFitness /  _genericAlgorithm.FitnessCalculation;
        
        
      }
      
      //for avarage --> NumberOfTrials
    }
  }
 }

