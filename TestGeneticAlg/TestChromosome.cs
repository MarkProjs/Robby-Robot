using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticLibrary;
using System;

namespace TestGeneticAlg
{
    [TestClass]
    public class TestChromosome
    {
        static int[] p1 = new int[] { 2, 5, 1, 0, 4, 5, 3, 6 };
        private Chromosome _spouse = new Chromosome(20, 6, 6);
        private static int _numberOfGenes = 10;
        private static int _lengthOfGene = 6;
        private static int _seed = 0;
        private static Chromosome _chromosome;


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Arguments are not valid")]
        public void ArgumentNullDeepCopyChromosomeConstructor()
        {
            Chromosome deepClone = new Chromosome(_chromosome);
            bool reference = object.ReferenceEquals(deepClone, _chromosome);
            Assert.IsFalse(reference, "Deep copy constructor is not functional");
        }

        [TestMethod]
        public void TestDefaultArrayLength()
        {
            _chromosome = new Chromosome(_numberOfGenes, _lengthOfGene, _seed);
            Assert.AreEqual(10, _chromosome.Length);
        }

        [TestMethod]
        public void TestRandomGenesRange()
        {
            foreach (int i in p1)
            {
                Assert.IsTrue(i < 7, "The genes range cannot be greater than 6");
            }
        }

        [TestMethod]
        public void TestRandomGenesRange2()
        {
            _chromosome = new Chromosome(_numberOfGenes, _lengthOfGene, _seed);
            int[] genes = _chromosome.Genes;
            foreach (int i in genes)
            {
                Assert.IsTrue(i < 7, "The genes range cannot be greater than 6");
            }
        }

        [TestMethod]
        public void TestChromosomeFitnessField()
        {
            double fitnessResult = 39.4;
            _chromosome = new Chromosome(_numberOfGenes, _lengthOfGene, _seed);
            _chromosome.Fitness = 39.4;
            Assert.AreEqual(_chromosome.Fitness, fitnessResult);
        }


        [TestMethod]
        public void TestRandomGenesRange3()
        {
            _chromosome = new Chromosome(100, 7, _seed);
            int[] genes = _chromosome.Genes;
            foreach (int i in genes)
            {
                Assert.IsTrue(i < 8, "The genes range cannot be greater than 7");
            }
        }

        [TestMethod]
        public void TestArrayIndex()
        {
            Assert.AreEqual(p1[3], 0, "Index element is not the expected value");
        }


        [TestMethod]
        public void TestDeepCopyConstructor()
        {
            _chromosome = new Chromosome(_numberOfGenes, _lengthOfGene, _seed);
            Chromosome deepClone = new Chromosome(_chromosome);
            bool reference = object.ReferenceEquals(deepClone, _chromosome);
            Assert.IsFalse(reference, "Deep copy constructor is not functional");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "A chromosome arguments are  was inappropriately allowed.")]
        public void ArgumentOutOfRangeChromosomeConstructor()
        {
            _chromosome = new Chromosome(100, -7);
        }

        [TestMethod]
        public void TestDeepCopyChromosomeConstructorCompareTo()
        {
            _chromosome = new Chromosome(_numberOfGenes, _lengthOfGene, _seed);
            Chromosome deepClone = new Chromosome(_chromosome);
            Assert.AreEqual(_chromosome.CompareTo(deepClone), 0, "The two instances can not be equal");
        }

        [TestMethod]
        public void TestDeepCopyConstructorLength()
        {
            Chromosome deepClone = new Chromosome(_chromosome);
            Assert.AreEqual(_chromosome.Length, deepClone.Length, "Deep copy constructor is not functional");
        }

        [TestMethod]
        public void TestReproduceMethod0MutationProbParent1()
        {
            _chromosome = new Chromosome(20, _lengthOfGene, _seed);
            IChromosome[] nextGeneration = _chromosome.Reproduce(_spouse, 0);
            for (int i = 0; i < _chromosome.Length; i++)
            {
            }
        }

        [TestMethod]
        public void TestReproduceMethod0MutationProbSpouse()
        {
            _chromosome = new Chromosome(20, _lengthOfGene, _seed);
            IChromosome[] nextGeneration = _chromosome.Reproduce(_spouse, 0);
            // Chromosome nextGenChromosome = new Chromosome(nextGeneration[1]);
            for (int i = 0; i < _chromosome.Length; i++)
            {
                // Assert.AreEqual(spouse[i], nextGenChromosome[i]);
            }
        }
        // [TestMethod]
        // public void TestReproduceMethod100MutationProb()
        // {
        //     chromosome = new Chromosome(20, LengthOfGene, seed);
        //     IChromosome[] nextGeneration = chromosome.Reproduce(spouse, 100);
        //     Chromosome nextGenChromosome = new Chromosome(nextGeneration[0]);
        //     for (int i = 0; i < chromosome.Length; i++)
        //     {
        //         Assert.AreNotEqual(chromosome[i], nextGenChromosome[i]);
        //     }
        // }

        [TestClass]
        public class UnitTest1
        {
            Chromosome chr = new Chromosome(5, 7, 1);

            [TestMethod]
            public void TestFitness()
            {
                Assert.AreEqual(chr.Fitness, 0.0);
            }

            [TestMethod]
            public void TestLength()
            {
                Assert.AreEqual(chr.Length, 5);
            }

            [TestMethod]
            public void TestGenes()
            {
                Random rnd = new Random(1);
                int[] tempGenes = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    int rndInt = rnd.Next(7);
                    tempGenes[i] = rndInt;
                }

                Assert.AreEqual(chr[0], tempGenes[0]);
            }
        }
    }
}