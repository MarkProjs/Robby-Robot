using System;
using GeneticLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGeneticAlg
{
    [TestClass]
    public class TestGeneration
    {
        
        // GeneticAlgorithm ga = new GeneticAlgorithm(30,20,7,0,0,100,);
        

         Chromosome ch1 = new Chromosome(20, 7,6);
         Chromosome ch2 = new Chromosome(20, 7,6);
        
       
        
        [TestMethod]
        public void TestConstructorLength()
        {
            IChromosome[] childrenArr = ch1.Reproduce(ch2, 100);
            Assert.AreEqual(childrenArr.Length, 20);
        }
        
   
    }
}
