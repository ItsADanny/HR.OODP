class Program
{
    public static void Main()
    {
        Point point1 = new(0, 0);
        Point point2 = new(1.5, 2.5);
        Point point3 = new(-3, -12.5);

        PrintEuclideanDistance(point1, point2);
        PrintEuclideanDistance(point1, point3);
        PrintEuclideanDistance(point2, point3);
    }

    private static void PrintEuclideanDistance(Point point1, Point point2)
    {
        Console.WriteLine($"Euclidean distance: {Math.Round(Point.EuclideanDistance(point1, point2), 2)}");
    }
}