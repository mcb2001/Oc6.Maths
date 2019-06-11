using System;
using System.Diagnostics;

namespace Oc6.Maths.Path
{
    [DebuggerDisplay("Point: ({X}, {Y})")]
    public class PathNode : IEquatable<PathNode>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsBlocked { get; set; }

        internal bool Closed { get; set; }

        internal PathNode CameFrom { get; set; }

        internal double GScore { get; set; }
        internal double FScore { get; set; }

        public PathNode(int x, int y)
        {
            X = x;
            Y = y;
            GScore = double.PositiveInfinity;
            FScore = double.PositiveInfinity;
            CameFrom = null;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PathNode);
        }

        public bool Equals(PathNode other)
        {
            return other != null &&
                   X == other.X &&
                   Y == other.Y;
        }

        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
