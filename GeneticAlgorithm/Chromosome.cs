namespace GeneticLibrary
{

    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a chromosome that implement from the IChromosome
    /// </summary>
    public class Chromosome : IChromosome
    {

        private Random rand;

        //genCount = 243 lengthGens = 7 seed =  random
        public Chromosome(int genCount, int lengthGens, int seed = 0)
        {
            if (Length <= 0)
            {
                throw new ArgumentException("Length must be greater than 0");
            }

            rand = new Random(seed);
            Length = genCount;
            Genes = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                Genes[i] = rand.Next(lengthGens);
            }

            Fitness = 0;
        }

        public int Seed { get; }

        public Chromosome(IChromosome chromosome)
        {
            Length = chromosome.Length;
            Genes = new int[chromosome.Length];
        }

        public IChromosome[] Reproduce(IChromosome spouse, double mutationProb)
        {
            int pointA = rand.Next((int) Length);
            int pointB = rand.Next(pointA, (int) Length);
            int[] p1Tmp = spouse.Genes[pointA..pointB]; //p1
            int[] p2Tmp = this.Genes[pointA..pointB]; //p2



            // mutation of the child
            double rndDouble = rand.NextDouble();
            for (int i = 0; i < Genes.Length; i++)
            {
                if (mutationProb >= rndDouble)
                {
                    int rndInt = rand.Next((int)Length);
                }
            }

        }


        public int this[int index] { get{ Genes[index]}; set{} }

        public double Fitness { get; set; }

        public int[] Genes { get; }

        // The Length = 243 
        public long Length { get; }
        public int CompareTo(IChromosome other)
        {
            throw new NotImplementedException();
        }
    }
}
