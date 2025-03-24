static class Program
{
    static void Main()
    {
        Console.WriteLine("Give the circle radius:");
        double radius = Convert.ToDouble(Console.ReadLine());
        Circle circle = new(radius);

        Console.WriteLine($"Rounded circle area: {Math.Round(circle.GetArea())}");
    }
}