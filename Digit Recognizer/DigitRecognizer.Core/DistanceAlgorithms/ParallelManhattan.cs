using System;
using System.Threading;
using System.Threading.Tasks;

namespace DigitRecognizer.Core.DistanceAlgorithms
{
    public class ParallelManhattan : ICalculateDistance
    {
        public double Between(int[] pixels1, int[] pixels2)
        {
            long distance = 0;
            Parallel.For(0, pixels1.Length, new ParallelOptions { MaxDegreeOfParallelism = 2 }, i =>
            {
                Interlocked.Add(ref distance, Math.Abs(pixels1[i] - pixels2[i]));
            });

            return distance;
        }
    }
}
