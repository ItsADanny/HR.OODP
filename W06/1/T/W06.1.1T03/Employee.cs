class Employee : IPayable
{
    public static int EmployeeCounter = 0;

    public string Name { get; set; }
    public double Salary { get; set; }
    public int EmployeeId { get; set; }
    public string Info {get {return $"ID: {EmployeeId} ({Name}); {Salary}/month";}}

    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
        EmployeeId = ++EmployeeCounter;
    }

    public double GetPaymentAmount() => Salary;
}
