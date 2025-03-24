static class Program
{
    static void Main()
    {
        List<Job> jobs = [
            new("Waiter", 25000.0),
            new("Math teacher", 50000.0),
            new("Clown", 10000.0),
            new("Developer", 90000.0),
            new("Bus Driver", 40000.0),
        ];

        Person person = new("Jane", jobs[0]);
        Console.WriteLine(person.Info());

        for (int i = 1; i < jobs.Count; i++)
        {
            person.DayJob = person.DayJob!.GetJobWithHigherSalary(jobs[i]);
        }
        Console.WriteLine(person.Info()); // Should now have the job with the highest salary

        person.DayJob = null!;
        Console.WriteLine(person.Info());
    }
}