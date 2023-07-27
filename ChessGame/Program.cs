using board;
using chess;

namespace ChessGame
{
    class Program
    {
        static void Main()
        {
            try
            {
                ChessMatch chessMatch = new();
               

                Screen.PrintBoard(chessMatch.Board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}