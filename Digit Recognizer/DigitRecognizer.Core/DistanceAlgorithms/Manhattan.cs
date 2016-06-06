using System;

namespace DigitRecognizer.Core.DistanceAlgorithms
{
    public class Manhattan : ICalculateDistance
    {
        public double Between(int[] pixels1, int[] pixels2)
        {
            var distance = 0;

            for (var i = 0; i < pixels1.Length; i++)
            {
                distance += Math.Abs(pixels1[i] - pixels2[i]);
            }
            return distance;
        }
    }
}
