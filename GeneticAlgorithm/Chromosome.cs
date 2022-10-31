namespace GeneticLibrary
{
    public class Chromosome : IChromosome
    {
        private double _fitness;
        private int[] _genes;

        public Chromosome( int GenesNum, int AGeneSize) {
            _genes = new int[AGeneSize];
        }

        public Chromosome(IChromosome chromosome) {
            _fitness = chromosome.Fitness;
            _genes = chromosome.Genes;
        }

        public delegate IChromosome[] PerformRep(IChromosome spouse, double mutationProb);
        public IChromosome[] Reproduce(IChromosome spouse, double mutationProb) {
            PerformRep delReproduce = (spouse, mutationProb) => {
                if (mutationProb > 0.50) {
                    //do the mutation
                }else {
                    //not the mutation
                }
            };
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