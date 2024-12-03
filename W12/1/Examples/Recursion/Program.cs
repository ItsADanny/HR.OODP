class Program
{
    static void Main()
    {
        Console.WriteLine(SumRecursive(5));
    }

    public static int SumRecursive(int n) {
        if (n <= 0) { //Base case
            return 0; // Base step
        }
        else
        { //Recursive case
            return 1 + SumRecursive(n -1); //Recursive step
        }
    }
}
