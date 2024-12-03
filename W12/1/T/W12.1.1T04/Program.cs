public class Program
{
    private static Random? rand;

    public static void Main(string[] args)
    {
        int seed = Convert.ToInt32(args[1]);
        rand = new(seed);

        for (int i = 0; i < 5; i++)
        {
            int[] ints = GenerateRandomArray();
            Console.WriteLine(RecSumArray(ints));
        }
    }

    private static int[] GenerateRandomArray()
    {
        int length = rand.Next(0, 11); // Generate a random length between 1 and 10
        var arr = new int[length];
        for (int i = 0; i < length; i++)
        {
            arr[i] = rand.Next(100); // Generate a random integer between 0 and 99
        }
        return arr;
    }

    //TODO: Currently contains an error thanks to which this won't work, I will check this on a later date
    public static int RecSumArray(int[] n) {
        if (n.Count() < 0) { //Base case
            return 0; // Base step
        }
        else
        { //Recursive case
            return RecSumArray(n, n.Count()); //Recursive step
        }
    }

    public static int RecSumArray(int[] n, int index) {
        if (index < n.Count()) { //Base case
            return 0; // Base step
        }
        else
        { //Recursive case
            return n[index] + RecSumArray(n, index - 1); //Recursive step
        }
    }
}