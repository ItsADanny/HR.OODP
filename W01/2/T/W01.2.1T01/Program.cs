static class Program
{
    static void Main()
    {
        int int_wallet = 4;

        while (int_wallet != 0) {
            Console.WriteLine("Money left: " + int_wallet);
            Console.WriteLine("Look around (1) or go in a ride (2)?");
            string str_choice = Console.ReadLine();
             switch (str_choice)
            {
                case "1":
                    Console.WriteLine("Yay!");
                    break;
                case "2":
                    Console.WriteLine("Wheee!");
                    int_wallet--;
                    break;        
            }
        }
        
        Console.WriteLine("Time to go home");
    }
}