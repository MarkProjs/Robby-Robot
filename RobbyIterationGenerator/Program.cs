using System;
using RobbyTheRobot;

namespace RobbyIterationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            IRobbyTheRobot rtr = Robby.CreateRobby(1000, 200, 200);
            rtr.GeneratePossibleSolutions("../Generations/");

        }
    }
}