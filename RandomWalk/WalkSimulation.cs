using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomWalk
{
    public class WalkSimulation
    {
        public int NumSims { get; private set; }
        public int NumSteps { get; private set; }
        public List<ParticleWalk> Walks { get; private set; }
        public double Mean { get; private set; }
        public double StandardDeviation { get; private set; }

        public WalkSimulation(int numSims, int numSteps, Random random)
        {
            NumSims = numSims;
            NumSteps = numSteps;
            Walks = new List<ParticleWalk>();

            for (int i = 0; i < numSims; i++)
            {
                Walks.Add(new ParticleWalk(numSteps, random));
            }

            Mean = Walks.Select(w => w.EndPoint.R).Average();
            StandardDeviation = Walks.Select(w => w.EndPoint.R).PopulationStandardDeviation();
        }
    }
}
