using System;
using NUnit.Framework;

namespace GameOfLife
{
    [TestFixture]
    public class GameTests
    {
        private void Test(bool[,] input, bool[,] expectedResult)
        {
            var actualResult = Game.NextStep(input);
            Assert.AreEqual(expectedResult.GetLength(0), actualResult.GetLength(0));
            Assert.AreEqual(expectedResult.GetLength(1), actualResult.GetLength(1));
            for (var i = 0; i < expectedResult.GetLength(0); i++) for (var j = 0; j < expectedResult.GetLength(1); j++)
                Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void OneCellTest()
        {
            var input = new bool[,]{{false, false, false}, {false, true, false}, {false, false, false}};
            var expectedResult = new bool[,] {{false, false, false}, {false, false, false}, {false, false, false}};
            Test(input, expectedResult);
        }

        [Test]
        public void EveryOneIsAlive()
        {
            var input = new bool[,] { 
                { false, true, false }, 
                { true, true, true },
                { false, true, false } 
            };
            var expectedResult = new bool[,] {
                { true, true, true }, 
                { true, false, true }, 
                { true, true, true }
            };
            Test(input, expectedResult);
        }
    }
}