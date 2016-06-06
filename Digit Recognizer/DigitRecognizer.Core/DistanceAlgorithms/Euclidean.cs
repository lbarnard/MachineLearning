using System;

namespace DigitRecognizer.Core.DistanceAlgorithms
{
    public class Euclidean : ICalculateDistance
    {
        public double Between(int[] pixels1, int[] pixels2)
        {
            double distance = 0;

            for (var i = 0; i < pixels1.Length; i++)
            {
                distance += Math.Pow(pixels1[i] - pixels2[i], 2);
            }
            return distance;
        }
    }
}
