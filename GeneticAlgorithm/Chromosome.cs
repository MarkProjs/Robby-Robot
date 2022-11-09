using System;

namespace GeneticLibrary
{
    public class Chromosome : IChromosome
    {
        private double _fitness;
        private static int currentIndex = 0;
        
        public Chromosome(int numberOfGenes, int lengthOfGene, int? seed = null){
            if (numberOfGenes <= 0 || lengthOfGene <= 0) throw new ArgumentOutOfRangeException("Arguments are not valid");
            Genes = new int[numberOfGenes];
            Random rand;

            if(seed is null){ rand = new Random();}
            else rand = new Random(seed.GetValueOrDefault());  // seed.GetValueOrDefault() cause of creating same children all children have same Genes
            
            for (int i = 0; i < numberOfGenes; i++)
            {
                int rndInt = rand.Next(lengthOfGene);
                Genes[i] = rndInt;
            }
            _fitness = 0;
        }

        public Chromosome(IChromosome chromosome){
            if(chromosome == null) throw new ArgumentNullException("chromosome is empty");
            Fitness = chromosome.Fitness;
            Genes = new int[chromosome.Length];
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
            if (this.Genes.Length != spouse.Genes.Length)
            {
                throw new ArgumentException("genes count does not equal");
            }
            //Creating a new children array
            IChromosome[] children = new IChromosome[spouse.Length];
            // Creating 2 new temporary child objects
            IChromosome child1 = new Chromosome(spouse.Genes.Length, 7);
            IChromosome child2 = new Chromosome(spouse.Genes.Length, 7);
            //make it crossing over between parent's chromosomes
            child1 = CrossingOver(spouse, this);
            child2 = CrossingOver(this, spouse);
            //Make it mutate based one the random values
             MutateChild(ref child1,mutationProb);
            MutateChild(ref child2,mutationProb);
           
            // Adding the children index
            children[currentIndex] = child1;
            currentIndex++;
            
            children[currentIndex] = child2;
            currentIndex++;
            return children;
        }

        private IChromosome CrossingOver(IChromosome p1, IChromosome p2)
        {
            IChromosome child = new Chromosome(p1.Genes.Length,7);
            Random rd = new Random();
            int slicer = rd.Next(p1.Genes.Length);
            slicer = 5;
            // Array.Copy(p1.Genes,0,child.Genes,0,slicer);
            // Array.Copy(p2.Genes,slicer,child.Genes,slicer,p1.Length-13);
            for (int i = 0; i < slicer; i++)
            {
                child.Genes[i] = p1.Genes[i];
            }

            for (int i = slicer; i < p1.Length; i++)
            {
                child.Genes[i] = p2.Genes[i];
            }
            
            return child;
        }

        private void MutateChild(ref IChromosome child, double mutationProb)
        {
            Random random = new Random();
            for (int i = 0; i < child.Genes.Length; i++)
            {
                double mutationRate = random.NextDouble() * 100;
                if (mutationRate < mutationProb)
                {
                    child.Genes[i] = random.Next(7);
                }
            }        
        }
        //implement indexer
        public int this[int index] {
            get {return Genes[index];}
            set {Genes[index]=value;}
        }
        public double Fitness { 
            get { return _fitness; }
            set { _fitness = value; }
        }

        public int[] Genes { get; }

        // The Length = 243 
        public long Length { get { return Genes.Length; } }

    }
}