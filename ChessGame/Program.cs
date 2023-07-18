using board;
using chess;

namespace ChessGame
{
    class Program
    {
        static void Main()
        {
            ChessPosition chessPosition = new('C', 7);

            Console.WriteLine(chessPosition.ToString());
            Console.WriteLine(chessPosition.ToPosition());
            Console.ReadLine();
            //try
            //{
            //    Board board = new(8, 8);

            //    board.PlacePiece(
            //        new Tower(board, Color.BLACK),
            //        new Position(0, 0)
            //    );
            //    board.PlacePiece(
            //        new King(board, Color.BLACK),
            //        new Position(0, 1)
            //    );

            //    Screen.PrintBoard(board);
            //}
            //catch (BoardException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }
    }
}