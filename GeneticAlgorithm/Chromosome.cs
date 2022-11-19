using System;

namespace GeneticLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Chromosome : IChromosome
    {
        private double _fitness;
        private static int _currentIndex = 0;
        private int? _seed;
        Random rand;

        /// <summary>
        /// This class is main constructor, and creates a chromosome to given parameter 
        /// </summary>
        /// <param name="numberOfGenes"></param>
        /// <param name="lengthOfGene"></param>
        /// <param name="seed"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Chromosome(int numberOfGenes, int lengthOfGene, int? seed = null)
        {
            if (numberOfGenes <= 0 || lengthOfGene <= 0)
                throw new ArgumentOutOfRangeException("Arguments are not valid");
            Genes = new int[numberOfGenes];
            rand = new Random();

            if(seed is null){ rand = new Random();}
            else rand = new Random(seed.GetValueOrDefault());  

            // Filling genes with the random values
            for (int i = 0; i < numberOfGenes; i++)
            {
                int rndInt = rand.Next(lengthOfGene);
                Genes[i] = rndInt;
            }

            _fitness = 0;
            _seed = seed;
        }

        /// <summary>
        /// This is second constructor and accepts another chromosome and makes a deep copy. 
        /// </summary>
        /// <param name="chromosome"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Chromosome(Chromosome chromosome)
        {
            if (chromosome == null) throw new ArgumentNullException("chromosome is empty");

            Genes = new int[chromosome.Length];
            rand = new Random();
            for (var i = 0; i < chromosome.Length; i++)
            {
                Genes[i] = chromosome[i];
            }
        }

        /// <summary>
        /// This method compares two chromosomes
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int number based on the compare results</returns>
        public int CompareTo(IChromosome other)
        {
            int res;
            Chromosome compare = new Chromosome((other as Chromosome));

            if (this.Fitness > other.Fitness)
            {
                res = 1;
            }
            else if (this.Fitness < other.Fitness)
            {
                res = -1;
            }
            else
            {
                res = 0;
            }

            return res;
            // return Fitness.CompareTo((other as Chromosome).Fitness);
        }

        /// <summary>
        /// This method generates new generation chromosomes 
        /// </summary>
        /// <param name="spouse"></param>
        /// <param name="mutationProb"></param>
        /// <returns> chromosome</returns>
        /// <exception cref="ArgumentException"></exception>
        public IChromosome[] Reproduce(IChromosome spouse, double mutationProb)
        {
            if (this.Genes.Length != spouse.Genes.Length)
            {
                throw new ArgumentException("genes count does not equal");
            }

            // Creating a new children array
            IChromosome[] children = new Chromosome[2];

            Chromosome child1 = new Chromosome(this);
            Chromosome child2 = new Chromosome(spouse as Chromosome);
            
            // Makes it a single crossing-over and swap random genes 
            CrossingOver(child1, child2);
            
            //Make it mutate based one the random values
            MutateChild(child1, mutationProb);
            MutateChild(child2, mutationProb);

            // Adding the children index
            children[0] = child1;
            children[1] = child2;

            return children;
        }

        /// <summary>
        /// Swap sequence of genes between parents chromosome 
        /// </summary>
        /// <param name="p1">parent 1</param>
        /// <param name="p2">parent 1</param>
        private void CrossingOver(Chromosome p1, Chromosome p2)
        {
            Chromosome tmp = new Chromosome(p1);


            int slicer1 = rand.Next(0, p1.Genes.Length - 2);
            int slicer2 = rand.Next(slicer1, p1.Genes.Length);

            for (int i = slicer1; i < slicer2; i++)
            {
                tmp.Genes[i] = p1.Genes[i];
                p1.Genes[i] = p2.Genes[i];
                p2.Genes[i] = tmp.Genes[i];
            }
        }

        /// <summary>
        /// Makes a mutation in the chromosome based on the mutation rate
        /// </summary>
        /// <param name="child"></param>
        /// <param name="mutationProb"></param>
        private void MutateChild(Chromosome child, double mutationProb)
        {
            for (int i = 0; i < child.Genes.Length; i++)
            {
                double mutationRate = Math.Round(rand.NextDouble() * 100) / 100;
                if (mutationRate < mutationProb)
                {
                    child.Genes[i] = rand.Next(7);
                }
            }
        }


        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index"></param>
        public int this[int index]
        {
            get => Genes[index];
            set => Genes[index] = value;
        }

        public double Fitness
        {
            get => _fitness;
            set => _fitness = value;
        }

        public int[] Genes { get; }

        // The Length = 243 
        public long Length => Genes.Length;
    }
}