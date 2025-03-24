static class Program
{
    static void Main()
    {
        Console.WriteLine("Enter an age:");
        int int_age = Convert.ToInt32(Console.ReadLine());

        string result = int_age switch
        {
            int n when (int_age >= 0 && int_age <= 12) => "Age " + int_age + ": a child",
            int n when (int_age >= 13 && int_age <= 19) => "Age " + int_age + ": a teenager",
            int n when (int_age >= 20 && int_age <= 150) => "Age " + int_age + ": an adult",
            _ => "Age " + int_age + ": invalid"
        };

        Console.WriteLine(result);
    }
}