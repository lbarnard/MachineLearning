using System;
using System.Collections.Generic;

namespace DigitRecognizer.Core
{
    public class BasicClassifier : IClassifier
    {
        private IEnumerable<Observation> _trainingSet;
        private readonly ICalculateDistance _calculateDistance;

        public BasicClassifier(ICalculateDistance calculateDistance)
        {
            _calculateDistance = calculateDistance;
        }
        
        public void Train(IEnumerable<Observation> trainingSet)
        {
            _trainingSet = trainingSet;
        }

        public string Predict(int[] pixels)
        {
            Observation best = new Observation("",new int[0]);
            var shortestDistance = Double.MaxValue;

            foreach (var trainingObservation in _trainingSet)
            {
                var distance = _calculateDistance.Between(trainingObservation.Pixels, pixels);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    best = trainingObservation;
                }
            }
            return best.Label;
        }
    }
}
