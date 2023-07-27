namespace board
{
    abstract class Piece
    {
        public Position?    Position            { get; set; }
        public Board        Board               { get; protected set; }
        public Color        Color               { get; set; }
        public int          MovimentQuantities  { get; protected set; } 
    
        public Piece(Board board, Color color)
        {
            Position            = null;
            Board               = board;
            Color               = color;
            MovimentQuantities  = 0;
        }

        public void IncrementMovimentQuantities()
        {
            MovimentQuantities++;
        }

        public bool ExistsPossibleMoviment()
        {
            bool[,] matrix = AllowedMoviments();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0;  j < Board.Columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position destination)
        {
            return AllowedMoviments()[destination.Row, destination.Column];
        }

        public abstract bool[,] AllowedMoviments();
    }
}
