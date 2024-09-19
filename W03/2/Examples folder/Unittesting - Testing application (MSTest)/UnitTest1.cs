namespace Unittesting___Testing_application__MSTest_;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    [DataRow(1, 2, 3)]
    [DataRow(-5, 10, 5)]

    public void TestAdd(int x, int y, int expected) {
        int actual = Calculator.Add(x, y);
        Assert.AreEqual(actual, expected);
    }

    [TestMethod]
    [DataRow(5, 2, 3)]
    [DataRow(5, 10, 5)]

    public void TestMinus(int x, int y, int expected) {
        int actual = Calculator.Minus(x, y);
        Assert.AreEqual(actual, expected);
    }
}