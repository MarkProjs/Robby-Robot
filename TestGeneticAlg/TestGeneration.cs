using System;
using GeneticLibrary;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGeneticAlg
{
    [TestClass]
    public class TestGeneration
    {
        static Chromosome ch1 = new Chromosome(20, 7,6);
        static Chromosome ch2 = new Chromosome(20, 7,6);
        static IChromosome[] childrenArr = ch1.Reproduce(ch2, 0);
        public static double fitnes(IChromosome chromosome, IGeneration generation){
          return 120;
        }
        private IGeneticAlgorithm _geneticAlgorithm = new GeneticAlgorithm(100,243,7,0,0,100,fitnes,0);
       
        [TestMethod]
        public void TestConstructorDeepCopy()
        {
            for (int i = 0; i < childrenArr[0].Genes.Length; i++)
            {
                Assert.AreEqual(ch1.Genes[i] ,childrenArr[0].Genes[i]);
            }
           
        }
        
     
        [TestMethod]
        public void TestCurrentGeneration()
        {
            Assert.AreEqual(_geneticAlgorithm.CurrentGeneration.NumberOfChromosomes, 2);
        } 
        [TestMethod]
        public void TestGenerationCount()
        {
            Assert.AreEqual(_geneticAlgorithm.GenerationCount, 2);
        } 
        
        [TestMethod]
        public void TestLength()
        {
            Assert.AreEqual(childrenArr.Length, 20);
        } 
        
        [TestMethod]
        public void TestPopulationSize()
        {
            Assert.AreEqual(_geneticAlgorithm.PopulationSize, 100);
        } 
        
        [TestMethod]
        public void TestNumberOfGenes()
        {
            Assert.AreEqual(_geneticAlgorithm.NumberOfGenes, 7);
        } 
        
        [TestMethod]
        public void TestLengthOfGene()
        {
            Assert.AreEqual(_geneticAlgorithm.LengthOfGene, 243);
        } 
        
        [TestMethod]
        public void TestMutationRate()
        {
            Assert.AreEqual(_geneticAlgorithm.MutationRate, 0);
        } 
        
        [TestMethod]
        public void TestEliteRate()
        {
            Assert.AreEqual(_geneticAlgorithm.EliteRate, 0);
        } 
        
        [TestMethod]
        public void TestNumberOfTrials()
        {
            Assert.AreEqual(_geneticAlgorithm.NumberOfTrials, 100);
        } 
        
        [TestMethod]
        public void TestFitnessCalculation()
        {
            Assert.AreEqual(_geneticAlgorithm.FitnessCalculation, 20);
        } 
        
        [TestMethod]
        public void TestGenerateNextGeneration()
        {
            Assert.AreEqual(_geneticAlgorithm.GenerateGeneration().NumberOfChromosomes, 2);
        }
        
     
        
   
    }
}
