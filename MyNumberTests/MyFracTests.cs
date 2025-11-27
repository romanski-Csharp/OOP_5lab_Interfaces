using OOP_5lab_Interfaces;

namespace MyNumberTests
{
    [TestClass]
    public sealed class MyFracTests
    {
        [TestMethod]
        [DynamicData(nameof(TestData.FracAddData), typeof(TestData))]
        public void FracAdd_ShouldBeCorrect(int nomA, int denomA, int nomB, int denomB, int expectedNom, int expectedDenom)
        {
            MyFrac a = new MyFrac(nomA, denomA);
            MyFrac b = new MyFrac(nomB, denomB);
            MyFrac expected = new MyFrac(expectedNom, expectedDenom);

            MyFrac result = a.Add(b);
            Assert.AreEqual(expected, result, $"Incorrect adding: {a} + {b}.");
        }
        
        [TestMethod]
        [DynamicData(nameof(TestData.FracCompareData), typeof(TestData))]
        public void FracCompare_ShouldBeCorrect(int nomA, int denomA, int nomB, int denomB, int expectedComparison)
        {
            MyFrac a = new MyFrac(nomA, denomA);
            MyFrac b = new MyFrac(nomB, denomB);

            int result = a.CompareTo(b);

            Assert.AreEqual(expectedComparison, result.CompareTo(0), $"Comparing {a} and {b} is incorect.");

            if (expectedComparison == 0)
            {
                Assert.IsTrue(a.Equals(b), $"Incorrect equality {a} == {b}.");
            }
        }
        [TestMethod]
        [DynamicData(nameof(TestData.FracDivideByZeroDenomData), typeof(TestData))]
        public void FracDivideByZeroDenom_ShouldThrowException(int nomA, int denomA, int nomB, int denomB)
        {
            MyFrac a = new MyFrac(nomA, denomA);
            MyFrac b = new MyFrac(nomB, denomB);

            Assert.ThrowsException<DivideByZeroException>(() => a.Divide(a.Add(b)),
                "Dividing didn't throw a DivideByZeroException.");
        }
    }
}
