using System;
using RobbyTheRobot;

namespace RobbyIterationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            IRobbyTheRobot rtr = Robby.CreateRobby(10, 20, 10);
            rtr.GeneratePossibleSolutions("./Generations/");


        }
    }
}