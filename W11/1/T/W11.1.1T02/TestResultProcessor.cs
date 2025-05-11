public static class TestResultProcessor {
    public static Tuple<double, bool> GetTestResult(int points, int maxPoints) {
        double grade = (double)points / maxPoints * 10;
        bool passed = false;
        if (grade >= 5.5) {
            passed = true;
        }
        return new Tuple<double, bool>(grade, passed);
    }

    public static void PrintTestResult(Tuple<double, bool> result) {
        string resultStr = result.Item2 ? "Passed" : "Did not pass";
        Console.WriteLine($"Grade: {result.Item1}\n{resultStr}");
    }
}