public static class ArrayUtils
{
    public static void ReverseArray<T>(T[] arr)
    {
        RecReverseArray(arr, 0, arr.Length - 1);
    }

    //RecReverseArray goes here
    public static void RecReverseArray<T>(T[] arr, int i, int j) {
        if (i != j) {
            T I_item = arr[i];
            T J_item = arr[j];
            arr[i] = J_item;
            arr[j] = I_item;
            RecReverseArray(arr, i++, j--);
        }
    }

    public static void PrintArray<T>(T[] arr)
    {
        foreach (T elem in arr)
        {
            Console.WriteLine(elem);
        }
    }
}