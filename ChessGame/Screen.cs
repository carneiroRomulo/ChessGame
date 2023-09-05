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
                    PrintPiece(board.GetPiece(i, j));
                }
                Console.WriteLine();
            }

            Console.Write("  A B C D E F G H");
        }

        public static void PrintBoard(Board board, bool[,] allowedPositions)
        {
            ConsoleColor primaryBackground = Console.BackgroundColor;
            ConsoleColor secondaryBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{board.Rows - i} ");

                for (int j = 0; j < board.Columns; j++)
                {
                    if (allowedPositions[i, j])
                    {
                        Console.BackgroundColor = secondaryBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = primaryBackground;
                    }
                    PrintPiece(board.GetPiece(i, j));
                }
                Console.WriteLine();
                Console.BackgroundColor = primaryBackground;
            }

            Console.Write("  A B C D E F G H");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("-");
            }
            else
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
            }
            Console.Write(" ");
        }

        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Round: " + match.Round);

            if (!match.Finished)
            {
                Console.WriteLine("Player: " + match.CurrentPlayer);
                if (match.Check)
                {
                    Console.WriteLine("Check!");
                }
            }
            else
            {
                Console.WriteLine("Checkmate!");
                Console.WriteLine("Winner: " + match.CurrentPlayer);
            }
        }   

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("White: ");
            PrintSet(match.CapturedPieces(Color.WHITE));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.CapturedPieces(Color.BLACK));
            Console.ForegroundColor = consoleColor;
            Console.WriteLine();

        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece piece in set)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
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
