static class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Task": TestTask(); return;
            case "TODO": TestToDo(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }
    
    static void TestTask()
    {
        Task simple = new("Test");
        Console.WriteLine(simple.Info());
    }
    
    static void TestToDo()
    {
        ToDo today = new();
        today.AddTask("T1");
        today.AddTask("T2");
        today.AddTask("T3");
        today.AddTask("T4");

        Task task1 = today.GetTask("T2");
        Task task2 = today.GetTask("T4");
        Task task3 = today.GetTask("T5");

        task1?.Done(); // if (task1 != null) task1.Done(); 
        task2?.Done();
        task3?.Done();

        Console.WriteLine(today.Report());
    }
}