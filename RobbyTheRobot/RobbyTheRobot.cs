using System;
using GeneticLibrary;

namespace RobbyTheRobot
{
    internal class RobbyTheRobot : IRobbyTheRobot
    {
        private RobbyHelper _helper;
        public RobbyTheRobot(
            int numberOfGenerations,
            int populationSize,
            int numberOfTrials,
            int? seed)
        {
            NumberOfGenerations = numberOfGenerations;
            NumberOfActions = numberOfTrials;
            PopulationSize = populationSize;
        }

        public int PopulationSize { get; }
        public int NumberOfActions { get;}
        public int NumberOfTestGrids { get; set; }
        public int GridSize { get; }
        public int NumberOfGenerations { get; }
        public double MutationRate { get; set; }
        public double EliteRate { get; set; }

        public void GeneratePossibleSolutions(string folderPath)
        {
           
        }

        public ContentsOfGrid[,] GenerateRandomTestGrid()
        {
            throw new NotImplementedException();
        }

        // public double computeFitness(IChromosome chromosome, IGeneration generation)
        // {
        //
        // }
    }
}
