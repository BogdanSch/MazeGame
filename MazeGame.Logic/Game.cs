using MazeGame.Models;
using MazeGame.Models.Enums;
using MazeGame.Models.Units;
using System.Threading;

namespace MazeGame
{
    public class Game
    {
        private readonly Action<string> _print;

        private readonly Maze _maze;
        private readonly Player _player;
        private Cell _playerCell;
        private readonly Cell _exitCell;
        private Timer? _timer;

        public const int DEFAULT_GAME_DURATION = 60;
        public const int TIMER_STEP = 1000;
        private int _gameDuration;
        private int _currentTime;

        public bool IsGameOver
        {
            get => _playerCell.Location.Equals(_exitCell.Location) || _playerCell.OccupyingUnit is Exit || _currentTime <= 0;
        }

        public Game(int rows, int cols, Action<string> print, int gameDuration)
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

        public Game(Action<string> print)
            : this(Maze.DEFAULT_ROWS_COUNT, Maze.DEFAULT_COLS_COUNT, print, DEFAULT_GAME_DURATION) { }

        public void StartGame()
        {
            _timer = new Timer(TimerCallback, null, 0, TIMER_STEP);
        }
        private void TimerCallback(object? state)
        {
            if (IsGameOver)
            {
                _timer?.Dispose();
                //PrintVictoryMessage();
                return;
            }
            if (_currentTime <= 0)
            {
                _timer?.Dispose();
                _print("\nTime is up! Game over.");
                //IsGameOver = true;
                return;
            }
            _currentTime--;
        }
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

            Cell nextCell = _maze[current.Row, current.Column];
            CheckNextCell(nextCell);

            if (_maze.CanMove(current))
            {
                _maze[_playerCell.Location.Row, _playerCell.Location.Column].OccupyingUnit = null;
                _playerCell = nextCell;
                _playerCell.OccupyingUnit = _player;
            }

            _maze.PrintMaze(_print);
            PrintPlayerInventory();
            _print($"\nTime left: {_currentTime}");
        }

        private void CheckNextCell(Cell reachedCell)
        {
            Unit? followingUnit = reachedCell.OccupyingUnit;

            if (followingUnit == null) return;

            if (reachedCell.OccupyingUnit is Key)
            {
                _player.AddKey((Key)followingUnit);
            }
            else if (reachedCell.OccupyingUnit is Door door)
            {
                if (door.DoorKey == null) return;

                if (_player.HasKey(door.DoorKey))
                {
                    door.IsOpen = true;
                    _print($"\nYou opened the door with key {door.DoorKey.Name}.");
                    _player.RemoveKey(door.DoorKey);
                }
                else
                {
                    _print($"\nYou need key {door.DoorKey?.Name} to open this door.");
                }
            }
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
                _print($"Key: {key.Symbol} ");
            }
        }
        public void PrintVictoryMessage()
        {
            _print("\nCongratulations! You have reached the exit!");
        }
    }
}