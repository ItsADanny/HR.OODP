public class Program {
    public static void Main() {
        JaggedArrays();
        Console.WriteLine(TriangularJaggedArray(5));
    }

    public static void JaggedArrays() {
        string[][] groups = [
            ["John", "Mary", "Joe"],
            ["", "", ""],
            ["Lisa", "Bart", "Maggie", "Marge", "Homer"]
        ];


        //Length
        int Length = groups.Length;
        int LengthOfLast = groups[^1].Length;

        //Accessing elements
        string firstInFirst = groups[0][0];
        string firstInSecond = groups[1][0];
        string lastInLast = groups[2][4];
        string lastInLast2 = groups[^1][^1];

        //Print using for
        Console.WriteLine("---\nfor:");
        for (int i = 0; i < groups.Length ; i++) {
            for (int j = 0; j < groups[i].Length; j++) {
                Console.Write(groups[i][j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static int[][] TriangularJaggedArray(int size) {
        //Create an JaggedArray, with the first array's size based on the size parameter
        int[][] triangle = new int[size][];

        for (int i = 0; i < triangle.Length; i++) {
            //We set the size of our "inner" array to the current i + 1.
            triangle[i] = new int[i + 1];

            //We then use a for-loop to iterate and fill our "inner" array's integer fields with 1's
            for (int j = 0; j < triangle[i].Length; j++) {
                triangle[i][j] = 1;
            }
        }

        //We then return the results
        return triangle;

        //Example of what a result could look like (if you input 4):
        // [1]
        // [1, 1]
        // [1, 1, 1]
        // [1, 1, 1, 1]
    }
}