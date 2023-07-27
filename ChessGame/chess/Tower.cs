using board;

namespace chess
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        public override bool[,] AllowedMoviments()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];

            Position pos = new(Position.Row, Position.Column);

            // Verify Top Position
            pos.Row--;
            pos.Column = Position.Column;
            while (Board.IsValidatePosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row--;
            }

            // Verify Right Position
            pos.Row = Position.Row;
            pos.Column++;
            while (Board.IsValidatePosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column++;
            }

            // Verify Bottom Position
            pos.Row++;
            pos.Column = Position.Column;
            while (Board.IsValidatePosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row++;
            }

            // Verify Left Position
            pos.Row = Position.Row;
            pos.Column--;
            while (Board.IsValidatePosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column--;
            }

            return matrix;
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }
    }
}