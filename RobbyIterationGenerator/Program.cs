using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using GeneticLibrary;

namespace RobbyIterationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Fraction a = new Fraction(1, 2);  
            // Fraction b = new Fraction(3, 4);  
            // Fraction d = a + b;
            // Console.WriteLine(a.Numerator);
            // Console.WriteLine(b.Deniminator);
            // Console.WriteLine(d.Deniminator);
            // Console.WriteLine(d.Numerator);

            // Chromosome chromosome = new Chromosome(20, 6, 6);
            // Chromosome spouse = new Chromosome(20, 6, 6);

            // IChromosome[] nextGeneration = chromosome.Reproduce(spouse, 0);

            // Chromosome nextGenChromosome = new Chromosome(nextGeneration[1]);
            // for (int i = 0; i < chromosome.Length; i++)
            // {
            //     Console.WriteLine("Chromosome "+i +" "+chromosome[i]);
            //     Console.WriteLine("Spouse "+i+" "+spouse[i]);
            //     Console.WriteLine("-----------");
            // }
            // GeneticLibrary gens = new GeneticLibrary();
            // IGeneticAlgorithm algorithm = new GeneAlgorithm(gens.PopulationSize, gens.NumberOfGenes,gens.LengthOfGene,gens.MutationRate,gens.EliteRate,gens.NumberOfTrials,gens.FitnessEventHandler,0);
            // IGeneration current = new Generation();
            //    Console.WriteLine("Hello World!");
            //

            // CalDel compute = Calculator.Add;
            // compute(3, 5);
            // compute = Calculator.Subs;
            // compute(12, 3);
            //
            // Task t = new Task(() =>
            // {
            //     for (int i = 0; i < 10; i++)
            //     {
            //         Console.WriteLine("Task Loop");
            //     }
            // });
            // t.Start();
            // for (int i = 0; i < 10; i++)
            // {
            //     Console.WriteLine("End Main");
            // }

            Dog myDog = new Dog("Rover");
            ChangeName(out myDog);
            Console.WriteLine(myDog.Name);
        }
        public static void ChangeName (out Dog anotherDog)
        {
            anotherDog.Name =="Max";
            anotherDog = new Dog ("COCO");
        }
       
        public class Mysource : IDisposable
        {
            private object unmanRes;
            public Mysource()
            {
                unmanRes = new object();
            }

            public void Dispose()
            {
                unmanRes = null;
            }
        }

        public sealed class ThreadSafe
        {
            private static ThreadSafe instance = null;
            private static readonly object padlock = new object();
            public ThreadSafe(){}

            public ThreadSafe Instance
            {
                get
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            return new ThreadSafe();
                        }
                    }
                    return instance;
                }
            }
        }

        public delegate void CalDel(int x, int y);
        public class Calculator
        {
            public static void Add(int x, int y)
            {
                Console.WriteLine(x+y);
            }

            public static void Subs(int x, int y)
            {
                Console.WriteLine(x-y);
            }
        }
        
        public class  Fraction
        {
            public int Numerator { get; set; }
            public int Deniminator { get; set; }

            public Fraction(int x, int y)
            {
                Numerator = x;
                Deniminator = y;
            }

            public static Fraction operator +(Fraction a, Fraction b)
            {
                int n1, n2;
                n1 = a.Deniminator * b.Numerator + a.Numerator * b.Deniminator;
                n2 = a.Deniminator * b.Deniminator;
                return new Fraction(n1, n2);
            }
            
            public static implicit  operator Fraction(int a)
            {
                return new Fraction(a, 1);
            }

        }
        

    }
    public class Dog
    {
        public string Name { get; set; }
        public Dog(string ab)
        {
            Name = ab;
        }
    }
}