public static class ArrayUtils
{
    public static void ReverseArray<T>(T[] arr)
    {
        RecReverseArray(arr, 0, arr.Length - 1);
    }

    //RecReverseArray goes here
    public static void RecReverseArray<T>(T[] data, int i, int j) {
        if (i == j) return;
        T valueOne = data[i];
        T valueTwo = data[j];
        data[i] = valueTwo;
        data[j] = valueOne;
        RecReverseArray(data, i+1, j-1);
    }

    public static void PrintArray<T>(T[] arr)
    {
        foreach (T elem in arr)
        {
            Console.WriteLine(elem);
        }
    }
}