static class Program
{
    static void Main()
    {
        Console.WriteLine("Press how many times?");
        int pressHowManyTimes = Convert.ToInt32(Console.ReadLine());
        
        Button button = new();
        for (int i = 0; i < pressHowManyTimes; i++)
        {
            button.Press();
        }
        
        Console.WriteLine(button.Info());
    }
}