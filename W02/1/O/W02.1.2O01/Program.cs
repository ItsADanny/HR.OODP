//We create a class called Program, which will start when we execute the script
class Program
{
    //In this Program class we create a method called Main, this will be automaticly called when the program boots up
    public static void Main() {
        //We request an input year from the user
        int int_input_year = Convert.ToInt32(Console.ReadLine());
        //We then print if this is a leap year
        PrintIsLeapYear(int_input_year);
    }

    //This function returns a true or false based on if 2 values are divisible
    public static bool IsDivisibleBy(int int_numb_one, int int_numb_two) {
        //Here we check if its possible to divise 2 values and have a 0 at the end
        if (Convert.ToDouble(int_numb_one) % Convert.ToDouble(int_numb_two) == 0) {
            //If so we return true
            return true;
        } else {
            //Else we return false
            return false;
        }
    }

    //This function will return a true or false based on if a input year is a leap year or not
    public static bool IsLeapYear(int int_year) {
        //First we check if a year is divisible by 4
        if (IsDivisibleBy(int_year, 4)) {
            //Secondly we check if a year is not divisible by 100 or if it can be divised by 400
            if (!IsDivisibleBy(int_year, 100) || IsDivisibleBy(int_year, 400)) {
                //If both are correct then we return a true
                return true;
            } else {

            }
        }
        //Else we return a false
        return false;
    }

    //This function will print if a year is a leap year or is not a leap year
    public static void PrintIsLeapYear(int int_year) {
        //We call the function IsLeapYear which will return a true or false based on if a year is a leap year
        if (IsLeapYear(int_year)) {
            Console.WriteLine($"{int_year} is a leap year");
        } else {
            Console.WriteLine($"{int_year} is not a leap year");
        }
    }
}