using GeneticLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGeneticAlg
{
    [TestClass]
    public class TestGeneration
    {
        
        // GeneticAlgorithm ga = new GeneticAlgorithm(30,20,7,0,0,100,);
        

        static Chromosome ch1 = new Chromosome(10, 7,6);
        static Chromosome ch2 = new Chromosome(10, 7,6);
        IChromosome[] charr = ch1.Reproduce(ch2, 100);
       
        
        [TestMethod]
        public void TestConstructorGeneration()
        {
        }
    }
}
