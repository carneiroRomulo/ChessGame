using System.Collections.Generic;
using board;

namespace chess
{
    class ChessMatch
    {
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public Board Board { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captureds;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.WHITE;
            Finished = false;
            pieces = new();
            captureds = new();
            StartPositions();
        }

        public void ExecuteMoviment(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementMovimentQuantities();

            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(piece, destination);

            if (capturedPiece != null)
            {
                captureds.Add(capturedPiece);
            }
        }

        public void PlayerRound(Position origin, Position destination)
        {
            ExecuteMoviment(origin, destination);
            Round++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position origin)
        {
            if (Board.GetPiece(origin) == null)
            {
                throw new BoardException("There is no piece in the choosen origin point");
            }
            if (CurrentPlayer != Board.GetPiece(origin).Color)
            {
                throw new BoardException("The choosen piece belongs to the other player");
            }
            if (!Board.GetPiece(origin).ExistsPossibleMoviment())
            {
                throw new BoardException("The choosen piece cannot move");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!Board.GetPiece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Invalid destination position");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.WHITE)
            {
                CurrentPlayer = Color.BLACK;
            }
            else
            {
                CurrentPlayer = Color.WHITE;
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {   
            HashSet<Piece> capturedsByColor = new();
            foreach (Piece piece in captureds)
            {
                if (piece.Color == color)
                {
                    capturedsByColor.Add(piece);
                }
            }
            return capturedsByColor;
            
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> piecesInGameByColor = new();
            foreach (Piece piece in captureds)
            {
                if (piece.Color == color)
                {
                    piecesInGameByColor.Add(piece);
                }
            }
            piecesInGameByColor.ExceptWith(CapturedPieces(color));

            return piecesInGameByColor;
        }

        public void PlaceNewPiece(char col, int row, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(col, row).ToPosition());
            pieces.Add(piece);
        }

        private void StartPositions()
        {
            PlaceNewPiece('C', 1, new Tower(Board, Color.WHITE));
            PlaceNewPiece('C', 2, new Tower(Board, Color.WHITE));
            PlaceNewPiece('D', 2, new Tower(Board, Color.WHITE));
            PlaceNewPiece('E', 2, new Tower(Board, Color.WHITE));
            PlaceNewPiece('E', 1, new Tower(Board, Color.WHITE));
            PlaceNewPiece('D', 1, new King(Board, Color.WHITE));

            PlaceNewPiece('C', 7, new Tower(Board, Color.BLACK));
            PlaceNewPiece('C', 8, new Tower(Board, Color.BLACK));
            PlaceNewPiece('D', 7, new Tower(Board, Color.BLACK));
            PlaceNewPiece('E', 7, new Tower(Board, Color.BLACK));
            PlaceNewPiece('E', 8, new Tower(Board, Color.BLACK));
            PlaceNewPiece('D', 8, new King(Board, Color.BLACK));

            //for (int i = 1; i <= 8; i++)
            //{
            //    Board.PlacePiece(new Pawn(Board, Color.BLACK), new ChessPosition(c, 2).ToPosition());
            //    Board.PlacePiece(new Pawn(Board, Color.WHITE), new ChessPosition(c, 7).ToPosition());

            //    c++;
            //}
            //Board.PlacePiece(new Tower(Board, Color.BLACK), new ChessPosition('A', 1).ToPosition());
            //Board.PlacePiece(new Tower(Board, Color.BLACK), new ChessPosition('H', 1).ToPosition());
            //Board.PlacePiece(new Knight(Board, Color.BLACK), new ChessPosition('B', 1).ToPosition());
            //Board.PlacePiece(new Knight(Board, Color.BLACK), new ChessPosition('G', 1).ToPosition());
            //Board.PlacePiece(new Bishop(Board, Color.BLACK), new ChessPosition('C', 1).ToPosition());
            //Board.PlacePiece(new Bishop(Board, Color.BLACK), new ChessPosition('F', 1).ToPosition());
            //Board.PlacePiece(new King(Board, Color.BLACK), new ChessPosition('E', 1).ToPosition());
            //Board.PlacePiece(new Queen(Board, Color.BLACK), new ChessPosition('D', 1).ToPosition());

            //.PlacePiece(new Tower(Board, Color.WHITE), new ChessPosition('A', 8).ToPosition());
            //Board.PlacePiece(new Tower(Board, Color.WHITE), new ChessPosition('H', 8).ToPosition());
            //Board.PlacePiece(new Knight(Board, Color.WHITE), new ChessPosition('B', 8).ToPosition());
            //Board.PlacePiece(new Knight(Board, Color.WHITE), new ChessPosition('G', 8).ToPosition());
            //Board.PlacePiece(new Bishop(Board, Color.WHITE), new ChessPosition('C', 8).ToPosition());
            //Board.PlacePiece(new Bishop(Board, Color.WHITE), new ChessPosition('F', 8).ToPosition());
            //Board.PlacePiece(new King(Board, Color.WHITE), new ChessPosition('E', 8).ToPosition());
            //Board.PlacePiece(new Queen(Board, Color.WHITE), new ChessPosition('D', 8).ToPosition());
        }
    }
}
