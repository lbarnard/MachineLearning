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
    class Program
    {
        static void Main(string[] args)
        {
            var euclidean = new Euclidean();
            var euclideanClassifier = new BasicClassifier(euclidean);

            var manhattan = new Manhattan();
            var manhattanClassifier = new BasicClassifier(manhattan);

            var trainingPath = @"Data\train_lite.csv";
            var training = DataReader.ReadObservations(trainingPath);
            euclideanClassifier.Train(training);
            manhattanClassifier.Train(training);

            var validationPath = @"Data\train.csv";
            var validation = DataReader.ReadObservations(validationPath);

            var evaluator = new Evaluator();

            var correct = evaluator.Correct(validation, manhattanClassifier);
            Console.WriteLine("Manhattan Score: {0:P2}", correct);

            correct = evaluator.Correct(validation, euclideanClassifier);
            Console.WriteLine("Euclidean Score: {0:P2}", correct);

  
        Console.ReadLine();
        }
    }
}
