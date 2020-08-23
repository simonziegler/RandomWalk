using System;
using System.Collections.Generic;

namespace RandomWalk
{
    public class ParticleWalk
    {
        public int NumSteps { get; private set; }
        public List<Point> Path { get; private set; }
        public Point EndPoint { get; private set; }

        public ParticleWalk(int numSteps, Random random)
        {
            NumSteps = numSteps;
            Path = new List<Point>();

            var curr = new Point();
            Path.Add(curr);

            for (int i = 0; i < numSteps; i++)
            {
                curr = curr.Add(Point.Spherical(1, 2 * Math.PI * random.NextDouble(), 2 * Math.PI * random.NextDouble()));

                Path.Add(curr);
            }

            EndPoint = curr;
        }
    }
}
