class Car : ICommute
{
    public int Mileage { get; private set; }
    public Car() => Mileage = 0;

    public void Move(int amount) {
        Mileage += amount;
        Console.WriteLine($"Drove {amount} kms\nMileage: {Mileage} kms");
    }
}