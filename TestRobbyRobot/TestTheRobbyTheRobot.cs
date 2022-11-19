using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobbyTheRobot;
using GeneticLibrary;

namespace RobbyTheRobotTest
{
    [TestClass]
    public class TestRobbyRobot
    {

      // private IRobbyTheRobot _robbyTheRobot = new RobbyTheRobot( 200, 200, 10, 0);
      public static double fitnes(IChromosome chromosome, IGeneration generation){
          return 1;
        }
      public static GeneticAlgorithm _geneticAlgorithm = new GeneticAlgorithm(1, 1, 1, 1,  1, 1, fitnes, 0);
      public static IGeneration _generation = new Generation(_geneticAlgorithm , fitnes, 0);
      private IRobbyTheRobot _robbyTheRobot = Robby.CreateRobby(1, 10, 1, 0);
      private Chromosome _chromosome = new Chromosome(243, 7, 0);



      [TestMethod]
      public void TestNumberOfActions()
      {
          Assert.AreEqual( _robbyTheRobot.NumberOfActions, 200);
      }

      [TestMethod]
      public void TestNumberOfTestGrids()
      {
          Assert.AreEqual( _robbyTheRobot.NumberOfTestGrids, 100);
      }

      [TestMethod]
      public void TestGridSize()
      {
          Assert.AreEqual( _robbyTheRobot.GridSize, 100);
      }

      [TestMethod]
      public void TestNumberOfGenerations()
      {
          Assert.AreEqual( _robbyTheRobot.NumberOfGenerations, 200);
      }

      [TestMethod]
      public void TestMutationRate()
      {
          Assert.AreEqual( _robbyTheRobot.MutationRate, 0.05);
      }

      [TestMethod]
      public void TestEliteRate()
      {
          Assert.AreEqual( _robbyTheRobot.EliteRate, 0.05);
      }

      [TestMethod]
      public void TestComputeFitness()
      {   
          double fitness = (_robbyTheRobot as RobbyTheRobot.RobbyTheRobot).computeFitness( _chromosome, _generation);
          Assert.AreEqual( fitness, 0);
      }

  }
}