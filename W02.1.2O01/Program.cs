class Program
{
    public static void Main() {
        int int_input_year = Convert.ToInt32(Console.ReadLine());
        PrintIsLeapYear(int_input_year);
    }

    public static bool IsDivisibleBy(int int_numb_one, int int_numb_two) {
        if (Convert.ToDouble(int_numb_one) / Convert.ToDouble(int_numb_two) ==
            (int) (Convert.ToDouble(int_numb_one) / Convert.ToDouble(int_numb_two))) {
            return true;
        } else {
            return false;
        }
    }

    public static bool IsLeapYear(int int_year) {
        if (IsDivisibleBy(int_year, 4)) {
            return true;
        } else {
            return false;
        }
    }

    public static void PrintIsLeapYear(int int_year) {
        if (IsLeapYear(int_year)) {
            Console.WriteLine($"{int_year} is a leap year");
        } else {
            Console.WriteLine($"{int_year} is not a leap year");
        }
    }
}