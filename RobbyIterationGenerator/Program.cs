using System;

namespace RobbyIterationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] list = {98, 23, 97, 36, 77};
         Console.WriteLine("Original Unsorted List");
         foreach (int i in list) {
            Console.Write(i + " ");
         }
         Array.Sort(list);
         Console.WriteLine("sorted List");
         for(int i=0; i<list.Length; i++) {
            Console.Write(list[i] + " ");
         }

        }
    }
}
