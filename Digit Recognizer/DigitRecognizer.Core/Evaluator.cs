using System.Collections.Generic;
using System.Linq;

namespace DigitRecognizer.Core
{
    public class Evaluator
    {
        public double Correct(IEnumerable<Observation> validationSet, IClassifier classifier)
        {
            return validationSet
                .Select(observation => Score(observation, classifier))
                .Average();
        }

        private double Score(Observation observation, IClassifier classifier)
        {
            return classifier.Predict(observation.Pixels) == observation.Label ? 1.0 : 0.0;
        }
    }
}
