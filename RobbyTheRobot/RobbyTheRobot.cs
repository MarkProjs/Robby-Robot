using System;
using GeneticLibrary;

namespace RobbyTheRobot
{
  public class RobbyTheRobot : IRobbyTheRobot
  {
    public RobbyTheRobot(
      int numberOfGenerations,
      int populationSize,
      int numberOfTrials,
      int? seed) {

      NumberOfGenerations = numberOfGenerations;

      }
    public int NumberOfActions => throw new NotImplementedException();

    public int NumberOfTestGrids => throw new NotImplementedException();

    public int GridSize => throw new NotImplementedException();

    public int NumberOfGenerations { get; }

    public double MutationRate => throw new NotImplementedException();

    public double EliteRate => throw new NotImplementedException();

    public void GeneratePossibleSolutions(string folderPath)
    {
      throw new NotImplementedException();
    }

    public ContentsOfGrid[,] GenerateRandomTestGrid()
    {
      throw new NotImplementedException();
    }
  }
}