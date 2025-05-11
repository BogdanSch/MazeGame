using MazeGame.Models;
using MazeGame.Models.Enums;
using MazeGame.Models.GameTools;
using MazeGame.Models.Units;
using System.Text;

namespace MazeGame.Logic
{
    public class Game
    {

        private readonly Action<string> _updateInventory;
        private readonly Action<string> _updateTimer;

        private readonly Maze _maze;
        public Cell[,] MazeGrid
        {
            get
            {
                return _maze.Field;
            }
        }

        private readonly Player _player;
        private Cell _playerCell;
        private readonly Cell _exitCell;
        private Timer? _timer;
        private Direction _userDirection = Direction.Up;

        public const int DEFAULT_GAME_DURATION = 60;
        public const int TIMER_STEP = 1000;
        private readonly int _gameDuration;
        private int _currentTime;

        public string GameState { get; private set; } = string.Empty;
        public readonly static Dictionary<string, GameDifficulty> DifficultyLevels = new()
        {
            {"Easy", new GameDifficulty(11, 11, 90)},
            {"Medium", new GameDifficulty(15, 15, 70)},
            {"Difficult", new GameDifficulty(19, 27, 60)},
            {"Hardcore", new GameDifficulty(21, 29, 65, true)},
        };
        public bool IsGameOver
        {
            get => _playerCell.OccupyingUnit == null || _playerCell.Location.Equals(_exitCell.Location) || _exitCell.OccupyingUnit is Player || _currentTime <= 0;
        }

        public Game(int rows, int cols, Action<string> updateInventory, Action<string> updateTimer, int gameDuration)
        {
            _maze = new Maze(rows, cols);
            _maze.GenerateMaze();

            _updateInventory = updateInventory;
            _updateTimer = updateTimer;

            _gameDuration = gameDuration;
            _currentTime = gameDuration;

            _player = new Player("Player");
            _playerCell = _maze[1, 1];
            _playerCell.OccupyingUnit = _player;

            Exit exit = new();
            _exitCell = _maze[rows - 2, cols - 1];
            _exitCell.OccupyingUnit = exit;

            PrintPlayerInventory();
        }
        ~Game()
        {
            GameState = "The game has been stopped!";
            _timer?.Dispose();
        }
        public Game(Action<string> updateInventory, Action<string> updateTimer, int gameDuration)
            : this(Maze.DEFAULT_ROWS_COUNT, Maze.DEFAULT_COLS_COUNT, updateInventory, updateTimer, gameDuration) { }
        public Game(Action<string> updateInventory, Action<string> updateTimer)
            : this(Maze.DEFAULT_ROWS_COUNT, Maze.DEFAULT_COLS_COUNT, updateInventory, updateTimer, DEFAULT_GAME_DURATION) { }
        public void StartGame()
        {
            GameState = "The game has stated!";
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
            _updateTimer($"Time left: {_currentTime}");
        }
        public void CheckGameOver()
        {
            if (_currentTime <= 0)
            {
                GameState = "Time is up! Game over.";
            }
            else if (_exitCell.OccupyingUnit is Player)
            {
                GameState = "Congratulations! You have reached the exit!";
            }
            else if (_playerCell.OccupyingUnit == null)
            {
                GameState = "Player has died! Game over.";
            }
        }
        public void MovePlayer(Direction direction)
        {
            if (IsGameOver)
                return;

            _userDirection = direction;
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

            RedrawGameInterface();
        }
        public void RedrawGameInterface()
        {
            //_maze.PrintMaze(_print);
            PrintPlayerInventory();
            //_updateInventory(GameState);
            _updateTimer($"Time left: {_currentTime}");
            //_print($"\nTime left: {_currentTime}", null);
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
                if(tool.IsActivated)
                {
                    GameState = $"Tool {tool.Name} is already activated.";
                    return;
                }
                _player.AddTool(tool);
                reachedCell.OccupyingUnit = null;
                GameState = $"Found tool {tool.Name}.";
            }
            else if(reachedCell.OccupyingUnit is Exit)
            {
                GameState = "You have reached the exit!";
            }
        }
        public void PrintPlayerInventory()
        {
            StringBuilder inventory = new();
            inventory.Append("\nCollected Keys: ");

            if (_player.CollectedKeys.Count == 0)
            {
                inventory.Append("_");
            }
            else
            {
                foreach (Key key in _player.CollectedKeys)
                {
                    inventory.Append($"{key.Symbol} ");
                }
            }

            inventory.Append("\nCollected Tools: ");

            if (_player.CollectedTools.Count == 0)
            {
                inventory.Append("_");
            }
            else
            {
                foreach (Tool tool in _player.CollectedTools)
                {
                    inventory.Append($"{tool.Symbol} ");
                }
            }

            _updateInventory(inventory.ToString());
        }
        public void SelectTool(int index)
        {
            if (IsGameOver)
                return;
            if (index < 0 || index >= _player.CollectedTools.Count)
            {
                GameState = "Invalid tool selection.";
                return;
            }

            Tool selectedTool = _player.CollectedTools[index];
            GameState = $"Selected tool {selectedTool.Name}.";
            _player.ActiveTool = selectedTool;
        }
        private bool TryPlaceTool(Tool tool, ref Location current)
        {
            switch (_userDirection)
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

            if (!_maze.CanMove(current))
                return false;

            Cell toolCell = _maze[current.Row, current.Column];

            if (toolCell.OccupyingUnit != null)
                return false;

            toolCell.OccupyingUnit = tool;
            return true;
        }
        public void UseTool()
        {
            if (IsGameOver) return;
            if (_player.CollectedTools.Count == 0)
            {
                GameState = "No tools to use.";
                return;
            }

            Location current = _playerCell.Location;

            Tool? tool = _player.ActiveTool;

            if(tool == null)
            {
                GameState = "No tool selected.";
                return;
            }
            if (!TryPlaceTool(tool, ref current))
            {
                GameState = $"Tool {tool.Name} cannot be used here.";
                return;
            }

            _player.CollectedTools.Remove(tool);
            _player.ActiveTool = null;
            Cell toolCell = _maze[current.Row, current.Column];
            tool.Use();

            if (tool is Explosive explosive)
            {
                explosive.Exploded += (sender, e) =>
                {
                    if (IsGameOver)
                        return;

                    GameUtils.Explode(_maze, toolCell, explosive.DamageRadius);
                    GameState = $"Explosive device exploded!";
                };
                GameState = $"Planted an explosive device! You have {explosive.CooldownTime} seconds before detonatin.";
            }
            else
            {
                GameState = $"Used tool {tool.Name}.";
            }
        }
    }
}