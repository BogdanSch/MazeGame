using MazeGame.Models.Units;

namespace MazeGame.Models
{
    public class Cell
    {
        public Location Location { get; set; }
        public Unit? OccupyingUnit { get; set; }
        public bool IsVisited { get; set; }

        public Cell(int row, int col, Unit? unit = null)
        {
            Location = new Location(row, col);
            OccupyingUnit = unit;
            IsVisited = false;
        }

        public bool IsWalkable()
        {
            return OccupyingUnit == null || OccupyingUnit is not Wall;
        }

        public override string ToString()
        {
            return OccupyingUnit?.Symbol.ToString() ?? " ";
        }
    }
}
