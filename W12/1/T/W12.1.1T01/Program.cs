class Program {
    static void Main() {
        Console.WriteLine(SumRecursive(Convert.ToInt32(Console.ReadLine())));
    }

    public static int SumRecursive(int n) {
        if (n <= 0) { //Base case
            return 0; // Base step
        }
        else
        { //Recursive case
            return n + SumRecursive(n -1); //Recursive step
        }
    }
}