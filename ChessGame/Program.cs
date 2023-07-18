using board;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Position position = new Position(1, 1);

            Console.WriteLine("Position: " + position.ToString());
        }
    }
}