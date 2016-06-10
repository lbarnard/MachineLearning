using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitRecognizer.Core
{
    public class ParallelClassifier : IClassifier
    {
        private IEnumerable<Observation> _trainingSet;
        private readonly ICalculateDistance _calculateDistance;
        private readonly int _maxDegreeOfParallelism;

        public ParallelClassifier(ICalculateDistance calculateDistance, int parallelism)
        {
            _calculateDistance = calculateDistance;
            _maxDegreeOfParallelism = parallelism;
        }

        public void Train(IEnumerable<Observation> trainingSet)
        {
            _trainingSet = trainingSet;
        }

        public string Predict(int[] pixels)
        {
            Observation best = new Observation("", new int[0]);
            var shortestDistance = Double.MaxValue;

            Parallel.ForEach(_trainingSet, new ParallelOptions {MaxDegreeOfParallelism = _maxDegreeOfParallelism }, trainingObservation =>
            {
                var distance = _calculateDistance.Between(trainingObservation.Pixels, pixels);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    best = trainingObservation;
                }
            });
            
            return best.Label;
        }
    }
}
