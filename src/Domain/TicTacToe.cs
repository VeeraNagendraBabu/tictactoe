using Common;

namespace Domain
{
    public class TicTacToe
    {
        private const int BoardSize = 3;
        private CellOptions[] board;
        private CellOptions currentPlayer;

        public TicTacToe()
        {
            board = new CellOptions[BoardSize * BoardSize];
            currentPlayer = CellOptions.Cross;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = CellOptions.Empty;
            }
        }

        public bool IsBoardFull()
        {
            foreach (var cell in board)
            {
                if (cell == CellOptions.Empty)
                    return false;
            }
            return true;
        }

        public bool MakeMove(int row, int col)
        {
            int index = row * BoardSize + col;
            if (row < 0 || row >= BoardSize || col < 0 || col >= BoardSize || board[index] != CellOptions.Empty)
                return false;

            board[index] = currentPlayer;
            currentPlayer = currentPlayer == CellOptions.Cross ? CellOptions.Nought : CellOptions.Cross;
            return true;
        }

        public CellOptions GetWinner()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                if (CheckRow(i) || CheckColumn(i))
                    return board[i]; // Row or column win
            }

            if (CheckDiagonals())
                return board[4]; // Diagonal win

            return CellOptions.Empty; // No winner
        }

        private bool CheckRow(int row)
        {
            int startIndex = row * BoardSize;
            return board[startIndex] != CellOptions.Empty && board[startIndex] == board[startIndex + 1] && board[startIndex + 1] == board[startIndex + 2];
        }

        private bool CheckColumn(int col)
        {
            return board[col] != CellOptions.Empty && board[col] == board[col + BoardSize] && board[col + BoardSize] == board[col + BoardSize * 2];
        }

        private bool CheckDiagonals()
        {
            return (board[0] != CellOptions.Empty && board[0] == board[4] && board[4] == board[8]) ||
                   (board[2] != CellOptions.Empty && board[2] == board[4] && board[4] == board[6]);
        }

        public void PrintBoard()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    int index = i * BoardSize + j;
                    Console.Write(board[index] == CellOptions.Empty ? " - " : board[index] == CellOptions.Cross ? " X " : " O ");
                }
                Console.WriteLine();
            }
        }

        public void PlayGame()
        {
            while (GetWinner() == CellOptions.Empty && !IsBoardFull())
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("Current player: " + (currentPlayer == CellOptions.Cross ? "X" : "O"));
                Console.WriteLine("Enter row and column (e.g., '1, 1' for the first row and first column):");
                string input = Console.ReadLine();
                string[] coordinates = input.Split(',');

                if (coordinates.Length != 2 || !int.TryParse(coordinates[0], out int row) || !int.TryParse(coordinates[1], out int col))
                {
                    Console.WriteLine("Invalid input. Please enter row and column numbers separated by space.");
                    continue;
                }

                if (!MakeMove(row - 1, col - 1))
                {
                    Console.WriteLine("Invalid move. Please try again.");
                }
            }

            Console.Clear();
            PrintBoard();
            CellOptions winner = GetWinner();
            if (winner == CellOptions.Empty)
            {
                Console.WriteLine("It's a draw!");
            }
            else
            {
                Console.WriteLine($"Player {winner} wins!");
            }
        }
    }
}
