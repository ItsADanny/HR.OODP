static class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Modifiers": TestModifiers(); return;
            case "Car": TestCar(); return;
            case "Factory": TestFactory(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestModifiers()
    {
        Console.WriteLine("The field modifiers are correct: " +
            TestFieldModifiers.AreModifiersCorrect()); // Hidden test
    }
    
    public static void TestCar()
    {
        Console.Write("How many cars will be created? ");
        int amount = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < amount; i++)
        {
            LimitedEditionCar car = new();
            Console.WriteLine($"Car chassis number: {car.ChassisNumber}");
        }

        Console.WriteLine($"Counter after creating {amount} cars: {LimitedEditionCar.Counter}");
    }
    
    public static void TestFactory()
    {
        Console.Write("What is the limit for the amount of cars? ");
        int limit = Convert.ToInt32(Console.ReadLine());
        CarFactory factory = new(limit);

        Console.WriteLine("Starting production...");
        for (int i = 0; i < 10; i++)
        {
            LimitedEditionCar car = factory.ProduceLimitedEditionCar();
            if (car != null)
            {
                Console.WriteLine($" - Car #{i+1} produced");
            }
            else
            {
                Console.WriteLine("Not allowed to produce more");
                return;
            }
        }
    }
}