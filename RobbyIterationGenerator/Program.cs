using System;
using System.Diagnostics;
using RobbyTheRobot;

namespace RobbyIterationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue = false;
            while(isTrue != true)
            {
                try
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
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    for (long i = 0; i < 1000000000; i++)
                    {
                        rtr.GeneratePossibleSolutions("../Generations/");
                    }
                    watch.Stop();
                    Console.WriteLine(watch.ElapsedMilliseconds);

                    isTrue = true;

                }
                catch(Exception e)
                {
                    Console.WriteLine("ERROR! You have an error. Try Again!");
                    isTrue = false;
                }
            }
        }

        public static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

    }
}