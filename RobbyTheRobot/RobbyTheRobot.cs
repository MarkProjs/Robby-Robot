using System;
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
        public event FileWritten _filewritten;

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
        public double fitnessCalculation(IChromosome chromosome, IGeneration generation){return 0.1;}
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
            // int[] genNum = new int[] { 1, 20, 100, 200, 500, 1000 };
            while (_geneticAlg.GenerationCount < NumberOfGenerations)
            {
                _generation = _geneticAlg.GenerateGeneration();
                // if (Array.Exists(genNum, elem => elem == _geneticAlg.GenerationCount))
                // {
                //     (_generation as Generation).EvaluateFitnessOfPopulation();

                //     string fileName = "Generation" + _geneticAlg.GenerationCount + ".txt";
                //     string path = folderPath + fileName;
                //     if (!File.Exists(path))
                //     {
                //         using (StreamWriter sw = File.CreateText(path))
                //         {
                //             sw.Write(_generation.MaxFitness + "," + _numberOfActions + "," + _generation[0]);
                //         }
                //     }
                // }
            }
            // _filewritten?.Invoke("Files written to" + folderPath);
        }

        //the computeFitness
        public double computeFitness(IChromosome chromosome, IGeneration generation)
        {
            //use the _seed
            Random rnd = new Random();
            int x = rnd.Next(0, 10);
            int y = rnd.Next(0, 10);
            double totalFitness = 0.0;
            for (int i = 0; i < NumberOfActions; i++)
            {

                totalFitness += RobbyHelper.ScoreForAllele(chromosome.Genes, GenerateRandomTestGrid(), rnd, ref x, ref y);
            }
            return totalFitness;
        }
    }
}

            // int[] genNum = new int[] { 1, 20, 100, 200, 500, 1000 };
            // for (int i = 0; i < ; i++)
            // {
            //      _geneticAlg.GenerateGeneration(); 
            //     if (i == _geneticAlg.GenerationCount)
            //     {
            //         int[] genes = getBestChromosome(i);
            //         WriteFile(genes, folderPath);
            //     }else{

            //     }

            // }



        // private int[] getBestChromosome(int i)
        // {
        //     IGeneration tmp = _geneticAlg.GenerateGeneration();
        //     return tmp[i].Genes;
        // }

        // private static void WriteFile(int[] file, string path)
        // {
        //     if (!File.Exists(path))
        //     {
        //         using (StreamWriter sw = File.AppendText(path))
        //         {
        //                 sw.WriteLine(file);
        //         }
        //     }
        // }