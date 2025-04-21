using MazeGame.Models;
using MazeGame.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame.Logic
{
    public static class GameUtils
    {
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

                    Cell targetCell = maze[row, col];
                    int distanceSquared = (center.Row - row) * (center.Row - row) + (center.Column - col) * (center.Column - col);

                    if (distanceSquared <= damageRadiusSquared)
                    {
                        if (targetCell.OccupyingUnit is Exit) continue;
                        targetCell.OccupyingUnit = null;
                    }
                }
            }
        }
    }
}
