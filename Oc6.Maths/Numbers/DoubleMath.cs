using Oc6.Maths.Util;
using System;

namespace Oc6.Maths.Numbers
{
    public static class DoubleMath
    {
        public static double Root(double value, int root)
        {
            if (IntegerMath.IsPowerOfTwo(root) && value < 0.0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "must be positive");
            }
            else if (value == 0.0)
            {
                return 0.0;
            }

            try
            {
                return NewtonRaphson.Iterate(x => Math.Pow(x, root) - value, x => root * Math.Pow(x, root - 1), rounding: null);
            }
            catch (IterationsExceededException<double> exc)
            {
                return exc.LastValue;
            }
        }
    }
}
