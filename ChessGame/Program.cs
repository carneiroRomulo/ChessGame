using board;
using chess;

namespace ChessGame
{
    class Program
    {
        static void Main()
        {
            
            ChessMatch chessMatch = new();
            while (!chessMatch.Finished)
            {
                try
                {
                    Console.Clear();

                    Screen.PrintMatch(chessMatch);

                    Console.WriteLine();
                    Console.Write("Initial Position (Ex. A2): ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    chessMatch.ValidateOriginPosition(origin);

                    Console.Clear();
                    bool[,] allowedPositions = chessMatch.Board.GetPiece(origin).AllowedMoviments();
                    Screen.PrintBoard(chessMatch.Board, allowedPositions);

                    Console.WriteLine();
                    Console.WriteLine("Round: " + chessMatch.Round);
                    Console.WriteLine("Player: " + chessMatch.CurrentPlayer);
                    Console.WriteLine();
                    Console.Write("Final Position (Ex. B3): ");
                    Position destination = Screen.ReadChessPosition().ToPosition();
                    chessMatch.ValidateDestinationPosition(origin, destination);

                    chessMatch.PlayerRound(origin, destination);
                }
                catch (BoardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }

            }
            
        }
    }
}