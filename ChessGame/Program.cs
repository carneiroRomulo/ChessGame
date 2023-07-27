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

                while (!chessMatch.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(chessMatch.Board);

                    Console.WriteLine();
                    Console.Write("Initial Position (Ex. A2): ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    Console.Clear();
                    bool[,] allowedPositions = chessMatch.Board.GetPiece(origin).AllowedMoviments();
                    Screen.PrintBoard(chessMatch.Board, allowedPositions);

                    Console.WriteLine();
                    Console.Write("Final Position (Ex. B3): ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    chessMatch.ExecuteMoviment(origin, destination);
                }

            }
            catch (BoardException)
            {
                throw;
            }
        }
    }
}