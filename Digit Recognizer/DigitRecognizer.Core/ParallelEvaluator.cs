using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitRecognizer.Core
{
    public class ParallelEvaluator
    {
        public double Correct(IEnumerable<Observation> validationSet, IClassifier classifier)
        {
            List<double> scores = new List<double>();
            int progress = 0;
            decimal currentProgress = 0;
            var observations  = validationSet as IList<Observation> ?? validationSet.ToList();
            Parallel.ForEach(observations, new ParallelOptions { MaxDegreeOfParallelism = 8 }, observation =>
                                            {
                                                var score = Score(observation, classifier);
                                                scores.Add(score);
                                                progress++;
                                                var progressPercentage = Math.Round((decimal) progress/observations.Count*100, 0);
                                                if (progressPercentage != currentProgress)
                                                {
                                                    currentProgress = progressPercentage;
                                                    Console.WriteLine("Progress " + progressPercentage + "%");
                                                }
                                            });
            return scores.Average();
        }

        private double Score(Observation observation, IClassifier classifier)
        {
            return classifier.Predict(observation.Pixels) == observation.Label ? 1.0 : 0.0;
        }
    }
}
