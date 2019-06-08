﻿using Oc6.Maths.Decimal;
using Oc6.Maths.Shared;
using System;

namespace Oc6.Maths.Finance
{
    public static class LoanFunctions
    {
        public static double Rate(double periods, double presentValue, double futureValue, double monthlyPayment, PaymentType type)
        {
            double t = (int)type;
            double guess = ((monthlyPayment * periods) - presentValue) / presentValue;

            try
            {
                return NewtonRaphson.Iterate(
                        (double r0) => (presentValue * Math.Pow(1 + r0, periods) - futureValue) / ((1 + r0 * t) * ((Math.Pow(1 + r0, periods) - 1) / r0)) - monthlyPayment,
                        (double r0) => (futureValue * (periods * r0 * r0 * t * Math.Pow(1 + r0, periods) + periods * r0 * Math.Pow(1 + r0, periods) - r0 * Math.Pow(1 + r0, periods) - Math.Pow(1 + r0, periods) + r0 + 1) + presentValue * Math.Pow(1 + r0, periods) * (-periods * r0 * r0 * t + Math.Pow(1 + r0, periods) + r0 * (Math.Pow(1 + r0, periods) - periods - 1) - 1)) / ((r0 + 1) * (Math.Pow(1 + r0, periods) - 1) * (Math.Pow(1 + r0, periods) - 1) * (r0 * t + 1) * (r0 * t + 1)),
                        guess);
            }
            catch (IterationsExceededException<double> exc)
            {
                return exc.LastValue;
            }
        }

        public static decimal Rate(int periods, decimal presentValue, decimal futureValue, decimal monthlyPayment, PaymentType type)
        {
            decimal t = (int)type;
            decimal N0 = periods;
            decimal guess = ((monthlyPayment * periods) - presentValue) / presentValue;

            try
            {
                return NewtonRaphson.Iterate(
                       (decimal r0) => (presentValue * DecimalMath.Pow(1M + r0, periods) - futureValue) / ((1M + r0 * t) * ((DecimalMath.Pow(1M + r0, periods) - 1) / r0)) - monthlyPayment,
                       (decimal r0) => (futureValue * (N0 * r0 * r0 * t * DecimalMath.Pow(1M + r0, periods) + periods * r0 * DecimalMath.Pow(1M + r0, periods) - r0 * DecimalMath.Pow(1M + r0, periods) - DecimalMath.Pow(1M + r0, periods) + r0 + 1) + presentValue * DecimalMath.Pow(1M + r0, periods) * (-N0 * r0 * r0 * t + DecimalMath.Pow(1M + r0, periods) + r0 * (DecimalMath.Pow(1 + r0, periods) - periods - 1) - 1)) / ((r0 + 1) * (DecimalMath.Pow(1 + r0, periods) - 1) * (DecimalMath.Pow(1 + r0, periods) - 1) * (r0 * t + 1) * (r0 * t + 1)),
                       guess);
            }
            catch (IterationsExceededException<decimal> exc)
            {
                return exc.LastValue;
            }
        }

        public static double Periods(double rate, double presentValue, double monthlyPayment, double futureValue, PaymentType type)
        {
            int N = 0;
            int pmtInt = (int)monthlyPayment;

            for (; true; ++N)
            {
                int pmtTemp = (int)MonthlyPayment(rate, N + 1, presentValue, futureValue, type);

                if (pmtTemp < pmtInt)
                {
                    return N;
                }
            }
        }

        public static decimal Periods(decimal rate, decimal presentValue, decimal monthlyPayment, decimal futureValue, PaymentType type)
        {
            int N = 0;
            int pmtInt = (int)monthlyPayment;

            for (; true; ++N)
            {
                int pmtTemp = (int)MonthlyPayment(rate, N + 1, presentValue, futureValue, type);

                if (pmtTemp < pmtInt)
                {
                    return N;
                }
            }
        }

        public static double MonthlyPayment(double rate, double periods, double presentValue, double futureValue, PaymentType type)
        {
            if (rate == 0)
            {
                return (presentValue - futureValue) / periods;
            }

            double t = (int)type;

            return (presentValue * Math.Pow(1 + rate, periods) - futureValue) / ((1 + rate * t) * ((Math.Pow(1 + rate, periods) - 1) / rate));
        }

        public static decimal MonthlyPayment(decimal rate, int periods, decimal presentValue, decimal futureValue, PaymentType type)
        {
            if (rate == 0)
            {
                return (presentValue - futureValue) / periods;
            }

            decimal t = (int)type;

            return (presentValue * DecimalMath.Pow(1 + rate, periods) - futureValue) / ((1 + rate * t) * ((DecimalMath.Pow(1 + rate, periods) - 1) / rate));
        }

        public static double PresentValue(double rate, double periods, double elapsedPeriods, double monthlyPayment, double futureValue, PaymentType type)
        {
            if (rate == 0)
            {
                return futureValue + monthlyPayment * (periods - elapsedPeriods);
            }

            if (elapsedPeriods == periods)
            {
                return futureValue;
            }

            double t = (int)type;

            return (monthlyPayment * (1 + rate * t) * ((Math.Pow(1 + rate, periods - elapsedPeriods) - 1) / rate) + futureValue) / Math.Pow(1 + rate, periods - elapsedPeriods);
        }

        public static decimal PresentValue(decimal rate, int periods, int elapsedPeriods, decimal monthlyPayment, decimal futureValue, PaymentType type)
        {
            if (rate == 0)
            {
                return futureValue + monthlyPayment * (periods - elapsedPeriods);
            }

            if (elapsedPeriods == periods)
            {
                return futureValue;
            }

            decimal t = (int)type;

            return (monthlyPayment * (1 + rate * t) * ((DecimalMath.Pow(1 + rate, periods - elapsedPeriods) - 1) / rate) + futureValue) / DecimalMath.Pow(1 + rate, periods - elapsedPeriods);
        }

        public static double FutureValue(double periods, double presentValue, double rate, double monthlyPayment, PaymentType type)
        {
            double t = (int)type;
            return Math.Round(-1 * ((((1 + rate * t) * ((Math.Pow(1 + rate, periods) - 1) / rate)) * monthlyPayment) - (presentValue * Math.Pow(1 + rate, periods))), 8);
        }

        public static decimal FutureValue(int periods, decimal presentValue, decimal rate, decimal monthlyPayment, PaymentType type)
        {
            decimal t = (int)type;
            return Math.Round(-1 * ((((1 + rate * t) * ((DecimalMath.Pow(1 + rate, periods) - 1) / rate)) * monthlyPayment) - (presentValue * DecimalMath.Pow(1 + rate, periods))), 8);
        }
    }
}
