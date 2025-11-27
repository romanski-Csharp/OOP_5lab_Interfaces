using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_5lab_Interfaces;

namespace MyNumberTests
{
    [TestClass]
    public class MyComplexTests
    {
        private const double Epsilon = 1e-9;

        [TestMethod]
        [DynamicData(nameof(TestData.ComplexMultiplyData), typeof(TestData))]
        public void ComplexMultiply_ShouldBeCorrect(
            double reA, double imA, double reB, double imB, double expectedRe, double expectedIm)
        {
            MyComplex a = new MyComplex(reA, imA);
            MyComplex b = new MyComplex(reB, imB);
            MyComplex expected = new MyComplex(expectedRe, expectedIm);

            MyComplex result = a.Multiply(b);

            Assert.AreEqual(expected.Re, result.Re, Epsilon, "Incorrect: (Re).");
            Assert.AreEqual(expected.Im, result.Im, Epsilon, "Incorrect: (Im).");
        }
        [TestMethod]
        [DynamicData(nameof(TestData.ComplexDivideData), typeof(TestData))]
        public void ComplexDivide_ShouldBeCorrect(
            double reA, double imA, double reB, double imB, double expectedRe, double expectedIm)
        {
            MyComplex a = new MyComplex(reA, imA);
            MyComplex b = new MyComplex(reB, imB);
            MyComplex expected = new MyComplex(expectedRe, expectedIm);

            MyComplex result = a.Divide(b);

            Assert.AreEqual(expected.Re, result.Re, Epsilon, "Incorrect: (Re).");
            Assert.AreEqual(expected.Im, result.Im, Epsilon, "Incorrect: (Im).");
        }
        [TestMethod]
        [DynamicData(nameof(TestData.ComplexDivideByZeroData), typeof(TestData))]
        public void ComplexDivideByZero_ShouldThrowException(double reA, double imA, double reB, double imB)
        {
            MyComplex zeroComplex = new MyComplex(reA, imA);
            MyComplex nonZero = new MyComplex(reB, imB);

            Assert.ThrowsException<DivideByZeroException>(() => nonZero.Divide(zeroComplex),
                "Deviding by 0+0i didn't throw a DivideByZeroException.");
        }
    }
}
