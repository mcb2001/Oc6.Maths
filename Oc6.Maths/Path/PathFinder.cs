using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Oc6.Maths.Path
{
    public static class PathFinder
    {
        [SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "By design")]
        public static List<PathNode> GetShortestPath(PathNode[,] field, int xSource, int ySource, int xSink, int ySink)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            int width = field.GetLength(0);
            int height = field.GetLength(1);

            PathNode start = field[xSource, ySource];

            if (start.IsBlocked)
            {
                throw NotPathableException.SourceBlocked();
            }

            var openSet = new HashSet<PathNode> { start };

            start.GScore = 0;
            start.FScore = 0;

            while (openSet.Count > 0)
            {
                PathNode current = null;

                foreach (PathNode node in openSet)
                {
                    if (current == null)
                    {
                        current = node;
                    }
                    else if (current.FScore > node.FScore)
                    {
                        current = node;
                    }
                }

                if (current.X == xSink && current.Y == ySink)
                {
                    return ReconstructPath(current);
                }

                openSet.Remove(current);
                current.Closed = true;

                Test(field, current.X + 1, current.Y, width, height, current, openSet, xSink, ySink);
                Test(field, current.X - 1, current.Y, width, height, current, openSet, xSink, ySink);
                Test(field, current.X, current.Y + 1, width, height, current, openSet, xSink, ySink);
                Test(field, current.X, current.Y - 1, width, height, current, openSet, xSink, ySink);
            }

            throw NotPathableException.NoPath();
        }

        [SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "By design")]
        private static void Test(PathNode[,] field, int x, int y, int width, int height, PathNode cameFrom, HashSet<PathNode> openSet, int xSink, int ySink)
        {
            if (x < 0 || x == width || y < 0 || y == height)
            {
                return;
            }

            PathNode neighbor = field[x, y];

            if (neighbor.Closed || neighbor.IsBlocked)
            {
                return;
            }

            double tScore = cameFrom.GScore + 1;
            openSet.Add(neighbor);

            if (tScore >= neighbor.GScore)
            {
                return;
            }

            neighbor.CameFrom = cameFrom;
            neighbor.GScore = tScore;
            neighbor.FScore = tScore + Math.Abs(neighbor.X - xSink) + Math.Abs(neighbor.Y - ySink);
        }

        private static List<PathNode> ReconstructPath(PathNode field)
        {
            var list = new List<PathNode>();

            while (field.CameFrom != null)
            {
                list.Add(field);
                field = field.CameFrom;
            }

            list.Add(field);

            return list;
        }
    }
}
