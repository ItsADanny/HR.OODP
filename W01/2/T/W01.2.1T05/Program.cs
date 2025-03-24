static class Program
{
    static void Main()
    {
        var pack = new List<string>()
        {
            "laptop",
            "lunch",
            "notebook",
            "pen",
        };

        Console.WriteLine($"The first item in the pack is a " + pack[0]);
        //Only thing you need to do is add a - 1 to the pack.Count 
        //to solve this assignment
        Console.WriteLine($"The last item in the pack is a " + pack[pack.Count - 1]);
    }
}