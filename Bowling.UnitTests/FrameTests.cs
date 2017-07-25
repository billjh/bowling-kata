using System;
using NUnit.Framework;

namespace Bowling.UnitTests
{
    [TestFixture]
    public class FrameTests
    {
        [TestCase(11, 0)]
        [TestCase(0, 11)]
        [TestCase(9, 2)]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FrameConstructor_Should_ThrowException_OnInvalidArguments(int firstBall, int secondBall)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Frame(firstBall, secondBall);
        }

        [TestCase(0, 0)]
        [TestCase(0, 5)]
        [TestCase(0, 10)]
        [TestCase(5, 0)]
        [TestCase(10, 0)]
        [TestCase(3, 3)]
        [TestCase(5, 5)]
        public void FrameConstructor_Should_Not_ThrowExcpetion_OnValidArguments(int firstBall, int secondBall)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Frame(firstBall, secondBall);
        }

        [TestCase(10, 0, ExpectedResult = true)]
        [TestCase(0, 0, ExpectedResult = false)]
        [TestCase(0, 10, ExpectedResult = false)]
        [TestCase(5, 5, ExpectedResult = false)]
        public bool IsStrike_Should_GiveCorrectResult(int firstBall, int secondBall)
        {
            return new Frame(firstBall, secondBall).IsStrike;
        }

        [TestCase(0, 10, ExpectedResult = true)]
        [TestCase(0, 5, ExpectedResult = false)]
        [TestCase(5, 5, ExpectedResult = true)]
        [TestCase(10, 0, ExpectedResult = false)]
        public bool IsSpare_Should_GiveCorrectResult(int firstBall, int secondBall)
        {
            return new Frame(firstBall, secondBall).IsSpare;
        }
    }
}
