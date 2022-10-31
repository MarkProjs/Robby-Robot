namespace GeneticLibrary
{
    public class Chromosome : IChromosome
    {
        private double _fitness;
        private int[] _genes;

        public Chromosome(int GeneSize) {
            _genes = new int[GeneSize];
        }

        public Chromosome(IChromosome chromosome) {
            _fitness = chromosome.Fitness;
            _genes = chromosome.Genes;
        }

        public IChromosome[] Reproduce(IChromosome spouse, double mutationProb) {
            
        }

        public double Fitness {
            get {return _fitness;}
        }

        public int[] Genes {
            get {return _genes;}
        }

        public int this[int index]{
            get{return _genes[index];}
        }

        public long Length {
            get {return _genes.Length;}
        }
    }
}