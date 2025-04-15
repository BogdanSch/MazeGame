using MazeGame;
using MazeGame.Models.Enums;

class Program
{
    static void Main()
    {
        DisplayWelcomeMessage();

        Game game = new(Console.Write);
        game.StartGame();

        ConsoleKey key = ConsoleKey.Enter;

        while (key != ConsoleKey.Escape && !game.IsGameOver)
        {
            key = Console.ReadKey(true).Key;

            if (TryConvertKeyToDirection(key, out Direction direction))
            {
                Console.Clear();
                game.MovePlayer(direction);
                Console.WriteLine();
                Console.WriteLine(game.GameState);
            }
        }

        Console.Clear();
        Console.WriteLine(game.GameState);

        if (key != ConsoleKey.Escape)
        {
            Console.WriteLine("Would you like to try again? (y/n)");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Y)
            {
                Console.Clear();
                Main();
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
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
    private static void DisplayWelcomeMessage()
    {
        Console.WriteLine("=== The Maze v1.0 ===\n");
        Console.WriteLine(@"

               ___          ___                   ___          ___          ___          ___     
      ___     /__/\        /  /\                 /__/\        /  /\        /  /\        /  /\    
     /  /\    \  \:\      /  /:/_               |  |::\      /  /::\      /  /::|      /  /:/_   
    /  /:/     \__\:\    /  /:/ /\              |  |:|:\    /  /:/\:\    /  /:/:|     /  /:/ /\  
   /  /:/  ___ /  /::\  /  /:/ /:/_           __|__|:|\:\  /  /:/~/::\  /  /:/|:|__  /  /:/ /:/_ 
  /  /::\ /__/\  /:/\:\/__/:/ /:/ /\         /__/::::| \:\/__/:/ /:/\:\/__/:/ |:| /\/__/:/ /:/ /\
 /__/:/\:\\  \:\/:/__\/\  \:\/:/ /:/         \  \:\~~\__\/\  \:\/:/__\/\__\/  |:|/:/\  \:\/:/ /:/
 \__\/  \:\\  \::/      \  \::/ /:/           \  \:\       \  \::/         |  |:/:/  \  \::/ /:/ 
      \  \:\\  \:\       \  \:\/:/             \  \:\       \  \:\         |  |::/    \  \:\/:/  
       \__\/ \  \:\       \  \::/               \  \:\       \  \:\        |  |:/      \  \::/   
              \__\/        \__\/                 \__\/        \__\/        |__|/        \__\/    

        ");
        Console.WriteLine();
        Console.WriteLine("Navigate through the maze. Collect treasures. Avoid traps.");
        Console.WriteLine("Controls: Arrow Keys  or  W A S D");
        Console.WriteLine("Exit: [ESC] | Confirm: [Enter]");
        Console.WriteLine("Press any key to start your adventure...");
        Console.ReadKey(true);
        Console.Clear();
    }
}
