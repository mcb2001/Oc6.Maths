using System;

namespace Oc6.Maths.Util
{
    public class IterationsExceededException<T> : Exception where T : struct
    {
        public T LastValue { get; }

        public IterationsExceededException(T value)
        {
            LastValue = value;
        }
    }
}
