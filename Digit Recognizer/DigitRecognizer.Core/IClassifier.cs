using System.Collections.Generic;

namespace DigitRecognizer.Core
{
    public interface IClassifier
    {
        void Train(IEnumerable<Observation> trainingSet);
        string Predict(int[] pixels);
    }
}
