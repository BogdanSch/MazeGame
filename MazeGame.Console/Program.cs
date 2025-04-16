using MazeGame;
using MazeGame.Models;
using MazeGame.Models.Enums;

class Program
{
    private static void DisplayGameState(string gameState)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(gameState);
        Console.ResetColor();
    }

    private static void DisplayGameAction(string message, MessageStyle? style)
    {
        ConsoleColor color = ConsoleColor.Gray;

        if (style != null && Enum.TryParse<ConsoleColor>(style.ColorName, ignoreCase: true, out var parsedColor))
            color = parsedColor;

        Console.ForegroundColor = color;
        Console.Write(message);
    }

    static void Main()
    {
        DisplayWelcomeMessage();

        (int gameDurationSeconds, int rowsCount, int colsCount) = ConfigureGame();

        Game game = new(rowsCount, colsCount, DisplayGameAction, gameDurationSeconds);
        game.StartGame();

        ConsoleKey key = ConsoleKey.Enter;

        while (key != ConsoleKey.Escape && !game.IsGameOver)
        {
            key = Console.ReadKey(true).Key;

            if (TryConvertKeyToDirection(key, out Direction direction))
            {
                Console.Clear();
                game.MovePlayer(direction);
                DisplayGameState(game.GameState);
            }
        }

        Console.Clear();
        game.CheckGameOver();
        DisplayGameState(game.GameState);

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
        Console.WriteLine("1. Easy    ->  Duration: 90s | Maze: 11x11");
        Console.WriteLine("2. Medium  ->  Duration: 70s  | Maze: 15x15");
        Console.WriteLine("3. Hard    ->  Duration: 60s  | Maze: 19x27");
        Console.WriteLine("4. Custom  ->  Choose your own settings");

        ConsoleKey key = Console.ReadKey(true).Key;
        int gameDurationSeconds = Game.DEFAULT_GAME_DURATION;
        int rowsCount = Maze.DEFAULT_ROWS_COUNT;
        int colsCount = Maze.DEFAULT_COLS_COUNT;

        switch (key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                gameDurationSeconds = 90;
                rowsCount = colsCount = 11;
                break;

            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                gameDurationSeconds = 70;
                rowsCount = colsCount = 15;
                break;

            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                gameDurationSeconds = 60;
                rowsCount = 19;
                colsCount = 27;
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
        Console.Write("Enter maze dimensions in format NxM (They shoudl be odd numbers, N > 4 and M > 4): ");
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
                int.TryParse(dimensions[1], out colsCount) &&
                rowsCount > 4 && colsCount > 4)
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
        switch (key)
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                direction = Direction.Up;
                return true;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                direction = Direction.Down;
                return true;
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                direction = Direction.Left;
                return true;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                direction = Direction.Right;
                return true;
            default:
                direction = Direction.Up;
                return false;
        }
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
