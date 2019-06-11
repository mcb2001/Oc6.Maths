using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Oc6.Maths.UnitTests
{
    [TestClass]
    public sealed class LoanFunctionsDecimalTests
    {
        private readonly int periods = 84;
        private readonly decimal presentValue = 1000000.0M;
        private readonly decimal midValue = 573573.91732153818245070789658M;
        private readonly decimal futureValue = 100000M;
        private readonly decimal monthlyPayment = 12111.690831836007850590867629M;
        private readonly decimal rate = 0.0025M; // 3%
        private readonly PaymentType type = PaymentType.BeginningOfPeriod;

        [TestMethod]
        public void Rate()
        {
            decimal actual = LoanFunctions.Rate(periods, presentValue, futureValue, monthlyPayment, type);
            Assert.AreEqual(rate, actual);
        }

        [TestMethod]
        public void Periods()
        {
            decimal actual = LoanFunctions.Periods(rate, presentValue, monthlyPayment, futureValue, type);
            Assert.AreEqual(periods, actual);
        }

        [TestMethod]
        public void MonthlyPayment()
        {
            decimal actual = LoanFunctions.MonthlyPayment(rate, periods, presentValue, futureValue, type);
            Assert.AreEqual(monthlyPayment, actual);
        }

        [TestMethod]
        public void PresentValue_Start()
        {
            decimal actual = LoanFunctions.PresentValue(rate, periods, 0, monthlyPayment, futureValue, type);
            Assert.AreEqual(presentValue, actual);
        }

        [TestMethod]
        public void PresentValue_Mid()
        {
            decimal actual = LoanFunctions.PresentValue(rate, periods, 42, monthlyPayment, futureValue, type);
            Assert.AreEqual(midValue, actual);
        }

        [TestMethod]
        public void PresentValue_End()
        {
            decimal actual = LoanFunctions.PresentValue(rate, periods, periods, monthlyPayment, futureValue, type);
            Assert.AreEqual(futureValue, actual);
        }

        [TestMethod]
        public void FutureValue()
        {
            decimal actual = LoanFunctions.FutureValue(periods, presentValue, rate, monthlyPayment, type);
            Assert.AreEqual(futureValue, actual);
        }
    }
}
