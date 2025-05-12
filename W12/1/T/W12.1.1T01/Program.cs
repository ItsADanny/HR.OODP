public class Program {
    public static void Main() {
        int? input = null;
        do {
            Console.Clear();
            Console.WriteLine("Please input an integer");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int intValue)) {
                input = intValue;
            } else {
                Console.WriteLine("Invalid input, please input a valid integer");
            }
        } while (input is null);
        //RecursiveSum
        Console.WriteLine($"Result: {RecursiveSum((int) input)}");
    }

    //You have to put it in the Program.cs because CodeGrade is sometimes piece of quite incompitent software...
    public static int RecursiveSum(int start) {
        if (start == 0) return 0;
        return start + RecursiveSum(start-1);
    }
}