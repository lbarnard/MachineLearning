using System;
using DigitRecognizer.Core;
using DigitRecognizer.Core.DistanceAlgorithms;

namespace DigitRecognizer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Manhattan();
            Euclidean();
            Console.ReadLine();
        }

        private static void Manhattan()
        {
            var manhattan = new Manhattan();
            var manhattanClassifier = new ParallelClassifier(manhattan, 3);

            var trainingPath = @"Data\train_full.csv";
            var training = DataReader.ReadObservations(trainingPath);
            Console.WriteLine("Training with Manhattan Classifier");
            manhattanClassifier.Train(training);
            Console.WriteLine("Training complete");

            var validationPath = @"Data\validate.csv";
            Console.WriteLine("Loading Validation Set");
            var validation = DataReader.ReadObservations(validationPath);
            Console.WriteLine("Validation Set Loaded");

            var evaluator = new ParallelEvaluator();

            Console.WriteLine("Validating...");
            Console.WriteLine("Started at  " + DateTime.Now );
            var correct = evaluator.Correct(validation, manhattanClassifier);
            Console.WriteLine("Completed at  " + DateTime.Now);
            Console.WriteLine("Manhattan Score: {0:P2}", correct);

        }

        private static void Euclidean()
        {
            var euclidean = new Euclidean();
            var euclideanClassifier = new ParallelClassifier(euclidean, 3);

            var trainingPath = @"Data\train_full.csv";
            Console.WriteLine("Training with Euclidean Classifier");
            var training = DataReader.ReadObservations(trainingPath);
            euclideanClassifier.Train(training);
            Console.WriteLine("Training complete");

            var validationPath = @"Data\validate.csv";
            Console.WriteLine("Loading Validation Set");
            var validation = DataReader.ReadObservations(validationPath);
            Console.WriteLine("Validation Set Loaded");

            var evaluator = new ParallelEvaluator();

            Console.WriteLine("Validating...");
            Console.WriteLine("Started at  " + DateTime.Now);
            var correct = evaluator.Correct(validation, euclideanClassifier);
            Console.WriteLine("Completed at  " + DateTime.Now);
            Console.WriteLine("Euclidean Score: {0:P2}", correct);

            Console.ReadLine();
        }
    }
}
