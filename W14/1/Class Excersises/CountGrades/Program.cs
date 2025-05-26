public class Program
{
    public static void Main()
    {
        List<double> examGrades = [
            2.8,
            4.7,
            8.9,
            8,
            6,
            9,
            10,
            1.2
        ];

        Console.Clear();
        Console.WriteLine("RECURSIVE VERSION\n========================================================");
        int passed = CountGrades(examGrades);
        Console.WriteLine($"This many exam grades were a pass: {passed}");

        int passedWith10 = CountGrades(examGrades, 10);
        int failed = CountGrades(examGrades, 5.4);
        Console.WriteLine($"This many exam grades were passed with a 10: {passedWith10}");
        Console.WriteLine($"This many exam grades failed: {failed}");

        Console.WriteLine("\nRECURSIVE VERSION (HOF Version)\n========================================================");
        Func<double, int> PassedCheck = (grade) => grade >= 5.5 ? 1 : 0;
        int HOFpassed = CountGradesHOF(examGrades, PassedCheck);
        Console.WriteLine($"This many exam grades were a pass: {passed}");

        Func<double, int> PassedWith10Check = (grade) => grade >= 10 ? 1 : 0;
        int HOFpassedWith10 = CountGradesHOF(examGrades, PassedWith10Check);
        Func<double, int> FailedCheck = (grade) => grade <= 5.4 ? 1 : 0;
        int HOFfailed = CountGradesHOF(examGrades, FailedCheck);
        Console.WriteLine($"This many exam grades were passed with a 10: {passedWith10}");
        Console.WriteLine($"This many exam grades failed: {failed}");
        
        Console.WriteLine("\nFOREACH VERSION\n========================================================");
        int ForeachPassed = CountGradesForEach(examGrades);
        Console.WriteLine($"This many exam grades were a pass: {ForeachPassed}");

        int ForeachPassedWith10 = CountGradesForEach(examGrades, 10);
        int ForeachFailed = CountGradesForEach(examGrades, 5.4);
        Console.WriteLine($"This many exam grades were passed with a 10: {ForeachPassedWith10}");
        Console.WriteLine($"This many exam grades failed: {ForeachFailed}");
    }

    //Recursive method for counting grades
    public static int CountGrades(List<double> grades, double criteria = 5.5)
    {
        if (grades.Count() == 0) return 0;
        int passed = criteria >= 5.5 ? grades[0] >= criteria ? 1 : 0 : grades[0] <= criteria ? 1 : 0;
        return passed + CountGrades(grades.GetRange(1, grades.Count - 1), criteria);
    }

    //Recursive method for counting grades (With HOF)
    public static int CountGradesHOF(List<double> grades, Func<double, int> criteria)
    {
        if (grades.Count() == 0) return 0;
        int passed = criteria(grades[0]);
        return passed + CountGradesHOF(grades.GetRange(1, grades.Count - 1), criteria);
    }

    //Foreach method for counting grades
    public static int CountGradesForEach(List<double> grades, double criteria = 5.5)
    {
        int passed = 0;
        foreach (double grade in grades)
        {
            passed += criteria >= 5.5 ? grade >= criteria ? 1 : 0 : grade <= criteria ? 1 : 0;
        }
        return passed;
    }
}