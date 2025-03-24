namespace LeapYear.Tests;

[TestClass]
public class LeapYearTest
{
    [DataTestMethod]
    [DataRow(10, 2, true)]
    [DataRow(150, 3, true)]
    [DataRow(50, 3, false)]
    [DataRow(70, 15, false)]
    public void TestIsDivisibleBy(int dividend, int divisor, bool expected)
    {
        bool actual = Program.IsDivisibleBy(dividend, divisor);
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(2000, true)]
    [DataRow(1012, true)]
    [DataRow(4000, true)]
    [DataRow(1000, false)]
    [DataRow(2100, false)]
    [DataRow(2019, false)]
    public void Test_IsLeapYear(int year, bool expected)
    {
        bool actual = Program.IsLeapYear(year);
        Assert.AreEqual(expected, actual);
    }
}