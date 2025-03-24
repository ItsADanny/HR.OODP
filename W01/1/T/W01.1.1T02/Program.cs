static class Program
{
    static void Main()
    {
        Console.WriteLine("What is your age?");
        int int_age = Convert.ToInt32(int.Parse(Console.ReadLine()));
         double double_age = Convert.ToDouble(int_age);
        Console.WriteLine("You are " + int_age.ToString() + ". That's old enough to program!");
        Console.WriteLine("Last year you were " + (int_age - 1));
        Console.WriteLine("Next year you will be " + (int_age + 1));
        Console.WriteLine("At double your age you will be " + (int_age * 2));
        Console.WriteLine("Next year, double your age will be " + ((int_age + 1) * 2));

        Console.WriteLine("Half your age is " + (double_age / 2.0));
        Console.WriteLine("Half your age (rounded down) is " + (int_age / 2));
        Console.WriteLine("The last digit of your age is " + (int_age % 10));
    }
}