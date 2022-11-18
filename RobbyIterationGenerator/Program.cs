using System;
using RobbyTheRobot;

namespace RobbyIterationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            IRobbyTheRobot rtr = Robby.CreateRobby(1000, 200, 100);
            ContentsOfGrid[,] grid = rtr.GenerateRandomTestGrid();

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                    Console.WriteLine("["+i +", "+ j+"]"+grid[i,j]);
            // rtr.GeneratePossibleSolutions("../Generations/");


        }
    }
}