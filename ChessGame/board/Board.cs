namespace board
{
    class Board
    {
        public int          Rows   { get; set; }
        public int          Columns { get; set; }
        private Piece[,]    _pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _pieces = new Piece[Rows, Columns];
        }

        public Piece GetPiece(int row, int column)
        {
            return _pieces[row, column];
        }

        public Piece GetPiece(Position position)
        {
            return _pieces[position.Row, position.Column];
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (ExistsPieceInPosition(position))
            {
                throw new BoardException("Already exists a piece in this position!");
            }
            _pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public bool ExistsPieceInPosition(Position position)
        {
            ValidatePosition(position);
            return GetPiece(position) != null;
        }

        public void ValidatePosition(Position position)
        {
            if ((position.Row < 0
                || position.Column < 0
                || position.Row >= Rows
                || position.Column >= Columns)) {
                throw new BoardException("Invalid Position");
            }
        }
    }
}
