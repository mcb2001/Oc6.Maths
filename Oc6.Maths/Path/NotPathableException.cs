using System;
using System.Diagnostics.CodeAnalysis;

namespace Oc6.Maths.Path
{
    [SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "<Only one true constructor>")]
    public sealed class NotPathableException : Exception
    {
        private const string SourceName = "Source";
        private const string SinkName = "Sink";

        private NotPathableException(string pathNodeName)
            : base($"{pathNodeName} is blocked, not path exists")
        {

        }

        internal static NotPathableException SourceBlocked()
        {
            return new NotPathableException(SourceName);
        }

        internal static NotPathableException SinkBlocked()
        {
            return new NotPathableException(SinkName);
        }

        internal static NotPathableException NoPath()
        {
            return new NotPathableException($"{SourceName} or {SinkName}");
        }
    }
}
