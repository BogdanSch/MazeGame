using MazeGame.Models.Units;

namespace MazeGame.Models
{
    public class Maze
    {
        public const int DEFAULT_ROWS_COUNT = 16;
        public const int DEFAULT_COLS_COUNT = 28;
        private readonly Random _random = new();
        private readonly Stack<Cell> _stack = new();

        public Cell[,] Field { get; set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }

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

            foreach (var dir in directions)
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

        public void GenerateMaze(int startRow = 0, int startColumn = 0)
        {
            Field[startRow, startColumn].OccupyingUnit = null;
            Field[Rows - 1, Columns - 1].OccupyingUnit = null;

            Cell startCell = Field[startRow, startColumn]; // Starting cell
            startCell.IsVisited = true; // Mark as visited
            _stack.Push(startCell);

            while (_stack.Count > 0) // Continue until all cells are visited
            {
                Cell current = _stack.Peek(); // Look at the current cell
                List<(Cell neighbor, int dRow, int dCol)> unvisitedNeighbors = GetUnvisitedNeighboursWithDirection(current);

                if (unvisitedNeighbors.Count > 0) // If there are unvisited neighbors:
                {
                    (Cell nextCell, int dRow, int dCol) = unvisitedNeighbors[_random.Next(unvisitedNeighbors.Count)]; // Pick one at random

                    // Remove the wall between current and nextCell
                    int wallRow = current.Location.Row + dRow / 2;
                    int wallCol = current.Location.Column + dCol / 2;
                    Field[wallRow, wallCol].OccupyingUnit = null; // Remove the wall

                    // Mark the next cell as visited and open the path
                    nextCell.IsVisited = true;
                    nextCell.OccupyingUnit = null;
                    _stack.Push(nextCell); // Move to the next cell
                }
                else
                {
                    _stack.Pop();
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
