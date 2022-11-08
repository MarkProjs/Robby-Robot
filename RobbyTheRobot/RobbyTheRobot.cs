using System;
using GeneticLibrary;

namespace RobbyTheRobot
{
  internal class RobbyTheRobot : IRobbyTheRobot
  {
    private IGeneticAlgorithm _geneticAlg;
    public event FileWritten _filewritten;
    public RobbyTheRobot(int numberOfGenerations, int populationSize, int numberOfTrials, int? seed) 
    {
      NumberOfGenerations = numberOfGenerations;
    }
    public int NumberOfActions {};

    public int NumberOfTestGrids {};

    public int GridSize {};

    public int NumberOfGenerations { get; }

    public double MutationRate {};

    public double EliteRate {};

    public ContentsOfGrid[,] GenerateRandomTestGrid()
    {
      throw new NotImplementedException();
    }

    public void GeneratePossibleSolutions(string folderPath)
    {
      _filewritten?.Invoke("File has been written");
    }
  }
}