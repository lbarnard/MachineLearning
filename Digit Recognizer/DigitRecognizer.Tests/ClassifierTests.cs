using System.Collections.Generic;
using DigitRecognizer.Core;
using DigitRecognizer.Core.DistanceAlgorithms;
using NUnit.Framework;

namespace DigitRecognizer.Tests
{
    [TestFixture]
    public class ClassifierTests
    {
        [Test]
        public void EmptyTrainingSet()
        {
            var mockCalculator = new Manhattan();
            IClassifier classifier = new BasicClassifier(mockCalculator);

            classifier.Train(new List<Observation>());
            var actual = classifier.Predict(new int[0]);
            Assert.That(actual, Is.EqualTo(""));
        }

        [Test]
        public void VerySmallTrainingSet()
        {
            // With only one entry in the training set, every single prediction should be that single entry.
            var mockCalculator = new Manhattan();
            IClassifier classifier = new BasicClassifier(mockCalculator);

            classifier.Train(new List<Observation>() {new Observation("1",new[] {255} )});
            var actual = classifier.Predict(new[] {255});
            Assert.That(actual, Is.EqualTo("1"));

            actual = classifier.Predict(new[] { 0 });
            Assert.That(actual, Is.EqualTo("1"));
        }

        [Test]
        public void TwoItemsInTrainingSet_CheckEdgeConditions()
        {
            // check the edge/boundary of the greyscale 0-127 | 128-255
            var mockCalculator = new Manhattan();
            IClassifier classifier = new BasicClassifier(mockCalculator);

            classifier.Train(new List<Observation>()
            {
                new Observation("1", new[] { 0,0 }),
                new Observation("2", new[] { 255,255 }),
            });
            var actual = classifier.Predict(new[] { 127,127 });
            Assert.That(actual, Is.EqualTo("1"));

            actual = classifier.Predict(new[] { 128,128 });
            Assert.That(actual, Is.EqualTo("2"));
        }

    }
}
