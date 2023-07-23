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
                Board board = new(8, 8);

                board.PlacePiece(
                    new Tower(board, Color.BLACK),
                    new Position(0, 0)
                );
                board.PlacePiece(
                    new Tower(board, Color.BLACK),
                    new Position(1, 3)
                );
                board.PlacePiece(
                    new King(board, Color.BLACK),
                    new Position(0, 2)
                );
                board.PlacePiece(
                    new Tower(board, Color.WHITE),
                    new Position(3, 5)
                );

                Screen.PrintBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}