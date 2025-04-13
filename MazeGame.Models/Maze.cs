using MazeGame.Models.Units;
using System.IO;
using System.Numerics;

namespace MazeGame.Models
{
    public class Maze
    {
        public const int DEFAULT_ROWS_COUNT = 19;
        public const int DEFAULT_COLS_COUNT = 31;
        private readonly Random _random = new();
        private readonly Stack<Cell> _stack = new();
        private readonly List<Cell> _pathToExit = new();
        private readonly List<Cell> _doors = new();
        public Cell[,] Field { get; set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int KeysCount { get => 3; }//{ get => (Rows + Columns) / 8; }
        public int DoorsCount { get => 3; }//{ get => (Rows + Columns) / 8; }

        public Maze(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Field = new Cell[Rows, Columns];
            Initialize();
        }

        public Maze() : this(DEFAULT_ROWS_COUNT, DEFAULT_COLS_COUNT) { }

        public Cell this[int row, int col]
        {
            get
            {
                if (CheckBoundaries(row, col))
                    throw new IndexOutOfRangeException("Invalid cell coordinates");
                return Field[row, col];
            }
            set
            {
                if (CheckBoundaries(row, col))
                    throw new IndexOutOfRangeException("Invalid cell coordinates");
                Field[row, col] = value;
            }
        }

        private bool CheckBoundaries(int row, int col) => row < 0 || row >= Rows || col < 0 || col >= Columns;

        private void Initialize()
        {
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Columns; col++)
                    Field[row, col] = new Cell(row, col, new Wall());
        }

        public bool CanMove(Location location)
        {
            if (CheckBoundaries(location.Row, location.Column))
                return false;
            Cell cell = Field[location.Row, location.Column];
            return cell.IsWalkable();
        }

        private List<(Cell neighbor, int dRow, int dCol)> GetUnvisitedNeighboursWithDirection(Cell origin)
        {
            List<(Cell, int, int)> unvisitedNeighbours = [];
            int[][] directions = [new[] { -2, 0 }, new[] { 2, 0 }, new[] { 0, -2 }, new[] { 0, 2 }];

            foreach (int[] dir in directions)
            {
                int newRow = origin.Location.Row + dir[0];
                int newCol = origin.Location.Column + dir[1];

                if (newRow >= 0 && newRow < Rows && newCol >= 0 && newCol < Columns && !Field[newRow, newCol].IsVisited)
                {
                    unvisitedNeighbours.Add((Field[newRow, newCol], dir[0], dir[1]));
                }
            }

            return unvisitedNeighbours;
        }

        public void GenerateMaze(int startRow = 1, int startColumn = 1)
        {
            Field[startRow, startColumn].OccupyingUnit = null;
            //Field[Rows - 1, Columns - 1].OccupyingUnit = null;

            Cell startCell = Field[startRow, startColumn];
            startCell.IsVisited = true;
            _stack.Push(startCell);

            while (_stack.Count > 0)
            {
                Cell current = _stack.Peek();
                List<(Cell neighbor, int dRow, int dCol)> unvisitedNeighbors = GetUnvisitedNeighboursWithDirection(current);

                if (unvisitedNeighbors.Count > 0)
                {
                    (Cell nextCell, int dRow, int dCol) = unvisitedNeighbors[_random.Next(unvisitedNeighbors.Count)];

                    int wallRow = current.Location.Row + dRow / 2;
                    int wallCol = current.Location.Column + dCol / 2;
                    Field[wallRow, wallCol].OccupyingUnit = null;

                    nextCell.IsVisited = true;
                    nextCell.OccupyingUnit = null;
                    _stack.Push(nextCell);
                }
                else
                {
                    _stack.Pop();
                }
            }

            SetAllCellsUnvisited();
            PlaceDoorsAndKeys();
        }
        private void SetAllCellsUnvisited()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Field[row, col].IsVisited = false;
                }
            }
        }
        protected bool FindPathToExit(Location from, Location to)
        {
            if(CheckBoundaries(from.Row, from.Column) || CheckBoundaries(to.Row, to.Column))
                return false;
            if(Field[from.Row, from.Column].OccupyingUnit is Wall)
                return false;
            if(Field[from.Row, from.Column].IsVisited)
                return false;

            Cell currentCell = Field[from.Row, from.Column];
            currentCell.IsVisited = true;
            _pathToExit.Add(currentCell);

            if (from.Equals(to)) return true;

            int[][] directions = [new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 }];
            foreach (int[] direction in directions)
            {
                int nextRow = from.Row + direction[0];
                int nextCol = from.Column + direction[1];
                Location nextLocation = new Location(nextRow, nextCol);

                if(FindPathToExit(nextLocation, to))
                {
                    return true;
                }
            }

            _pathToExit.Remove(currentCell);
            return false;
        }
        public List<Cell> FindPathToExit()
        {
            FindPathToExit(new Location(1, 1), new Location(Rows - 2, Columns - 2));
            return _pathToExit;
        }
        public void PlaceDoorsAndKeys()
        {
            FindPathToExit();
            if (_pathToExit.Count == 0) return;

            int spacing = _pathToExit.Count / DoorsCount;
            char letter = 'a';

            for (int i = 1; i <= DoorsCount; i++, letter++)
            {
                int doorIndex = i * spacing;
                if (doorIndex >= _pathToExit.Count) break;

                Cell doorCell = _pathToExit[doorIndex];
                doorCell.OccupyingUnit = new Door(Char.ToUpper(letter));
                _doors.Add(doorCell);

                // Find a key placement before the door
                int keySearchStart = Math.Max(0, doorIndex - spacing / 2);
                for (int j = keySearchStart; j < doorIndex; j++)
                {
                    Cell potentialKeyCell = _pathToExit[j];
                    if (potentialKeyCell.OccupyingUnit == null)
                    {
                        potentialKeyCell.OccupyingUnit = new Key(letter);
                        break;
                    }
                }
            }
        }

        public void PrintMaze(Action<string> printAction)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    printAction(Field[row, col].ToString());
                }
                printAction("\n");
            }
        }
    }
}
