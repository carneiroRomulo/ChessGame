namespace board
{
    class Piece
    {
        public Position Position            { get; set; }
        public Board    Board               { get; protected set; }
        public Color    Color               { get; set; }
        public int      MovimentQuantities  { get; protected set; } 
    
        public Piece(Position position, Board board, Color color)
        {
            Position            = position;
            Board               = board;
            Color               = color;
            MovimentQuantities  = 0;
        }
    }
}
