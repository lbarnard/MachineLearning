using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitRecognizer.Core;
using DigitRecognizer.Core.DistanceAlgorithms;
using NUnit.Framework;

namespace DigitRecognizer.Tests
{
    [TestFixture]
    public class EuclideanDistanceTests
    {
        [Test]
        public void EmptyArraysAreEqual()
        {
            ICalculateDistance calculateDistance = new Euclidean();
            var result = calculateDistance.Between(new int[0], new int[0]);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void UnequalDimensionArraysThrowsException()
        {
            ICalculateDistance calculateDistance = new Euclidean();
            Assert.That(() => calculateDistance.Between(new int[0], new int[1]), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void ArraysReturnAppropriateDistances()
        {
            ICalculateDistance calculateDistance = new Euclidean();
            var actual = calculateDistance.Between(new int[1] { 0 }, new int[1] { 255 });
            Assert.That(actual, Is.EqualTo(65025));

            actual = calculateDistance.Between(new int[1] { 0 }, new int[1] { 2 });
            Assert.That(actual, Is.EqualTo(4));

        }

    }
}
