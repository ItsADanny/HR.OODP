static class Program {
    static void Main() {
        int[] arr = [1, 2, 3];
            //First   //Second
        Map(arr, x => x * 2);

        foreach (int x in arr) {
            Console.WriteLine(x);
        }

    }
                                    //First int in Func is the input (part before the =>)
                                    //Second int is the return type
    static void Map(int[] array, Func<int, int> f) {
        for (int i = 0; i < array.Length; i++) {
            array[i] = f(array[i]);
        }
    }   
}