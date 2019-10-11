using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oc6.Maths.Numbers;
using Oc6.Maths.Util;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public sealed class LoanFunctionsDoubleTests
    {
        private readonly int periods = 84;
        private readonly double presentValue = 1000000.0;
        private readonly double midValue = 573573.91732153727;
        private readonly double futureValue = 100000;
        private readonly double monthlyPayment = 12111.690831836235;
        private readonly double rate = 0.0025; // 3%
        private readonly PaymentType type = PaymentType.BeginningOfPeriod;

        [TestMethod]
        public void Rate()
        {
            double actual = LoanFunctions.Rate(periods, presentValue, futureValue, monthlyPayment, type);
            Assert.AreEqual(rate, actual);
        }

        [TestMethod]
        public void Periods()
        {
            double actual = LoanFunctions.Periods(rate, presentValue, monthlyPayment, futureValue, type);
            Assert.AreEqual(periods, actual);
        }

        [TestMethod]
        public void MonthlyPayment()
        {
            double actual = LoanFunctions.MonthlyPayment(rate, periods, presentValue, futureValue, type);
            Assert.AreEqual(monthlyPayment, actual);
        }

        [TestMethod]
        public void PresentValueStart()
        {
            double actual = LoanFunctions.PresentValue(rate, periods, 0, monthlyPayment, futureValue, type);
            Assert.AreEqual(presentValue, actual);
        }

        [TestMethod]
        public void PresentValueMid()
        {
            double actual = LoanFunctions.PresentValue(rate, periods, 42, monthlyPayment, futureValue, type);
            Assert.AreEqual(midValue, actual);
        }

        [TestMethod]
        public void PresentValueEnd()
        {
            double actual = LoanFunctions.PresentValue(rate, periods, periods, monthlyPayment, futureValue, type);
            Assert.AreEqual(futureValue, actual);
        }

        [TestMethod]
        public void FutureValue()
        {
            double actual = LoanFunctions.FutureValue(periods, presentValue, rate, monthlyPayment, type);
            Assert.AreEqual(futureValue, actual);
        }
    }
}
