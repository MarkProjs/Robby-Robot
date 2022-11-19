using System;
using RobbyTheRobot;

namespace RobbyIterationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            IRobbyTheRobot rtr = null;
           

            Console.WriteLine("Welcome to the Robby Simulation!");
            Console.WriteLine("How many generations do you want to have for Robby?");
            string numberOfGenerations = Console.ReadLine();
            Console.WriteLine("How many population size?");
            string populationSize = Console.ReadLine();
            Console.WriteLine("How many number of trials?");
            string numberOfTrials = Console.ReadLine();
            Console.WriteLine("Do you need the seed? Insert null if not needed or a number if needed");
            string seed = Console.ReadLine();
            
            if (seed == "null")
            {
                rtr = Robby.CreateRobby(int.Parse(numberOfGenerations), int.Parse(populationSize), int.Parse(numberOfTrials));
            }
            else
            {
                rtr = Robby.CreateRobby(int.Parse(numberOfGenerations), int.Parse(populationSize), int.Parse(numberOfTrials), int.Parse(seed));
            }

            rtr.Filewritten += WriteMessage;
            rtr.GeneratePossibleSolutions("../Generations/");
            
            
        }

        public static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

    }
}