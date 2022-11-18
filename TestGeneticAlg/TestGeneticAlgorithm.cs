using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticLibrary;

namespace TestGeneticAlg
{
    [TestClass]
    public class TestGeneticAlgorithm
    {
        public static double fitnes(IChromosome chromosome, IGeneration generation){
          return 120;
        }
        static GeneticAlgorithm _geneticAlgorithm = new GeneticAlgorithm(200, 243, 10, 2,  4, 100, fitnes, 0);

        public static IGeneration _generation = new Generation(_geneticAlgorithm , fitnes, 0);



        [TestMethod]
        public void TestPopulationSize()
        {
            Assert.AreEqual(_geneticAlgorithm.PopulationSize, 200);
        }

        [TestMethod]
        public void TestNumberOfGenes()
        {
            Assert.AreEqual(_geneticAlgorithm.NumberOfGenes, 243);
        }

        [TestMethod]
        public void TestLengthOfGene()
        {
            Assert.AreEqual(_geneticAlgorithm.LengthOfGene, 10);
        }

        [TestMethod]
        public void TestMutationRate()
        {
            Assert.AreEqual(_geneticAlgorithm.MutationRate, 2);
        }

        [TestMethod]
        public void TestEliteRate()
        {
            Assert.AreEqual(_geneticAlgorithm.EliteRate, 4);
        }

        [TestMethod]
        public void TestNumberOfTrials()
        {
            Assert.AreEqual(_geneticAlgorithm.NumberOfTrials, 100);
        }

        [TestMethod]
        public void TestGenerationCount()
        {
            Assert.AreEqual(_geneticAlgorithm.GenerationCount, 0);
        }

        [TestMethod]
        public void TestFitnessCalculation()
        {
            Assert.AreEqual(_geneticAlgorithm.FitnessCalculation, fitnes);
        }

        [TestMethod]
        public void TestCurrentGeneration()
        {
            Assert.AreEqual(_geneticAlgorithm.CurrentGeneration, null);
        }

        // [TestMethod]
        // public void TestGenerateGeneration()
        // {
        //     Assert.AreEqual(_geneticAlgorithm.GenerateGeneration(), _generation);
        // }
  
    }
}
