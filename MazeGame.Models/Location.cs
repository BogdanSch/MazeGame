using System.Data.Common;
using System.Drawing;

namespace MazeGame.Models
{
    public struct Location
    {
        private int _row;
        public int Row
        {
            get => _row;
            set
            {
                if(value < 0)
                {
                    //throw new ArgumentOutOfRangeException("X coordinate cannot be negative");
                    _row = 0;
                }
                _row = value;
            }
        }
        private int _column;
        public int Column
        {
            get => _column;
            set
            {
                if (value < 0)
                {
                    //throw new ArgumentOutOfRangeException("Y coordinate cannot be negative");
                    _column = 0;
                }
                _column = value;
            }
        }
        public Location(int row = 0, int column = 0)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object? other)
        {
            if (other == null || GetType() != other.GetType())
                return false;

            Location otherPoint = (Location)other;

            return _row == otherPoint.Row &&
                   Column == otherPoint.Column;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(_row, _column);
        }
    }
}
