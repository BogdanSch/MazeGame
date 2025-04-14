using MazeGame;
using MazeGame.Models.Enums;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Maze Game!");
        Console.WriteLine("For basic controls use arrow keys or WASD. Press ESC to exit.");
        Console.WriteLine("Press any key to start...");

        Console.ReadKey(true);
        Console.Clear();

        Game game = new Game(Console.Write);
        game.StartGame();

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
