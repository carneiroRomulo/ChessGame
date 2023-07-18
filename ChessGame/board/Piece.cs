namespace board
{
    class Piece
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
    }
}
