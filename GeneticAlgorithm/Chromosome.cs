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
        public Chromosome(int genCount, int lengthGens, int? seed = 0)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be greater than 0");
            }
            rand = new Random(seed);
            Length = genCount;
            Genes = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                Genes[i] = seed.Next(lengthGens);
            }
            Fitness = 0;
            Seed = seed;
        }
        public int Seed { get; }
        public Chromosome(IChromosome chromosome)
        {
            Length = chromosome.Length;
            Genes = new int[chromosome.Length];
        }

        public IChromosome[] Reproduce(IChromosome spouse, double mutationProb)
        {
            rnd = new Random();
            int pointA = rnd.Next(Length);
            int pointB = rnd.Next(pointA, Length);
            int[] p1Tmp = spouse.Genes.slice[pointA..pointB]; //p1
            int[] p2Tmp = this.Genes.slice[pointA..pointB]; //p2


            
            // mutation of the child
            double rndDouble = rnd.NextDouble(1);
            for (int i = 0; i < Genes.Length; i++)
            {
                if (mutationProb >= rndDouble)
                {
                    rnd = new Random();
                    int rndInt = rnd.Next(Length);
                }
            }

        }

    }
    public int this[int index] { get; internal set; }

    public double Fitness { get; set; }

    public int[] Genes { get; }

    // The Length = 243 
    public long Length { get; }

}
}