public class Manager : Employee
{
    public Manager(string name, double salary) : base(name, salary) { }
    public Manager(Employee employee)
        : this(employee.Name, employee.Salary + 1000) { }

    public int TeamSize { get; set; }

    public override string Info => base.Info + "; Team Size: 10";
}