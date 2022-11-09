using System;
using GeneticLibrary;

namespace RobbyTheRobot
{
  internal class RobbyTheRobot : IRobbyTheRobot
  {
    private IGeneticAlgorithm _geneticAlg;
    private int _numberOfActions = 200;
    private int _numberOfTestGrids = 100;
    private int _gridCol = 10;
    private int _gridRow = 10;
    private int _numGenes = 243;
    private double _mutationRate = 0.05;
    private double _eliteRate = 0.05;
    private Random _rnd;
    public event FileWritten _filewritten;
    public RobbyTheRobot(int numberOfGenerations, int populationSize, int numberOfTrials, int? seed=null) 
    {
      NumberOfGenerations = numberOfGenerations;
      if(seed != null) 
      {
        _rnd = new Random((int)seed);
      } 
      else 
      {
        _rnd = new Random();
      }
      
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
      int _canCounter = 0;
      ContentsOfGrid[,] grid = new ContentsOfGrid[_gridCol, _gridRow];
      for(int col = 0; col < grid.GetLength(0);col++) 
      {
        for(int row = 0; row< grid.GetLength(1); row++) 
        {
          int PlaceCanOrNot = _rnd.Next(0, 2);
          if( PlaceCanOrNot == 0 && _canCounter != 50) 
          {
            grid[col,row] = ContentsOfGrid.Can;
            _canCounter += 1;
          }
          else 
          {
             grid[col,row] = ContentsOfGrid.Empty;
          }
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