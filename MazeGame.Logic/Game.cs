using MazeGame.Models;
using MazeGame.Models.Enums;
using MazeGame.Models.Units;
using System.Drawing;

namespace MazeGame
{
    public class Game
    {
        private readonly Action<string> _print;

        private readonly Maze _maze;
        private readonly Player _player;
        private Cell _playerCell;
        private readonly Cell _exitCell;

        public bool IsGameOver =>
            _exitCell.OccupyingUnit is Player;

        public Game(int rows, int cols, Action<string> print)
        {
            _maze = new Maze(rows, cols);
            _maze.GenerateMaze();

            _print = print;

            _player = new Player("Player");
            _playerCell = _maze[0, 0];
            _playerCell.OccupyingUnit = _player;

            Exit exit = new();
            _exitCell = _maze[rows - 1, cols - 1];
            _exitCell.OccupyingUnit = exit;

            _maze.PrintMaze(print);
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
                _maze[_playerCell.Location.Row, _playerCell.Location.Column].OccupyingUnit = null;
                _playerCell = _maze[current.Row, current.Column];
                _playerCell.OccupyingUnit = _player;
                //_maze.PrintMaze(_print);
            }
            _maze.PrintMaze(_print);
        }
        public void PrintVictoryMessage()
        {
            _print("\nCongratulations! You have reached the exit!");
        }
    }
}
