namespace board
{
    class Board
    {
        public  int         Lines     { get; set; }
        public  int         Columns   { get; set; }
        private Piece[,]    _pieces;

        public Board()
        {
            Lines   = 8;
            Columns = 8;
            _pieces = new Piece[Lines, Columns];
        }

    }
}
