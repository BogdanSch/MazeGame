using MazeGame;
using MazeGame.Models.Enums;

class Program
{
    static void Main()
    {
        Game game = new Game(Console.Write);

        Console.WriteLine("Use arrows or WASD. Press ESC to exit.");

        ConsoleKey key = ConsoleKey.Enter;

        while (key != ConsoleKey.Escape)
        {
            key = Console.ReadKey(true).Key;

            if (TryConvertKeyToDirection(key, out Direction direction))
            {
                Console.Clear();
                game.MovePlayer(direction);
            }
        }
    }

    private static bool TryConvertKeyToDirection(ConsoleKey key, out Direction direction)
    {
        direction = Direction.Up;

        return key switch
        {
            ConsoleKey.W or ConsoleKey.UpArrow => (direction = Direction.Up) == Direction.Up,
            ConsoleKey.S or ConsoleKey.DownArrow => (direction = Direction.Down) == Direction.Down,
            ConsoleKey.A or ConsoleKey.LeftArrow => (direction = Direction.Left) == Direction.Left,
            ConsoleKey.D or ConsoleKey.RightArrow => (direction = Direction.Right) == Direction.Right,
            _ => false
        };
    }
}
