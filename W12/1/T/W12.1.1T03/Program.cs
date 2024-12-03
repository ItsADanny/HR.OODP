class Program {
    static void Main() {
        //W12.1.1T01
        // Console.WriteLine(SumRecursive(Convert.ToInt32(Console.ReadLine())));

        //W12.1.1T02
        // Console.WriteLine(Factorial(Convert.ToInt32(Console.ReadLine())));

        //W12.1.1T03
        int num = Convert.ToInt32(Console.ReadLine());
        int logBase = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(RecursiveLog(num, logBase));
    }

    //W12.1.1T01
    public static int SumRecursive(int n) {
        if (n <= 0) { //Base case
            return 0; // Base step
        }
        else
        { //Recursive case
            return n + SumRecursive(n -1); //Recursive step
        }
    }

    //W12.1.1T02
    public static int Factorial(int n) {
        if (n <= 0) { //Base case
            return -1; // Base step
        }

        if (n == 1) {
            return 1;
        }
        else
        { //Recursive case
            return n * Factorial(n - 1); //Recursive step
        }
    }

    //W12.1.1T03
    public static int RecursiveLog(int num, int logBase) {
        if (num < logBase) { //Base case
            return 0; // Base step
        }
        else
        { //Recursive case
            return 1 + RecursiveLog(num / logBase, logBase); //Recursive step
        }
    }
}