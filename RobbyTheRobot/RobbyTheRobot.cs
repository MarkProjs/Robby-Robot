using System;
using GeneticLibrary;

namespace RobbyTheRobot
{
  internal class RobbyTheRobot : IRobbyTheRobot
  {
    private IGeneticAlgorithm _geneticAlg;
    private int _numberOfActions;
    private int _numberOfTestGrids;
    private int _gridSize;
    private double _mutationRate;
    private double _eliteRate;
    public event FileWritten _filewritten;
    public RobbyTheRobot(int numberOfGenerations, int populationSize, int numberOfTrials, int? seed) 
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
        return _gridSize;
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
      
    }

    public void GeneratePossibleSolutions(string folderPath)
    {
      _filewritten?.Invoke("File has been written");
    }
  }
}