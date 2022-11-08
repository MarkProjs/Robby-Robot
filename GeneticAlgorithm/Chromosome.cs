using System;
using System.Diagnostics.CodeAnalysis;

namespace GeneticLibrary
{
    public class Chromosome : IChromosome
    {
        private double _fitness;
        public Chromosome(int numberOfGenes, int LengthOfGene, int? seed = null){
            if (numberOfGenes <= 0 || LengthOfGene <= 0) throw new ArgumentOutOfRangeException("Arguments are not valid");
            Genes = new int[numberOfGenes];
            var rand = new Random(seed.GetValueOrDefault());
            for (int i = 0; i < numberOfGenes; i++)
            {
                int rndInt = rand.Next(LengthOfGene);
                Genes[i] = rndInt;
            }
            Fitness = 0;
        }

        //deep copy of the _genes
        public Chromosome(IChromosome choromosome){
            if(choromosome == null) throw new ArgumentNullException("choromosome");
            Fitness = choromosome.Fitness;
            Genes = new int[choromosome.Length];
            for (var i = 0; i < choromosome.Length; i++)
            {
                Genes[i] = choromosome[i];
            } 
        }

        //implement indexer
        public int this[int index] {
            get {return Genes[index];}
            set {Genes[index]=value;}
        }

    
        public int CompareTo(IChromosome other) {
            return Fitness.CompareTo((other as Chromosome).Fitness);
        }

        public IChromosome[] Reproduce(IChromosome spouse, double mutationProb){
            var rand = new Random();
            int pointA = rand.Next((int)Length);
            int pointB = rand.Next(pointA, (int)Length);

            for (int i = pointA; i < pointB; i++) {
                double mutation = rand.NextDouble();
                if (mutation >= mutationProb) {
                    int movement = rand.Next(7);
                    this.Genes[i] = movement;
                    spouse.Genes[i] = movement;
                } else {
                    int tmp = this.Genes[i];
                    this.Genes[i] = spouse.Genes[i];
                    spouse.Genes[i] = tmp;
                }
            }
            return new []{this, spouse};
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