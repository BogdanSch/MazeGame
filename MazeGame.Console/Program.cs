using MazeGame;
using MazeGame.Models;
using MazeGame.Models.Enums;

class Program
{
    static void Main()
    {
        DisplayWelcomeMessage();

        (int gameDurationSeconds, int rowsCount, int colsCount) = ConfigureGame();

        Game game = new(rowsCount, colsCount, Console.Write, gameDurationSeconds);
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
    private static (int gameDurationSeconds, int rowsCount, int colsCount) ConfigureGame()
    {
        Console.WriteLine("Select difficulty:");
        Console.WriteLine("1. Easy    ->  Duration: 100s | Maze: 11x11");
        Console.WriteLine("2. Medium  ->  Duration: 60s  | Maze: 15x15");
        Console.WriteLine("3. Hard    ->  Duration: 30s  | Maze: 21x21");
        Console.WriteLine("4. Custom  ->  Choose your own settings");

        ConsoleKey key = Console.ReadKey(true).Key;
        int gameDurationSeconds = Game.DEFAULT_GAME_DURATION;
        int rowsCount = Maze.DEFAULT_ROWS_COUNT;
        int colsCount = Maze.DEFAULT_COLS_COUNT;

        switch (key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                gameDurationSeconds = 100;
                rowsCount = colsCount = 11;
                break;

            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                gameDurationSeconds = 60;
                rowsCount = colsCount = 15;
                break;

            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                gameDurationSeconds = 40;
                rowsCount = colsCount = 21;
                break;

            case ConsoleKey.D4:
            case ConsoleKey.NumPad4:
                return ConfigureCustomGame();

            default:
                Console.WriteLine("Invalid choice. Defaulting to Medium.");
                Thread.Sleep(1000);
                gameDurationSeconds = 60;
                rowsCount = colsCount = 15;
                break;
        }

        Console.Clear();
        return (gameDurationSeconds, rowsCount, colsCount);
    }
    private static (int gameDurationSeconds, int rowsCount, int colsCount) ConfigureCustomGame()
    {
        Console.Clear();
        Console.Write("Enter game duration in seconds (default 60): ");
        string? gameDurationInput = Console.ReadLine();
        Console.Write("Enter maze dimensions in format NxM (odd numbers): ");
        string? dimensionsLine = Console.ReadLine()?.Trim().ToLower();

        bool isValidDuration = int.TryParse(gameDurationInput, out int gameDurationSeconds);

        if (!isValidDuration || gameDurationSeconds <= 0)
            gameDurationSeconds = Game.DEFAULT_GAME_DURATION;

        int rowsCount, colsCount;
        if (dimensionsLine != null)
        {
            string[] dimensions = dimensionsLine.Split('x', StringSplitOptions.RemoveEmptyEntries);
            if (dimensions.Length == 2 &&
                int.TryParse(dimensions[0], out rowsCount) &&
                int.TryParse(dimensions[1], out colsCount))
            {
                if (rowsCount % 2 == 0) rowsCount++;
                if (colsCount % 2 == 0) colsCount++;
            }
            else
            {
                rowsCount = Maze.DEFAULT_ROWS_COUNT;
                colsCount = Maze.DEFAULT_COLS_COUNT;
            }
        }
        else
        {
            rowsCount = Maze.DEFAULT_ROWS_COUNT;
            colsCount = Maze.DEFAULT_COLS_COUNT;
        }

        Console.Clear();
        return (gameDurationSeconds, rowsCount, colsCount);
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
