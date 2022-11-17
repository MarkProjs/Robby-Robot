using System;
using System.Collections;
using System.IO;
using GeneticLibrary;

namespace RobbyTheRobot
{
    internal class RobbyTheRobot : IRobbyTheRobot
    {
        private IGeneticAlgorithm _geneticAlg;
        private IGeneration _generation;
        private int _numberOfActions = 200;
        private int _numberOfTestGrids = 100;
        private int _gridCol = 10;
        private int _gridRow = 10;
        private int _numGenes = 243;
        private int _lengthOfGenes = 7;
        private double _mutationRate = 0.05;
        private double _eliteRate = 0.05;
        private Random _rnd;
        private  ContentsOfGrid[,] candata;
        private int? _seed;
        public RobbyTheRobot(int numberOfGenerations, int populationSize, int numberOfTrials, int? seed = null)
        {
            _seed = seed;
            NumberOfGenerations = numberOfGenerations;
            _geneticAlg = GeneticLib.CreateGeneticAlgorithm(populationSize, _numGenes, _lengthOfGenes, _mutationRate, _eliteRate, numberOfTrials, computeFitness, seed);
            if (_seed != null)
            {
                _rnd = new Random((int)_seed);
            }
            else
            {
                _rnd = new Random();
            }

        }
         public int NumberOfActions{get{return _numberOfActions;}}
        public int NumberOfTestGrids{get{return _numberOfTestGrids;}}
        public int GridSize{get{return _gridRow * _gridCol;}}
        public int NumberOfGenerations { get; }
        public double MutationRate{get{return _mutationRate;}}
        public double EliteRate{get{return _eliteRate;}}
        public ContentsOfGrid[,] GenerateRandomTestGrid()
        {
            ContentsOfGrid[,] _tempGrid = new ContentsOfGrid[_gridCol, _gridRow];
            for (int col = 0; col < _tempGrid.GetLength(0); col++)
            {
                for (int row = 0; row < _tempGrid.GetLength(1); row++)
                {
                    _tempGrid[col, row] = ContentsOfGrid.Empty;
                }
            }
            //filling the grid to have 50 cans placed
            ContentsOfGrid[,] grid = PlaceCanOnGrid(_tempGrid);
            candata = grid;
            return grid;

        }
        private ContentsOfGrid[,] PlaceCanOnGrid(ContentsOfGrid[,] _tempGrid)
        {
            int _canCounter = 0;
            while (_canCounter < 50)
            {
                int col = _rnd.Next(_tempGrid.GetLength(0));
                int row = _rnd.Next(_tempGrid.GetLength(1));
                if (_tempGrid[col, row] == ContentsOfGrid.Empty)
                {
                    _tempGrid[col, row] = ContentsOfGrid.Can;
                    _canCounter += 1;
                }
            }
            return _tempGrid;
        }

        public void GeneratePossibleSolutions(string folderPath)
        {
            int c = 0;
            int[] genNum = new int[] { 1, 20,100, 200, 500, 1000 };
            while (_geneticAlg.GenerationCount < NumberOfGenerations)
            {
                _generation = _geneticAlg.GenerateGeneration();
                (_generation as Generation).EvaluateFitnessOfPopulation();
                if (_geneticAlg.GenerationCount == genNum[c])
                {
                    WriteGenerationTxt(folderPath);
                    c++;
                }
               
             
            }
            // _filewritten?.Invoke("Files written to" + folderPath);
            int[] test = _generation[0].Genes;
            for (int i = 0; i < _generation[0].Genes.Length; i++)
            {
                Console.Write(test[i]+" - ");
            }

            Console.WriteLine();
            Console.WriteLine(_generation.AverageFitness);
            Console.WriteLine(_generation.MaxFitness);
            Console.WriteLine(_generation[0].Fitness);
            
        }

        //the computeFitness
    public double computeFitness (IChromosome chromosome, IGeneration generation) //, int? seed = null
    {
      //use the _seed
      // Random rnd = new Random(seed.GetValueOrDefault());
      Random rnd = new Random();
      int x = rnd.Next(0,10);
      int y = rnd.Next(0,10);
      double totalFitness = 0.0;
      var grid = GenerateRandomTestGrid();
      for (int i = 0; i < NumberOfActions; i++)
      {

        totalFitness += RobbyHelper.ScoreForAllele(chromosome.Genes, grid , rnd, ref x, ref y);
      }
      return totalFitness;
    }

        private void WriteGenerationTxt(string folderPath)
        {
            string currentGenes = "";
            for (int i = 0; i < _generation[0].Genes.Length; i++)
            {
                currentGenes += _generation[0].Genes[i] + "-";
            }

            // string cancontert = "";
            // int firstd = candata.GetLength(0);
            // int secondd = candata.GetLength(1);
            // for (int i = 0; i < firstd; i++)
            // {
            //     for (int j = 0; j <secondd ; j++)
            //     {
            //         if (candata[i, j] == ContentsOfGrid.Can)
            //         {
            //             cancontert += "c-";
            //         }
            //         else
            //         {
            //             cancontert += "e-";
            //         }
            //     }
            // }

      
            string fileName = "Generation"+_geneticAlg.GenerationCount+".txt";
            string path = folderPath + fileName;
           
            
                using(var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(_generation.AverageFitness+ ";" + _numberOfActions+";" + _geneticAlg.GenerationCount+ ";" +currentGenes);
                } 
        }
     }
}
