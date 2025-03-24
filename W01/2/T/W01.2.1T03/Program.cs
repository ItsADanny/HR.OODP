static class Program
{
    static void Main()
    {
        String str_name;

        Console.WriteLine("What is the person's name?");
        str_name = Console.ReadLine();

        for (int i = 0; i != 4; i++) {
            if (i == 2) {
                Console.WriteLine("Happy birthday dear " + str_name + "!");
            } else {
                Console.WriteLine("Happy birthday to you!");
            }
        }
    }
}