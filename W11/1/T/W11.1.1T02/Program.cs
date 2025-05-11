public class Program
{
    public static void Main(string[] args)
    {
        switch (args[1])
        {
            case "GET":
                TestGet(); break;
            case "PRINT":
                TestPrint(); break;
            default: throw new ArgumentException();
        }
    }

    private static void TestGet()
    {
        Console.WriteLine("=== Testing method GetTestResult ===");
        int[] pointsObtained = new[] {0, 55, 100 };
        int[] maxPoints = new[] { 100, 200 };
        foreach (int max in maxPoints)
        {
            foreach (int points in pointsObtained)
            { 
                var result = TestResultProcessor.GetTestResult(points, max);
                PrintTestResult(result);
            }
        }
    }

    private static void TestPrint()
    {
        Console.WriteLine("=== Testing method PrintTestResult ===");
        Tuple<double, bool>[] results = new[]
        {
            Tuple.Create(5.5, true),
            Tuple.Create(10.0, true),
            Tuple.Create(5.4, false),
            Tuple.Create(2.5, false),
        };

        foreach (var result in results)
        {
            PrintTestResult(result);
        }
    }

    private static void PrintTestResult(Tuple<double, bool> result)
    {
        Console.WriteLine("Grade: " + result.Item1);
        Console.WriteLine(result.Item2 ? "Passed" : "Did not pass");
    }
}