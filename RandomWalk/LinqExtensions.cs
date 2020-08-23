using System;
using System.Collections.Generic;

namespace RandomWalk
{
    public static class LinqExtensions
    {
        public static double PopulationStandardDeviation(this IEnumerable<double> source) => Math.Sqrt(PopulationVariance(source));
        public static double SampleStandardDeviation(this IEnumerable<double> source) => Math.Sqrt(SampleVariance(source));

        public static double PopulationVariance(this IEnumerable<double> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            return CalculateVariance(source, false);
        }

        public static double SampleVariance(this IEnumerable<double> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            return CalculateVariance(source, true);
        }

        private static double CalculateVariance(IEnumerable<double> source, bool isSample)
        {
            int count = 0;
            double mean = 0;
            double sumOfDiffSquares = 0;

            foreach (double value in source)
            {
                count++;
                double delta = value - mean;
                mean += delta / count;
                sumOfDiffSquares = sumOfDiffSquares + delta * (value - mean);
            }

            // Switch calculation and item minimum based upon sample or population flag
            if (isSample)
            {
                return count <= 1 ? 0 : sumOfDiffSquares / (count - 1);
            }
            else
            {
                return count == 0 ? 0 : sumOfDiffSquares / count;
            }
        }
    }
}
