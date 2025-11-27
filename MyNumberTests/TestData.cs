public static class TestData
{
    public static IEnumerable<object[]> FracAddData =>
        new[]
        {
            new object[] { 1, 2, 1, 3, 5, 6 },
            new object[] { 1, 4, 1, 4, 1, 2 },
            new object[] { 1, -2, 1, 3, -1, 6 },
            new object[] { 3, 1, -3, 1, 0, 1 }
        };
    public static IEnumerable<object[]> FracCompareData =>
        new[]
        {
            new object[] { 1, 2, 1, 3, 1 },
            new object[] { 1, 3, 1, 2, -1 },
            new object[] { 1, 2, 2, 4, 0 },
            new object[] { -1, 2, 1, 3, -1 }
        };
    public static IEnumerable<object[]> FracDivideByZeroDenomData =>
        new[]
        {   
            new object[] { 5, 1, -5, 1 },
            new object[] { 0, 1, 0, 1 },
            new object[] { 1, -2, 1, 2 }
        };
    public static IEnumerable<object[]> ComplexMultiplyData =>
        new[]
        {
            new object[] { 1.0, 1.0, 1.0, 1.0, 0.0, 2.0 },
            new object[] { 0.0, 1.0, 0.0, 1.0, -1.0, 0.0 },
            new object[] { 2.0, 3.0, 1.0, 4.0, -10.0, 11.0 }
        };
    public static IEnumerable<object[]> ComplexDivideData =>
        new[]
        {
            new object[] { 1.0, 0.0, 1.0, 1.0, 0.5, -0.5 },
            new object[] { 6.0, 8.0, 2.0, 0.0, 3.0, 4.0 },
            new object[] { 5.0, 0.0, 3.0, 4.0, 0.6, -0.8 }
        };
    public static IEnumerable<object[]> ComplexDivideByZeroData =>
        new[]
        {
            new object[] { 0.0, 0.0, 5.0, 5.0 },
            new object[] { 0.0, 0.0, 1.0, 0.0 },
            new object[] { 0.0, 0.0, -1.0, 2.0 }
        };
}
