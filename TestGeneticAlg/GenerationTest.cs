using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticLibrary;

namespace TestGeneticAlg
{
    [TestClass]
    public class GenerationTest
    { 
      static double fitnessFunc(IChromosome chromosome, IGeneration generation) {
        return 0.5;
      }
      GeneticAlgorithm GAM = new GeneticAlgorithm(5, 3, 7, 0.2, 0.6, 2, fitnessFunc, 1);
      Generation gen = new Generation(GAM, fitnessFunc, 1);

        [TestMethod]
        public void TestAverage()
        {
        }
    }
}