using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticLibrary;
using System;

namespace TestGeneticAlg
{
    [TestClass]
    public class TestChromosome
    {
        static int[] p1 = new int[] { 2, 5, 1, 0, 4, 5, 3, 6 };
        private Chromosome spouse = new Chromosome(20, 6, 6);
        private static int numberOfGenes = 10;
        private static int LengthOfGene = 6;
        private static int seed = 0;
        private static Chromosome chromosome;


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Arguments are not valid")]
        public void ArgumentNullDeepCopyChromosomeConstructor()
        {
            Chromosome deepClone = new Chromosome(chromosome);
            bool reference = object.ReferenceEquals(deepClone, chromosome);
            Assert.IsFalse(reference, "Deep copy constructor is not functional");
        }

        [TestMethod]
        public void TestDefaultArrayLength()
        {
            chromosome = new Chromosome(numberOfGenes, LengthOfGene, seed);
            Assert.AreEqual(10, chromosome.Length);
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
            chromosome = new Chromosome(numberOfGenes, LengthOfGene, seed);
            int[] genes = chromosome.Genes;
            foreach (int i in genes)
            {
                Assert.IsTrue(i < 7, "The genes range cannot be greater than 6");
            }
        }

        [TestMethod]
        public void TestChromosomeFitnessField()
        {
            double fitnessResult = 39.4;
            chromosome = new Chromosome(numberOfGenes, LengthOfGene, seed);
            chromosome.Fitness = 39.4;
            Assert.AreEqual(chromosome.Fitness, fitnessResult);
        }


        [TestMethod]
        public void TestRandomGenesRange3()
        {
            chromosome = new Chromosome(100, 7, seed);
            int[] genes = chromosome.Genes;
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
            chromosome = new Chromosome(numberOfGenes, LengthOfGene, seed);
            Chromosome deepClone = new Chromosome(chromosome);
            bool reference = object.ReferenceEquals(deepClone, chromosome);
            Assert.IsFalse(reference, "Deep copy constructor is not functional");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "A chromosome arguments are  was inappropriately allowed.")]
        public void ArgumentOutOfRangeChromosomeConstructor()
        {
            chromosome = new Chromosome(100, -7);
        }

        [TestMethod]
        public void TestDeepCopyChromosomeConstructorCompareTo()
        {
            chromosome = new Chromosome(numberOfGenes, LengthOfGene, seed);
            Chromosome deepClone = new Chromosome(chromosome);
            Assert.AreEqual(chromosome.CompareTo(deepClone), 0, "The two instances can not be equal");
        }

        [TestMethod]
        public void TestDeepCopyConstructorLength()
        {
            Chromosome deepClone = new Chromosome(chromosome);
            Assert.AreEqual(chromosome.Length, deepClone.Length, "Deep copy constructor is not functional");
        }

        [TestMethod]
        public void TestReproduceMethod0MutationProbParent1()
        {
            chromosome = new Chromosome(20, LengthOfGene, seed);
            IChromosome[] nextGeneration = chromosome.Reproduce(spouse, 0);
            Chromosome nextGenChromosome = new Chromosome(nextGeneration[0]);
            for (int i = 0; i < chromosome.Length; i++)
            {
                Assert.AreEqual(chromosome[i], nextGenChromosome[i]);
            }
        }

        [TestMethod]
        public void TestReproduceMethod0MutationProbSpouse()
        {
            chromosome = new Chromosome(20, LengthOfGene, seed);
            IChromosome[] nextGeneration = chromosome.Reproduce(spouse, 0);
            Chromosome nextGenChromosome = new Chromosome(nextGeneration[1]);
            for (int i = 0; i < chromosome.Length; i++)
            {
                Assert.AreEqual(spouse[i], nextGenChromosome[i]);
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
