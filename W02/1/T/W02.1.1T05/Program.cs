static class Program
{
    static void Main()
    {
        Square sq1 = new Square(5);
        Square sq2 = new Square(10);

        PrintSquarInfo(sq1);
        PrintSquarInfo(sq2);
    }

    //You can also just put this code into the upper part and run it for
    //both objects but i wanted to do it in a function
    public static void PrintSquarInfo(Square sq) {
        Console.WriteLine($"Side: {sq.Side}");
        Console.WriteLine($"Area: {sq.GetArea()}");
        Console.WriteLine($"Perimeter: {sq.GetPerimeter()}");
    }
}