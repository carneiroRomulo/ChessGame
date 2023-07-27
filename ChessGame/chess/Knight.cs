﻿using board;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "S";
        }

        public override bool[,] AllowedMoviments()
        {
            throw new NotImplementedException();
        }
    }
}
