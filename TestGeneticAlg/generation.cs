using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticLibrary;

namespace TestGeneticAlg
{
  [TestMethod]
  public class generation
  {
    // public void TestDefaultArrayLength()
    static Chromosome chromosome01 = new Chromosome(1, 2,3);
    static Chromosome chromosome02 = new Chromosome(1, 2,3);

    public static double fitnes(IChromosome chromosome, IGeneration generation){
      return 120;
    }
    public static GeneticAlgorithm _geneticAlgorithm = new GeneticAlgorithm(200, 247, 10, 2,  4, 100, fitnes, 10);
    public static IGeneration _generation = new Generation(_geneticAlgorithm , fitnes, 0);

    [TestMethod]
        public void TestGeneration()
        {
          Assert.AreEqual( );
        }
  }
}