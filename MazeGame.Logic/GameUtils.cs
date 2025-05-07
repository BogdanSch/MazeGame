using MazeGame.Models;
using MazeGame.Models.Units;

namespace MazeGame.Logic
{
    public static class GameUtils
    {
        private static int GetSquaredDistance(Location a, int row, int col) => (a.Row - row) * (a.Row - row) + (a.Column - col) * (a.Column - col);
        public static void Explode(Maze maze, Cell explosionEpicenter, int damageRadius)
        {
            Location center = explosionEpicenter.Location;
            int damageRadiusSquared = damageRadius * damageRadius;

            for (int row = center.Row - damageRadius; row <= center.Row + damageRadius; row++)
            {
                for (int col = center.Column - damageRadius; col <= center.Column + damageRadius; col++)
                {
                    if (maze.IsOutOfBounds(row, col)) continue;
                    if (row == 0 || col == 0 || row == maze.Rows - 1 || col == maze.Columns - 1) continue;

                    int distanceSquared = GetSquaredDistance(center, row, col);

                    if (distanceSquared <= damageRadiusSquared)
                    {
                        Cell targetCell = maze[row, col];

                        if (targetCell.OccupyingUnit is Exit) continue;
                        if (targetCell.OccupyingUnit is Key) continue;
                        targetCell.OccupyingUnit = null;
                    }
                }
            }
        }
    }
}
