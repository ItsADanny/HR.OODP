class Job
{
    public string Name;
    public double Salary;

    public Job(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

    public Job? GetJobWithHigherSalary(Job? other) => Salary >= other.Salary ? this : other;
}