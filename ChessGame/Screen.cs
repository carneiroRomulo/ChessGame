using board;
using chess;

namespace ChessGame
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{board.Rows - i} ");

                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.GetPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.GetPiece(i, j));
                    }
                }
                Console.WriteLine();
            }

            Console.Write("  A B C D E F G H");
        }

        public static void PrintPiece(Piece piece)
        {
            switch (piece.Color)
            {
                case Color.WHITE:
                    Console.Write(piece);
                    break;

                case Color.BLACK:
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = consoleColor;
                    break;

                default:
                    break;
            }
            Console.Write(" ");
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char xAxis = s[0];
            int yAxis = int.Parse(s[1] + "");

            return new ChessPosition(xAxis, yAxis);
        }
    }
}
