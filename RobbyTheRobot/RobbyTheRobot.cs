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
        Random rnd = new Random();
        private ContentsOfGrid[,] candata;
        private int? _seed;

        /// <summary>
        /// Robot constructor accepts parameters
        /// </summary>
        /// <param name="numberOfGenerations"></param>
        /// <param name="populationSize"></param>
        /// <param name="numberOfTrials"></param>
        /// <param name="seed"></param>
        public RobbyTheRobot(int numberOfGenerations, int populationSize, int numberOfTrials, int? seed = null)
        {
            _seed = seed;
            NumberOfGenerations = numberOfGenerations;
            _geneticAlg = GeneticLib.CreateGeneticAlgorithm(populationSize, _numGenes, _lengthOfGenes, _mutationRate,
                _eliteRate, numberOfTrials, computeFitness, seed);
            if (_seed != null)
            {
                rnd = new Random((int)_seed);
            }
            else
            {
                rnd = new Random();
            }
        }

        /// <summary>
        /// Creates a new grid for the robby
        /// </summary>
        /// <returns></returns>
        public ContentsOfGrid[,] GenerateRandomTestGrid()
        {
            ContentsOfGrid[,] _tempGrid = new ContentsOfGrid[_gridCol, _gridRow];

            //filling the grid to have 50 cans placed
            ContentsOfGrid[,] grid = PlaceCanOnGrid(_tempGrid);
            return grid;
        }

        /// <summary>
        /// Places the Cans locations on the grid
        /// </summary>
        /// <param name="_tempGrid"></param>
        /// <returns></returns>
        private ContentsOfGrid[,] PlaceCanOnGrid(ContentsOfGrid[,] _tempGrid)
        {
            int _canCounter = 0;
            while (_canCounter < 50)
            {
                int col = rnd.Next(_tempGrid.GetLength(0));
                int row = rnd.Next(_tempGrid.GetLength(1));
                if (_tempGrid[col, row] == ContentsOfGrid.Empty)
                {
                    _tempGrid[col, row] = ContentsOfGrid.Can;
                    _canCounter += 1;
                }
            }

            return _tempGrid;
        }

        /// <summary>
        /// Generates the possible solutions
        /// </summary>
        /// <param name="folderPath"></param>
        public void GeneratePossibleSolutions(string folderPath)
        {
            int c = 0;
            int[] genNum = new int[] { 1, 3, 5, 7, 9, 20 };
            while (_geneticAlg.GenerationCount < NumberOfGenerations)
            {
                _generation = _geneticAlg.GenerateGeneration();
                Console.WriteLine(_geneticAlg.GenerationCount);
                Console.WriteLine(Math.Round(_generation.AverageFitness * 100) / 100);
                Console.WriteLine(Math.Round(_generation.MaxFitness * 100) / 100);
                // WriteGenerationTxt(folderPath);
            }
        }

        /// <summary>
        /// Calculates the fitness of the chromosome
        /// </summary>
        /// <param name="chromosome"></param>
        /// <param name="generation"></param>
        /// <returns></returns>
        //the computeFitness
        public double computeFitness(IChromosome chromosome, IGeneration generation)
        {
            //use the _seed
            int x = rnd.Next(0, 10);
            int y = rnd.Next(0, 10);
            double totalFitness = 0.0;
            ContentsOfGrid[,] grids = GenerateRandomTestGrid();
            for (int i = 0; i < NumberOfActions; i++)
            {
                totalFitness += RobbyHelper.ScoreForAllele(chromosome.Genes, grids, rnd, ref x, ref y);
            }

            return totalFitness;
        }

        /// <summary>
        /// Writes the results of the txt file.
        /// </summary>
        /// <param name="folderPath"></param>
        private void WriteGenerationTxt(string folderPath)
        {
            string fileName = "Generation.txt";
            string path = folderPath + fileName;

            using (var sw = new StreamWriter(path, true))
            {
                sw.WriteLine(_geneticAlg.GenerationCount + " ; " + _generation.MaxFitness + " ; " +
                             _generation.AverageFitness + " ; " + _numberOfActions);
            }
        }

        public int NumberOfActions
        {
            get { return _numberOfActions; }
        }

        public int NumberOfTestGrids
        {
            get { return _numberOfTestGrids; }
        }

        public int GridSize
        {
            get { return _gridRow * _gridCol; }
        }

        public int NumberOfGenerations { get; }

        public double MutationRate
        {
            get { return _mutationRate; }
        }

        public double EliteRate
        {
            get { return _eliteRate; }
        }
    }
}