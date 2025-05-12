static class ArrayUtils
{
    public static int FindMinimum(int[] arr)
    {
        Console.WriteLine($"ORIGINAL CALL INDEX: {arr.Length - 1}");
        return RecMinimum(arr, arr.Length - 1);
    }

    // RecMinimum goes here
    private static int RecMinimum(int[] data, int index) {
        if (index == 0) {
            return data[index];
        } else {
            return Math.Min(data[index], RecMinimum(data, index-1));
        }
    }
}
