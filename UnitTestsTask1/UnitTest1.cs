using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace UnitTestsTask1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PolynomialTest1()
        {
            var a = new Polynomial(1.5, 2, 3).ToString();
            Assert.AreEqual("3*x^2 + 2*x^1 + 1,5", a);
        }
        [TestMethod]
        public void PolynomialTest2()
        {
            var a = new Polynomial(0).ToString();
            Assert.AreEqual("0", a);
        }
        [TestMethod]
        public void PolynomialTest3()
        {
            var a = new Polynomial(1.5, 2, 3, 0, 0).ToString();
            Assert.AreEqual("3*x^2 + 2*x^1 + 1,5", a);
        }
        [TestMethod]
        public void PolynomialTest4()
        {
            var a = new Polynomial(1, 0, 3).ToString();
            Assert.AreEqual("3*x^2 + 1", a);
        }
        [TestMethod]
        public void PolynomialOperatorsTest1()
        {
            var a = (new Polynomial(1, 0, 3) + new Polynomial(2, 3, 4, 5)).ToString();
            Assert.AreEqual("5*x^3 + 7*x^2 + 3*x^1 + 3", a);
        }
        [TestMethod]
        public void PolynomialOperatorsTest2()
        {
            var a = (new Polynomial(2, 3, 4, 5) - new Polynomial(1, 0, 3)).ToString();
            Assert.AreEqual("5*x^3 + 1*x^2 + 3*x^1 + 1", a);
        }
        [TestMethod]
        public void PolynomialOperatorsTest3()
        {
            var a = (new Polynomial(2, 3, 4, 5) * new Polynomial(1, 0, 3)).ToString();
            Assert.AreEqual("15*x^5 + 12*x^4 + 14*x^3 + 10*x^2 + 3*x^1 + 2", a);
        }
        [TestMethod]
        public void PolynomialCalculateTest1()
        {
            var a = new Polynomial(1, 0, 3).Calculate(3);
            Assert.AreEqual(28, a);
        }
    }
}
