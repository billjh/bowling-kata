using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Bowling.UnitTests
{
    [TestFixture]
    public class BowlingGameTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BowlingGameConstructor_Should_ThrowNullException_WhenPassInNull()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new BowlingGame(null);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(9)]
        [TestCase(13)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BowlingGameConstructor_Should_ThrowArgumentOutOfRangeException_WhenPassInIncorrectNumberOfFrames(int numOfFrames)
        {
            var frames = new List<Frame>();
            for (var i = 0; i < numOfFrames; i++)
            {
                frames.Add(new Frame(0, 0));
            }

            // pre-condition
            Assert.AreEqual(numOfFrames, frames.Count);

            // ReSharper disable once ObjectCreationAsStatement
            new BowlingGame(frames);
        }

        [TestCase(10, 0)]
        [TestCase(5, 5)]
        [ExpectedException(typeof(ArgumentException))]
        public void BowlingGameConstructor_Should_ThrowArgumentException_When_HasTenFrames_And_TenthFrame_IsSpareOrStrike(
            int firstBall, int secondBall)
        {
            var frames = new List<Frame>();
            for (var i = 0; i < 10; i++)
            {
                frames.Add(new Frame(firstBall, secondBall));
            }

            // pre-condition
            Assert.AreEqual(10, frames.Count);
            Assert.IsTrue(frames[9].IsSpare || frames[9].IsStrike);

            // ReSharper disable once ObjectCreationAsStatement
            new BowlingGame(frames);
        }

        [TestCase(11)]
        [TestCase(12)]
        [ExpectedException(typeof(ArgumentException))]
        public void BowlingGameConstructor_Should_ThrowArgumentException_When_HasMoreThanTenFrames_And_TenthFrame_IsNotSpareOrStrike(int numOfFrames)
        {
            var frames = new List<Frame>();
            for (var i = 0; i < numOfFrames; i++)
            {
                frames.Add(new Frame(3, 4));
            }

            // pre-condition
            Assert.Greater(frames.Count, 10);
            Assert.IsFalse(frames[9].IsSpare);
            Assert.IsFalse(frames[9].IsStrike);

            // ReSharper disable once ObjectCreationAsStatement
            new BowlingGame(frames);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void BowlingGameConstructor_Should_ThrowArgumentException_When_HasEleventFrame_And_Tenth_EleventhFrame_IsStrike()
        {
            var frames = new List<Frame>();
            for (var i = 0; i < 11; i++)
            {
                frames.Add(new Frame(10, 0));
            }

            // pre-condiction
            Assert.AreEqual(11, frames.Count);
            Assert.IsTrue(frames[10].IsStrike);

            // ReSharper disable once ObjectCreationAsStatement
            new BowlingGame(frames);
        }
    }
}