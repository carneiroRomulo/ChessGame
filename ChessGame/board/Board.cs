namespace board
{
    class Board
    {
        public int          Lines   { get; set; }
        public int          Columns { get; set; }
        private Piece[,]    _pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            _pieces = new Piece[Lines, Columns];
        }

        public Piece GetPiece(int line, int column)
        {
            return _pieces[line, column];
        }

        public Piece GetPiece(Position position)
        {
            return _pieces[position.Line, position.Column];
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (ExistsPieceInPosition(position))
            {
                throw new BoardException("Already exists a piece in this position!");
            }
            _pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public bool ExistsPieceInPosition(Position position)
        {
            ValidatePosition(position);
            return GetPiece(position) != null;
        }

        public void ValidatePosition(Position position)
        {
            if ((position.Line < 0
                || position.Column < 0
                || position.Line >= Lines
                || position.Column >= Columns)) {
                throw new BoardException("Invalid Position");
            }
        }
    }
}
