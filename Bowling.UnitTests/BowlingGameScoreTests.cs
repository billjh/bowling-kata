using System.Collections.Generic;
using Bowling.UnitTests.TestCases;
using NUnit.Framework;

namespace Bowling.UnitTests
{
    [TestFixture]
    public class BowlingGameScoreTests
    {
        static readonly ScoreTestCase[] TestCases = {
            new ScoreTestCase
            {
                BowlingGame = new BowlingGame(new List<Frame>
                {
                    new Frame(9, 0),
                    new Frame(9, 0),
                    new Frame(9, 0),
                    new Frame(9, 0),
                    new Frame(9, 0),
                    new Frame(9, 0),
                    new Frame(9, 0),
                    new Frame(9, 0),
                    new Frame(9, 0),
                    new Frame(9, 0)
                }),
                ExpectedScore = 90
            }, 
            new ScoreTestCase
            {
                BowlingGame = new BowlingGame(new List<Frame>
                {
                    new Frame(10, 0),
                    new Frame(10, 0),
                    new Frame(10, 0),
                    new Frame(10, 0),
                    new Frame(10, 0),
                    new Frame(10, 0),
                    new Frame(10, 0),
                    new Frame(10, 0),
                    new Frame(10, 0),
                    new Frame(10, 0),
                    new Frame(10, 0),
                    new Frame(10, 0)
                }),
                ExpectedScore = 300
            }, 
            new ScoreTestCase
            {
                BowlingGame = new BowlingGame(new List<Frame>
                {
                    new Frame(5, 5),
                    new Frame(5, 5),
                    new Frame(5, 5),
                    new Frame(5, 5),
                    new Frame(5, 5),
                    new Frame(5, 5),
                    new Frame(5, 5),
                    new Frame(5, 5),
                    new Frame(5, 5),
                    new Frame(5, 5),
                    new Frame(5, 0)
                }),
                ExpectedScore = 150
            }, 
        };

        [Test, TestCaseSource("TestCases")]
        public void Score_Should_ReturnCorrectResult(ScoreTestCase testCase)
        {
            Assert.AreEqual(testCase.ExpectedScore, testCase.BowlingGame.Score);
        }
    }
}