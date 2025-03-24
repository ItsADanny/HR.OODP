static class Program
{
    static void Main()
    {
        Console.WriteLine("Give the first number:");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Give the second number:");
        double y = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"{x} + {y} = {Calculator.Add(x, y)}");
        Console.WriteLine($"{x} - {y} = {Calculator.Subtract(x, y)}");
        Console.WriteLine($"{x} * {y} = {Calculator.Multiply(x, y)}");
        Console.WriteLine($"{x} / {y} = {Calculator.Divide(x, y)}");
        Console.WriteLine($"{x} % {y} = {Calculator.Modulo(x, y)}");
    }
}