using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticLibrary;
namespace TestGeneticAlg
{
    [TestClass]
    public class UnitTest1
    {   
        Chromosome chr = new Chromosome(5, 7);

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
    }
}
