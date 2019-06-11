using System;

namespace Oc6.Maths.Path
{
    public class NotPathableException : Exception
    {
        protected const string SOURCE_NAME = "Source";
        protected const string SINK_NAME = "Sink";

        private NotPathableException(string pathNodeName)
            : base($"{pathNodeName} is blocked, not path exists")
        {

        }

        internal static NotPathableException SourceBlocked()
        {
            return new NotPathableException(SOURCE_NAME);
        }

        internal static NotPathableException SinkBlocked()
        {
            return new NotPathableException(SINK_NAME);
        }

        internal static NotPathableException NoPath()
        {
            return new NotPathableException($"{SOURCE_NAME} or {SINK_NAME}");
        }
    }
}
