static class Program
{
    static void Main()
    {
        int int_attempts = 0;

        for (; int_attempts != 3; int_attempts++) {
            Console.WriteLine("Enter your PIN");
            Console.WriteLine(3 - int_attempts + " attempts left");
            
            String str_pin_attempt = Console.ReadLine();
             
            if (str_pin_attempt == "1234") {
                Console.WriteLine("Correct!");
                break;
            }
        }

        if (int_attempts == 3) {
            Console.WriteLine("Your pass is confiscated.");
        }
    }
}