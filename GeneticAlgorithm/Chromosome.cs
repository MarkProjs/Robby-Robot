using System;

namespace GeneticLibrary
{
    public class Chromosome : IChromosome
    {
        private double _fitness;
        private static int _currentIndex = 0;
        private int? _seed;
        Random rand;

        
        public Chromosome(int numberOfGenes, int lengthOfGene, int? seed = null){
            if (numberOfGenes <= 0 || lengthOfGene <= 0) throw new ArgumentOutOfRangeException("Arguments are not valid");
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

        public Chromosome(Chromosome chromosome){
            if(chromosome == null) throw new ArgumentNullException("chromosome is empty");
            // Fitness = chromosome.Fitness;
            Genes = new int[chromosome.Length];
            rand = new Random();
            for (var i = 0; i < chromosome.Length; i++)
            {
                Genes[i] = chromosome[i];
            } 
        }
        public int CompareTo(IChromosome other) {
            return Fitness.CompareTo((other as Chromosome).Fitness);
        }

        public IChromosome[] Reproduce(IChromosome spouse, double mutationProb)
        {
            // if (this.Genes.Length != spouse.Genes.Length)
            // {
            //     throw new ArgumentException("genes count does not equal");
            // }
            //Creating a new children array
            IChromosome[] children = new Chromosome[2];
            
            // Creating 2 new temporary child objects
            //make it crossing over between parent's chromosomes
           
            Chromosome child1 = new Chromosome(this);
            Chromosome child2 = new Chromosome(spouse as Chromosome);
            CrossingOver(child1, child2); 
            //Make it mutate based one the random values
            MutateChild(child1,mutationProb);
            MutateChild(child2,mutationProb);
           
            // Adding the children index
            children[_currentIndex] = child1;
 
            return children;
        }

        private void CrossingOver(Chromosome p1, Chromosome p2)
        {
            Chromosome tmp = new Chromosome(p1);
            
           
            int slicer1 = rand.Next(0,p1.Genes.Length-2);
            int slicer2 = rand.Next(slicer1,p1.Genes.Length);

            for (int i = slicer1; i < slicer2; i++)
            {
                tmp.Genes[i] = p1.Genes[i];
                p1.Genes[i] = p2.Genes[i];
                p2.Genes[i] = tmp.Genes[i];
            }
        }

        private void MutateChild(IChromosome child, double mutationProb)
        {
            for (int i = 0; i < child.Genes.Length; i++)
            {
                double mutationRate = rand.NextDouble() * 100;
                if (mutationRate < mutationProb)
                {
                    child.Genes[i] = rand.Next(7);
                }
            }        
        }
        
        //implement indexer
        public int this[int index] {
            get => Genes[index];
            set => Genes[index]=value;
        }
        public double Fitness { 
            get => _fitness;
            set => _fitness = value;
        }

        public int[] Genes { get; }

        // The Length = 243 
        public long Length => Genes.Length;
    }
}