using System;
using System.Collections.Generic;

namespace RandomWalk
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random(0);
            var means = new List<double>();

            for (int i = 0; i < 10; i++)
            {
                var sim = new WalkSimulation(1000, 100, random);
                Console.WriteLine($"Mean/SD: {sim.Mean} / {sim.StandardDeviation}");
                means.Add(sim.Mean);
            }

            Console.WriteLine($"Seed SD: {means.PopulationStandardDeviation()}");
        }
    }
}
