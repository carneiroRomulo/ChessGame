using board;

namespace chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        public override bool[,] AllowedMoviments()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];

            Position pos = new(Position.Row, Position.Column);

            // Verify Top Position
            pos.Row--;
            if (Board.IsValidatePosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            // Verify Top/Right Position
            pos.Column++;
            if (Board.IsValidatePosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            // Verify Right Position
            pos.Row++;
            if (Board.IsValidatePosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            // Verify Bottom/Right Position
            pos.Row++;
            if (Board.IsValidatePosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            // Verify Bottom Position
            pos.Column--;
            if (Board.IsValidatePosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            // Verify Bottom/Left Position
            pos.Column--;
            if (Board.IsValidatePosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            // Verify Left Position
            pos.Row--;
            if (Board.IsValidatePosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
            }

            // Verify Top/Left Position
            pos.Row--;
            if (Board.IsValidatePosition(pos) && CanMove(pos))
            {
                matrix[pos.Row, pos.Column] = true;
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
