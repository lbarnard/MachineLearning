using System;

namespace DigitRecognizer.Core.DistanceAlgorithms
{
    public class Euclidean : ICalculateDistance
    {
        public double Between(int[] pixels1, int[] pixels2)
        {
            if (pixels1.Length != pixels2.Length)
            {
                throw new ArgumentException("Inconsistent image sizes.");
            }

            var length = pixels1.Length;
            double distance = 0;

            for (var i = 0; i < length; i++)
            {
                distance += Math.Pow(pixels1[i] - pixels2[i], 2);
            }
            return distance;
        }
    }
}
