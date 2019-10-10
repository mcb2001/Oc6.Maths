using System;
using System.Diagnostics.CodeAnalysis;

namespace Oc6.Maths.Util
{
    [SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Only one true constructor")]
    public sealed class IterationsExceededException<T> : Exception where T : struct
    {
        public T LastValue { get; }

        public IterationsExceededException(T value)
        {
            LastValue = value;
        }
    }
}
