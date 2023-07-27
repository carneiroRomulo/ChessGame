using board;
using System;

namespace chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int     turn;
        private Color   currentPlayer;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.WHITE;
            StartPositions();

        }

        public void ExecuteMoviment(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementMovimentQuantities();

            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(piece, destination);

        }

        private void StartPositions()
        {
            char c = 'A';

            for (int i = 1;  i <= 8; i++)
            {
                Board.PlacePiece(new Pawn(Board, Color.BLACK),  new ChessPosition(c, 2).ToPosition());
                Board.PlacePiece(new Pawn(Board, Color.WHITE),  new ChessPosition(c, 7).ToPosition());

                c++;
            }
            Board.PlacePiece(new Tower  (Board, Color.BLACK),   new ChessPosition('A', 1).ToPosition());
            Board.PlacePiece(new Tower  (Board, Color.BLACK),   new ChessPosition('H', 1).ToPosition());
            Board.PlacePiece(new Knight (Board, Color.BLACK),   new ChessPosition('B', 1).ToPosition());
            Board.PlacePiece(new Knight (Board, Color.BLACK),   new ChessPosition('G', 1).ToPosition());
            Board.PlacePiece(new Bishop (Board, Color.BLACK),   new ChessPosition('C', 1).ToPosition());
            Board.PlacePiece(new Bishop (Board, Color.BLACK),   new ChessPosition('F', 1).ToPosition());
            Board.PlacePiece(new King   (Board, Color.BLACK),   new ChessPosition('E', 1).ToPosition());
            Board.PlacePiece(new Queen  (Board, Color.BLACK),   new ChessPosition('D', 1).ToPosition());

            Board.PlacePiece(new Tower  (Board, Color.WHITE),   new ChessPosition('A', 8).ToPosition());
            Board.PlacePiece(new Tower  (Board, Color.WHITE),   new ChessPosition('H', 8).ToPosition());
            Board.PlacePiece(new Knight (Board, Color.WHITE),   new ChessPosition('B', 8).ToPosition());
            Board.PlacePiece(new Knight (Board, Color.WHITE),   new ChessPosition('G', 8).ToPosition());
            Board.PlacePiece(new Bishop (Board, Color.WHITE),   new ChessPosition('C', 8).ToPosition());
            Board.PlacePiece(new Bishop (Board, Color.WHITE),   new ChessPosition('F', 8).ToPosition());
            Board.PlacePiece(new King   (Board, Color.WHITE),   new ChessPosition('E', 8).ToPosition());
            Board.PlacePiece(new Queen  (Board, Color.WHITE),   new ChessPosition('D', 8).ToPosition());
        }
    }
}
