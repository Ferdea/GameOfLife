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
            // ...    ...
            // .#. -> ...
            // ...    ...
            var input = new[,] { { false, false, false }, { false, true, false }, { false, false, false } };
            var expectedResult = new[,] { { false, false, false }, { false, false, false }, { false, false, false } };
            Test(input, expectedResult);
        }

        [Test]
        public void EveryOneIsAlive()
        {
            // .#.    ###
            // ### -> #.#
            // .#.    ###
            var input = new[,] {
                { false, true, false },
                { true, true, true },
                { false, true, false }
            };
            var expectedResult = new[,] {
                { true, true, true },
                { true, false, true },
                { true, true, true }
            };
            Test(input, expectedResult);
        }

        [Test]
        public void ThreeInOne()
        {
            // #.#    ...
            // ... -> .#.
            // #..    ...
            var input = new[,]
            {
                { true, false, true },
                { false, false, false },
                { true, false, false }
            };
            var expectedResult = new[,]
            {
                { false, false, false },
                { false, true, false },
                { false, false, false }
            };
            Test(input, expectedResult);
        }

        [Test]
        public void TwoCells()
        {
            // #..    ...
            // ... -> ...
            // ..#    ...
            var input = new[,]
            {
                { true, false, false },
                { false, false, false },
                { false, false, true }
            };
            var expectedResult = new[,]
            {
                { false, false, false },
                { false, false, false },
                { false, false, false }
            };
            Test(input, expectedResult);
        }

        [Test]
        public void Blinker()
        {
            // .#.    ...
            // .#. -> ###
            // .#.    ...
            var input = new[,]
            {
                { false, true, false },
                { false, true, false },
                { false, true, false }
            };
            var expectedResult = new[,]
            {
                { false, false, false },
                { true, true, true },
                { false, false, false }
            };
            Test(input, expectedResult);
        }

        [Test]
        public void Population()
        {

            //.#.#.     ..##.
            //..#.#     .##..
            //..#.. --> .#.#.
            //#....     .#...
            //..#..     .....
            var input = new bool[,] {
                { false, true, false, true, false },
                { false, false, true, false, true },
                { false, false, true, false, false },
                { true, false, false, false, false },
                { false, false, true, false, false }

            };
            var expectedResult = new bool[,] {
                { false, false, true, true, false },
                { false, true, true, false, false },
                { false, true, false, true, false },
                { false, true, false, false, false },
                { false, false, false, false, false }
            };
            Test(input, expectedResult);
        }

        [Test]
        public void Symmetry()
        {
            // ##.    ...
            // ... -> #-#
            // .##    ...
            var input = new[,]
            {
                { true, true, false },
                { false, false, false },
                { false, true, true }
            };
            var expectedResult = new[,]
            {
                { false, false, false },
                { true, false, true },
                { false, false, false }
            };
            Test(input, expectedResult);
        }

        [Test]
        public void ThreeOClock()
        {
            // .#.    .##
            // .## -> .##
            // ...    ...
            var input = new[,]
            {
                { false, true, false },
                { false, true, true },
                { false, false, false }
            };
            var expectedResult = new[,]
            {
                { false, true, true },
                { false, true, true },
                { false, false, false }
            };
            Test(input, expectedResult);
        }

        [Test]
        public void Tetris()
        {
            // ...    .#.
            // ### -> ##.
            // #..    #..
            var input = new[,]
            {
                { false, false, false },
                { true, true, true },
                { true, false, false }
            };
            var expectedResult = new[,]
            {
                { false, true, false },
                { true, true, false },
                { true, false, false }
            };
            Test(input, expectedResult);
        }

        [Test]
        public void Ellipse()
        {
            // ....    ....
            // .##. -> .##.
            // #..#    #..#
            // .##.    .##.
            var input = new[,]
            {
                { false, false, false, false },
                { false, true, true, false },
                { true, false, false, true },
                { false, true, true, false }
            };
            var expectedResult = new[,]
            {
                { false, false, false, false },
                { false, true, true, false },
                { true, false, false, true },
                { false, true, true, false }
            };
            Test(input, expectedResult);
        }

    }
}