class Consultant : IPayable
{
    public string Name { get; set; }
    public double HourlyRate { get; set; }
    public int HoursWorked { get; set; }
    public string Info {get {return $"{Name}; {HourlyRate}/hour";}}

    public Consultant(string name, double hourlyRate)
    {
        Name = name;
        HourlyRate = hourlyRate;
    }

    public double GetPaymentAmount() => HourlyRate * HoursWorked;
}
