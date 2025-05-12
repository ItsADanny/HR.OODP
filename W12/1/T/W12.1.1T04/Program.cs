public class Program {
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

    //My preferred and more flexible way of testing the RecSumArray
    // public static void Main() {
    //     Console.WriteLine($"Result: {RecSumArray(RequestData())}");
    // }

    // public static int[] RequestData() {
    //     List<int> returnValue = new List<int>();

    //     bool done = default;
    //     int pos = 1;
    //     do {
    //         string usrInput = Console.ReadLine();
    //         if (usrInput == "") {
    //             if (returnValue.Count >= 2) {
    //                 done = true;
    //             } else {
    //                 Console.WriteLine("Please input more data, The data should atleast contain 2 integer values");
    //             }
    //         } else {
    //             if (int.TryParse(usrInput, out int intValue)) {
    //                 returnValue.Add(intValue);
    //             } else {
    //                 Console.WriteLine("Invalid input, please input a valid integer");
    //             }
    //         }
    //     } while (!done);

    //     return returnValue.ToArray();
    // }

    public static int RecSumArray(int[] data) {
        return RecSumArray(data, data.Count()-1);
    }

    public static int RecSumArray(int[] data, int index) {
        if (index < 0) return 0;
        return data[index] + RecSumArray(data, index-1);
    }
}