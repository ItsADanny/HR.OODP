public class HOF
{
    // //How would we store this method?
    // Func<Func<int, int>, Action<int[]>> genAct = GenerateMethod;

    // //How would we call this method so that 1 is added?
    // Action<int[]> addOne = GenerateMethod(num => num + 1);

    // //How would we invoke the returned method;
    // int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 9, 10 };
    // addOne(numbers);

    // //How could you di it all in one line?
    // GenerateMethod(num => num + 1)(numbers);

    // static Action<int[]> GenerateMethod(Func<int, int> update)
    // {
    //     return arr =>
    //     {
    //         for (int i = 0; i < arr.Length; i++)
    //         {
    //             arr[i] = update(arr[1]);
    //         }
    //     };
    // }

    static void CurriedLambdas()
    {
        Func<int, int> add1 = x => x + 1;
        Func<int, int> add2 = x => x + 2;
        Func<int, int> add3 = x => x + 3;
    }
}