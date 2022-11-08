using System;
using GeneticLibrary;

namespace RobbyTheRobot
{
    internal class RobbyTheRobot : IRobbyTheRobot
    {
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
            GeneticAlgorithm ga = new GeneticAlgorithm(PopulationSize,243,7,0,10,200,);
        }

        public ContentsOfGrid[,] GenerateRandomTestGrid()
        {
            throw new NotImplementedException();
        }
    }
}