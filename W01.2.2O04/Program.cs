int int32_start_numb, int32_end_numb;

int32_start_numb = Convert.ToInt32(Console.ReadLine());
int32_end_numb = Convert.ToInt32(Console.ReadLine());

int[] ls_int_range = Enumerable.Range(int32_start_numb, int32_end_numb).ToArray();

foreach (int int_number in ls_int_range) {
    if (int_number % 3 == 0 & int_number % 5 == 0) {
        Console.WriteLine("FizzBuzz");
    } else if (int_number % 3 == 0) {
        Console.WriteLine("Fizz");
    } else if (int_number % 5 == 0) {
        Console.WriteLine("Buzz");
    } else {
        Console.WriteLine(int_number);
    }
}
