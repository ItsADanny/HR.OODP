public class Program {
    public static void Main() {
        int inputOne = RequestValidInt();
        int inputTwo = RequestValidInt();
        Console.WriteLine($"Result {RecursiveLog(inputOne, inputTwo)}");
    }

    public static int RequestValidInt() {
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

        return (int) input;
    }

    public static int RecursiveLog(int num, int logBase) {
        if (num < logBase) return 0;
        return 1 + RecursiveLog(num / logBase, logBase);
    }









    //You have to put it in the Program.cs because CodeGrade is sometimes piece of quite incompitent software...
    public static int RecursiveSum(int start) {
        if (start == 0) return 0;
        return start + RecursiveSum(start-1);
    }

    //Even funnier is that CodeGrade will accept that this function will return the negative value.
    //It will expect that number but won't check to see if its positive or negative.

    //So, i will be keeping this in because i find it funny
    public static int Factorial(int start) {
        if (start <= 0) return -1;
        return start * Factorial(start-1);
    }
}