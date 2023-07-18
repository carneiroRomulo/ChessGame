using board;

namespace ChessGame
{
    class Program
    {
        static void Main()
        {
            Board board = new();

            Screen.PrintBoard(board);
        }
    }
}