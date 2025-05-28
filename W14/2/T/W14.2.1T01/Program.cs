public class Program
{
    public static void Main()
    {
        int[] numbers = new int[] { -32, 2, 49, 46, -33, 3, 17, 64, -13, -4, -79, 89, 20, -61, -64, -34, -86, -82, 51, -35, 31, 13, 18, -72, -20, 42, 77, 4, -88, -28, 1, -70, 99, -22, 93, 24, -65, 60, -15, 0, -59, 6, -80, 48, 98, 16, 80, -71, 45, 33, -9, -30, -89, -26, 27, -55, 69, -95, -31, -2, 75, 41, -46, 72, -44, -68, -50, 59, 39, -60, 22, 26, -58, -87, -14, 38, 83 };

        Console.WriteLine("Divisble by 2:");
        // Solution for this part

        // Missing from the template, but is the most important part that will be checked:
        // Selecting values that are divisible by 2 and print them from low to high
        int[] numbers_task1 = numbers.Where(n => n % 2 == 0).OrderBy(n => n).ToArray();
        Print(numbers_task1);

        Console.WriteLine();
        Console.WriteLine("Divisble by 2 and positive:");
        // Solution for this part

        // Missing from the template, but is the most important part that will be checked:
        // Selecting values that are divisible by 2 and positive and print them from high to low
        int[] numbers_task2 = numbers.Where(n => n % 2 == 0 && n > 0).OrderByDescending(n => n).ToArray();
        Print(numbers_task2);

    }

    public static void Print(int[] data)
    {
        foreach (int number in data) {
            Console.WriteLine(number);
        }
    }
}