using System;
using GeneticLibrary;

namespace RobbyTheRobot
{
  internal class RobbyTheRobot : IRobbyTheRobot
  {
    private IGeneticAlgorithm _geneticAlg;
    private int _numberOfActions = 200;
    private int _numberOfTestGrids;
    private int _gridCol = 10;
    private int _gridRow = 10;
    private double _mutationRate;
    private double _eliteRate;
    public event FileWritten _filewritten;
    public RobbyTheRobot(int numberOfGenerations, int populationSize, int numberOfTrials, int? seed=null) 
    {
      NumberOfGenerations = numberOfGenerations;
    }
    public int NumberOfActions 
    {
      get
      {
        return _numberOfActions;
      }
    }

    public int NumberOfTestGrids 
    {
      get
      {
        return _numberOfTestGrids;
      }
    }

    public int GridSize 
    {
      get
      {
        return _gridRow * _gridCol;
      }
    }

    public int NumberOfGenerations { get; }

    public double MutationRate 
    {
      get
      {
        return _mutationRate;
      }
    }

    public double EliteRate 
    {
      get
      {
        return _eliteRate;
      }
    }

    public ContentsOfGrid[,] GenerateRandomTestGrid()
    {
      ContentsOfGrid[,] grid = new ContentsOfGrid[_gridCol, _gridRow];
      for(int col = 0; col < grid.GetLength(0);col++) 
      {
        for(int row = 0; row< grid.GetLength(1); row++) 
        {

        }
      }
      return grid;

    }

    public void GeneratePossibleSolutions(string folderPath)
    {
      _filewritten?.Invoke("File has been written");
    }
  }
}