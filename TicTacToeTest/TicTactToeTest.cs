using NUnit.Framework;
using TicTactToe;

namespace TicTactToeTest
{
    [TestFixture]
    public class TicTactToeTest
    {
        [Test]
        public void CreateGame_GameIsInTheCorrectState()
        {
            Game game = new Game();

            Assert.AreEqual(0, game.MovesCounter);
            Assert.AreEqual(State.Unset, game.GetState(1));
        }

        [Test]
        public void MakeMove_CounterShifts()
        {
            Game game = new Game();
            game.MakeMove(1);

            Assert.AreEqual(1, game.MovesCounter);
        }

        [Test]
        public void MakeInvalidMove_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var game = new Game();
                game.MakeMove(0);
            });
        }

        [Test]
        public void MoveOnTheSameSquare_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var game = new Game();
                game.MakeMove(1);
                game.MakeMove(1);
            });
        }

        [TestCase(State.Cross, 1)]
        [TestCase(State.Zero, 2)]
        [TestCase(State.Cross, 3)]
        [TestCase(State.Zero, 4)]
        public void MakingMoves_SetStateCorrectly(Enum enumState, int state)
        {
            Game game = new Game();
            MakeMoves(game, 1, 2, 3, 4 );

            Assert.AreEqual(enumState, game.GetState(state));
        }

        [Test]
        public void GetWinner_ZeroesWinVertically_ReturnsZeroes()
        {
            Game game = new Game();
            // 2, 5, 8 - zeroes win
            MakeMoves(game, 1, 2, 3, 5, 7, 8);

            Assert.AreEqual(Winner.Zeroes, game.GetWinner());
        }

        [Test]
        public void GetWinner_CrossesWinDiagonal_ReturnsCrosses()
        {
            Game game = new Game();
            // 1, 5, 9 - crosses win
            MakeMoves(game, 1, 4, 5, 2, 9);

            Assert.AreEqual(Winner.Crosses, game.GetWinner());
        }

        [Test]
        public void GetWinner_GameIsUnfinished_ReturnsGameIsUnfinished()
        {
            Game game = new Game();
            MakeMoves(game, 1, 2, 4);
            
            Assert.AreEqual(Winner.GameIsUInfinished, game.GetWinner());
        }

        private void MakeMoves(Game game, params int[] indexes)
        {
            foreach (var index in indexes)
            {
                game.MakeMove(index);
            }
        }
    }
}