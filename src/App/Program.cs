using Domain;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.PlayGame();
            Console.Read();
        }
    }
}
