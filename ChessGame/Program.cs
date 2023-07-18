using board;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new();

            Console.WriteLine("board: " + board.ToString());
        }
    }
}