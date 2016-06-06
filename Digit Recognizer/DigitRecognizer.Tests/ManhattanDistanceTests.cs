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
    public class ManhattanDistanceTests
    {
        [Test]
        public void EmptyArraysAreEqual()
        {
            Manhattan distance = new Manhattan();
            var result = distance.Between(new int[0], new int[0]);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void UnequalDimensionArraysThrowsException()
        {
            Manhattan distance = new Manhattan();
            Assert.That(() => distance.Between(new int[0], new int[1]), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void ArraysReturnAppropriateDistances()
        {
            ICalculateDistance calculateDistance = new Manhattan();
            var actual = calculateDistance.Between(new int[1] {0}, new int[1] {255});
            Assert.That(actual, Is.EqualTo(255));
        }


    }
}
