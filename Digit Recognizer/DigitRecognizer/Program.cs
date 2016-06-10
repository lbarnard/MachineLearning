using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitRecognizer.Core;
using DigitRecognizer.Core.DistanceAlgorithms;

namespace DigitRecognizer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Manhattan();
            Console.ReadLine();
        }

        private static void Manhattan()
        {
            var manhattan = new Manhattan();
            var manhattanClassifier = new BasicClassifier(manhattan);

            var trainingPath = @"Data\train.csv";
            var training = DataReader.ReadObservations(trainingPath);
            Console.WriteLine("Training with Manhattan Classifier");
            manhattanClassifier.Train(training);
            Console.WriteLine("Training complete");

            var validationPath = @"Data\test.csv";
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
            var euclideanClassifier = new BasicClassifier(euclidean);

            var trainingPath = @"Data\train.csv";
            var training = DataReader.ReadObservations(trainingPath);
            euclideanClassifier.Train(training);

            var validationPath = @"Data\test.csv";
            var validation = DataReader.ReadObservations(validationPath);

            var evaluator = new ParallelEvaluator();

            var correct = evaluator.Correct(validation, euclideanClassifier);
            Console.WriteLine("Euclidean Score: {0:P2}", correct);


            Console.ReadLine();
        }
    }
}
