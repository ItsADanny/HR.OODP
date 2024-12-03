class Program
{
    static Dictionary<long, long> dict = new Dictionary<long, long> {
            {0, 0},
            {1, 1},
    };
    
    static void Main()
    {
        Console.WriteLine(FibRecursive(50));
    }

    public static long FibRecursive(int n) {
        if (n < 0) throw new ArgumentException();
        if (n == 0) return 0;
        if (n == 1) return 1;

        long res = FibRecursive(n - 1) + FibRecursive(n - 2);
        dict.Add(n , res);
        return res;
    }
}
