using Common;

namespace Domain.tests
{
    public class TicTacToeTests
    {
        [Fact]
        public void TestMakeMove_ValidMove_ReturnsTrue()
        {
            // Arrange
            TicTacToe game = new TicTacToe();

            // Act
            bool result = game.MakeMove(0, 0);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TestMakeMove_InvalidMove_ReturnsFalse()
        {
            // Arrange
            TicTacToe game = new TicTacToe();
            game.MakeMove(0, 0); // Make a valid move

            // Act
            bool result = game.MakeMove(0, 0); // Try to make the same move again

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestGetWinner_NoWinner_ReturnsEmpty()
        {
            // Arrange
            TicTacToe game = new TicTacToe();

            // Act
            CellOptions winner = game.GetWinner();

            // Assert
            Assert.Equal(CellOptions.Empty, winner);
        }

        [Fact]
        public void TestGetWinner_RowWin_ReturnsCorrectWinner()
        {
            // Arrange
            TicTacToe game = new TicTacToe();
            game.MakeMove(0, 0); // X
            game.MakeMove(1, 0); // O
            game.MakeMove(0, 1); // X
            game.MakeMove(1, 1); // O
            game.MakeMove(0, 2); // X

            // Act
            CellOptions winner = game.GetWinner();

            // Assert
            Assert.Equal(CellOptions.Cross, winner);
        }

        [Fact]
        public void TestGetWinner_ColumnWin_ReturnsCorrectWinner()
        {
            // Arrange
            TicTacToe game = new TicTacToe();
            game.MakeMove(0, 0); // X
            game.MakeMove(0, 1); // O
            game.MakeMove(1, 0); // X
            game.MakeMove(1, 1); // O
            game.MakeMove(2, 0); // X

            // Act
            CellOptions winner = game.GetWinner();

            // Assert
            Assert.Equal(CellOptions.Cross, winner);
        }

        [Fact]
        public void TestGetWinner_DiagonalWin_ReturnsCorrectWinner()
        {
            // Arrange
            TicTacToe game = new TicTacToe();
            game.MakeMove(0, 0); // X
            game.MakeMove(0, 1); // O
            game.MakeMove(1, 1); // X
            game.MakeMove(0, 2); // O
            game.MakeMove(2, 2); // X

            // Act
            CellOptions winner = game.GetWinner();

            // Assert
            Assert.Equal(CellOptions.Cross, winner);
        }

        [Fact]
        public void TestGetWinner_Draw_ReturnsEmpty()
        {
            // Arrange
            TicTacToe game = new TicTacToe();
            game.MakeMove(0, 0); // X
            game.MakeMove(0, 1); // O
            game.MakeMove(0, 2); // X
            game.MakeMove(1, 1); // O
            game.MakeMove(1, 0); // X
            game.MakeMove(1, 2); // O
            game.MakeMove(2, 1); // X
            game.MakeMove(2, 0); // O
            game.MakeMove(2, 2); // X

            // Act
            CellOptions winner = game.GetWinner();

            // Assert
            Assert.Equal(CellOptions.Empty, winner);
        }
    }

}