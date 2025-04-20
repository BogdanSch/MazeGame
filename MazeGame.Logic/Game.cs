using MazeGame.Models;
using MazeGame.Models.Enums;
using MazeGame.Models.GameTools;
using MazeGame.Models.Units;

namespace MazeGame
{
    public class Game
    {
        private readonly Action<string, MessageStyle?> _print;

        private readonly Maze _maze;
        private readonly Player _player;
        private Cell _playerCell;
        private readonly Cell _exitCell;
        private Timer? _timer;

        public const int DEFAULT_GAME_DURATION = 60;
        public const int TIMER_STEP = 1000;
        private int _gameDuration;
        private int _currentTime;

        public string GameState { get; private set; } = string.Empty;
        public readonly static Dictionary<string, (int gameDurationSeconds, int rowsCount, int colsCount)> DifficultyLevels = new()
        {
            {"Easy", (90, 11, 11)},
            {"Medium", (70, 15, 15)},
            {"Hard", (60, 19, 27)},
        };
        public bool IsGameOver
        {
            get => _playerCell.Location.Equals(_exitCell.Location) || _exitCell.OccupyingUnit is Player || _currentTime <= 0;
        }

        public Game(int rows, int cols, Action<string, MessageStyle?> print, int gameDuration)
        {
            _maze = new Maze(rows, cols);
            _maze.GenerateMaze();

            _print = print;

            _gameDuration = gameDuration;
            _currentTime = gameDuration;

            _player = new Player("Player");
            _playerCell = _maze[1, 1];
            _playerCell.OccupyingUnit = _player;

            Exit exit = new();
            _exitCell = _maze[rows - 2, cols - 1];
            _exitCell.OccupyingUnit = exit;

            _maze.PrintMaze(print);
            PrintPlayerInventory();
        }
        public Game(Action<string, MessageStyle?> print, int gameDuration)
            : this(Maze.DEFAULT_ROWS_COUNT, Maze.DEFAULT_COLS_COUNT, print, gameDuration) { }
        public Game(Action<string, MessageStyle?> print)
            : this(Maze.DEFAULT_ROWS_COUNT, Maze.DEFAULT_COLS_COUNT, print, DEFAULT_GAME_DURATION) { }

        public void StartGame()
        {
            _currentTime = _gameDuration;
            _timer = new Timer(TimerCallback, null, 0, TIMER_STEP);
        }
        private void TimerCallback(object? state)
        {
            if (IsGameOver)
            {
                CheckGameOver();
                _timer?.Dispose();
                return;
            }
            _currentTime--;
        }
        public void CheckGameOver()
        {
            if(_currentTime <= 0)
            {
                GameState = "Time is up! Game over.";
            }
            else if (_exitCell.OccupyingUnit is Player)
            {
                GameState = "Congratulations! You have reached the exit!";
            }
        }
        public void MovePlayer(Direction direction)
        {
            if (IsGameOver) 
                return;

            Location current = _playerCell.Location;

            switch (direction)
            {
                case Direction.Up:
                    current.Row--;
                    break;
                case Direction.Down:
                    current.Row++;
                    break;
                case Direction.Left:
                    current.Column--;
                    break;
                case Direction.Right:
                    current.Column++;
                    break;
            }

            Cell nextCell = _maze[current.Row, current.Column];
            CheckNextCellItem(nextCell);

            if (_maze.CanMove(current))
            {
                _maze[_playerCell.Location.Row, _playerCell.Location.Column].OccupyingUnit = null;
                _playerCell = nextCell;
                _playerCell.OccupyingUnit = _player;
            }

            _maze.PrintMaze(_print);
            PrintPlayerInventory();
            _print($"\nTime left: {_currentTime}", null);
        }
        private void CheckNextCellItem(Cell reachedCell)
        {
            Unit? followingUnit = reachedCell.OccupyingUnit;

            if (followingUnit == null) return;

            if (reachedCell.OccupyingUnit is Key key)
            {
                _player.AddKey(key);
                GameState = $"Found the key {key.Symbol} to open this door.";
            }
            else if (reachedCell.OccupyingUnit is Door door)
            {
                if (door.DoorKey == null) return;

                if (_player.HasKey(door.DoorKey))
                {
                    door.IsOpen = true;
                    GameState = $"You opened the door with key {door.DoorKey.Symbol}.";
                    _player.RemoveKey(door.DoorKey);
                }
                else
                {
                    GameState = $"You need key {door.DoorKey?.Symbol} to open this door.";
                }
            }
            else if (reachedCell.OccupyingUnit is Tool tool)
            {
                _player.AddTool(tool);
                reachedCell.OccupyingUnit = null;
                GameState = $"Found tool {tool.Symbol}.";
            }
        }
        public void PrintPlayerInventory()
        {
            _print("\nCollected Keys: ", null);

            if (_player.CollectedKeys.Count == 0)
            {
                _print("_", null);
                return;
            }

            foreach (Key key in _player.CollectedKeys)
            {
                _print($"{key.Symbol} ", null);
            }

            _print("\nCollected Tools: ", null);

            if (_player.CollectedTools.Count == 0)
            {
                _print("_", null);
                return;
            }

            foreach (Tool tool in _player.CollectedTools)
            {
                _print($"{tool.Symbol} ", null);
            }
        }
        //private Cell GetToolCell(Location origin)
        //{

        //}
        public void Explode(Location explosionEpicenter, int damageRadius)
        {

        }
        public void UseTool()
        {
            if (IsGameOver)
                return;

            if (_player.CollectedTools.Count == 0)
            {
                GameState = "No tools to use.";
                return;
            }

            Location current = _playerCell.Location;

            Tool tool = _player.CollectedTools[0];
            _player.CollectedTools.RemoveAt(0);

            tool.Use();

            if (tool is Explosive explosive)
            {
                //explosive.Use();
                explosive.Exploded += (sender, e) =>
                {
                    Explode(current, explosive.DamageRadius);
                    //_maze.Explode(explosive, current);
                    GameState = $"Explosive device exploded!";
                };
                GameState = $"Planted an explosive device!";
            }
            else
            {
                GameState = $"Used tool {tool.Symbol}.";
            }

            _maze.PrintMaze(_print);
            PrintPlayerInventory();
        }
    }
}