using System;

namespace GeneticLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Generation : IGenerationDetails
    {
        private Chromosome[] _populations;
        private int? _seed;
        public event FitnessEventHandler FitnessEvt;
        private Random rnd;
        private Random rand;
        private double _fitnessAvg;
        private double _maxFitness;
        IGeneticAlgorithm geneticAlgorithm;

        /// <summary>
        /// The constructor of the generation class instance
        /// </summary>
        /// <param name="_geneticAlgorithm"></param>
        /// <param name="fitnessEvt"></param>
        /// <param name="seed"></param>
        public Generation(IGeneticAlgorithm _geneticAlgorithm, FitnessEventHandler fitnessEvt, int? seed = null)
        {
            geneticAlgorithm = _geneticAlgorithm;
            FitnessEvt += fitnessEvt;
            rnd = new Random(seed.GetValueOrDefault());
            _populations = new Chromosome[geneticAlgorithm.PopulationSize];

            for (int i = 0; i < _populations.Length; i++)
            {
                _populations[i] = new Chromosome(geneticAlgorithm.NumberOfGenes, geneticAlgorithm.LengthOfGene);
            }
        }

        /// <summary>
        /// Copy constructor of the generation class and accepts Chromosome array and GeneticAlgorithm
        /// </summary>
        /// <param name="chromosomes"></param>
        /// <param name="geneticAlgorithmpar"></param>
        public Generation(Chromosome[] chromosomes, IGeneticAlgorithm geneticAlgorithmpar)
        {
            _populations = new Chromosome[chromosomes.Length];
            geneticAlgorithm = geneticAlgorithmpar;
            FitnessEvt += geneticAlgorithm.FitnessCalculation;
            for (int i = 0; i < chromosomes.Length; i++)
            {
                _populations[i] = chromosomes[i];
            }
        }

        /// <summary>
        /// Selects the best parent in the population. Selection is based on the elite rates.
        /// because of they are best adapted to the environment
        /// </summary>
        /// <returns></returns>
        public IChromosome SelectParent()
        {
            rand = new Random();
            // Console.WriteLine(_populations[0].Fitness);
            // return _populations[0];
            int elites = (int)(geneticAlgorithm.EliteRate * geneticAlgorithm.PopulationSize);
            int index = rand.Next(elites);
            return (_populations[index] as Chromosome);
        }

        /// <summary>
        /// Calculates the population's fitness based on the robby's movement and picked up the cans 
        /// </summary>
        public void EvaluateFitnessOfPopulation()
        {
            double fitnessEvent = 0;
            for (int i = 0; i < geneticAlgorithm.PopulationSize; i++)
            {
                for (int j = 0; j < geneticAlgorithm.NumberOfTrials; j++)
                {
                    fitnessEvent += this.FitnessEvt(_populations[j], this); // Potential problem is here
                }
                fitnessEvent = fitnessEvent / GeneticAlgorithm.NumberOfTrials;
                _populations[i].Fitness = fitnessEvent;
                _fitnessAvg += fitnessEvent;
            }

            _fitnessAvg = _fitnessAvg / _populations.Length;
            // Array.Sort(_populations);
            // Array.Reverse(_populations);


            for (int i = 1; i < _populations.Length - 1; i++)
            {
                if (_maxFitness < _populations[i].Fitness)
                {
                    _maxFitness = _populations[i].Fitness;
                }
            }
            Console.WriteLine(_maxFitness);
            // _maxFitness = _populations[0].Fitness;
        }


        public IGeneticAlgorithm GeneticAlgorithm
        {
            get { return geneticAlgorithm; }
        }

        public double AverageFitness
        {
            get { return _fitnessAvg; }
        }

        public double MaxFitness
        {
            get { return _maxFitness; }
        }

        public long NumberOfChromosomes
        {
            get { return _populations.Length; }
        }

        public IChromosome this[int index]
        {
            get { return _populations[index]; }
        }
    }
}