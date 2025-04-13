using MazeGame.Models;
using MazeGame.Models.Enums;
using MazeGame.Models.Units;

namespace MazeGame
{
    public class Game
    {
        private readonly Action<string> _print;

        private readonly Maze _maze;
        private readonly Player _player;
        private Cell _playerCell;
        private readonly Cell _exitCell;

        public bool IsGameOver 
        {
            get => _playerCell.Location.Equals(_exitCell.Location) || _playerCell.OccupyingUnit is Exit;
        }
        

        public Game(int rows, int cols, Action<string> print)
        {
            _maze = new Maze(rows, cols);
            _maze.GenerateMaze();

            _print = print;

            _player = new Player("Player");
            _playerCell = _maze[1, 1];
            _playerCell.OccupyingUnit = _player;

            Exit exit = new();
            _exitCell = _maze[rows - 2, cols - 1];
            _exitCell.OccupyingUnit = exit;

            _maze.PrintMaze(print);
            PrintPlayerInventory();
        }

        public Game(Action<string> print)
            : this(Maze.DEFAULT_ROWS_COUNT, Maze.DEFAULT_COLS_COUNT, print) { }

        public void MovePlayer(Direction direction)
        {
            if (IsGameOver) return;

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

            if (_maze.CanMove(current))
            {
                Cell nextCell = _maze[current.Row, current.Column];
                CheckReachedCell(nextCell);

                _maze[_playerCell.Location.Row, _playerCell.Location.Column].OccupyingUnit = null;
                _playerCell = _maze[current.Row, current.Column];
                _playerCell.OccupyingUnit = _player;

                
                //_maze.PrintMaze(_print);
            }
            _maze.PrintMaze(_print);
            PrintPlayerInventory();
        }

        private void CheckReachedCell(Cell reachedCell)
        {
            if(reachedCell.OccupyingUnit is Key)

        }

        public void PrintPlayerInventory()
        {
            _print("\nCollected Keys: ");

            if (_player.CollectedKeys.Count == 0)
            {
                _print("None");
                return;
            }

            foreach (Key key in _player.CollectedKeys)
            {
                _print($"Key: {key.Name} ");
            }
        }
        public void PrintVictoryMessage()
        {
            _print("\nCongratulations! You have reached the exit!");
        }
    }
}
