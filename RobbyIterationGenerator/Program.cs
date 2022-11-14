using System;
using GeneticLibrary;
using RobbyTheRobot;

namespace RobbyIterationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            IRobbyTheRobot rtr = Robby.CreateRobby(10, 200, 200);
            rtr.GeneratePossibleSolutions("C:\\Users\\devop\\Desktop\\yooo.txt");

        }
    }
}