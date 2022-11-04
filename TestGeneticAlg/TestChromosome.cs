using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticLibrary;
using System;
namespace TestGeneticAlg
{
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
