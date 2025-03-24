//First we request a start number and an end number from the user
int int_start_numb = Convert.ToInt32(Console.ReadLine());
int int_end_numb = Convert.ToInt32(Console.ReadLine());

//Because we need to use a For-loop for this assignment we will enter a For-loop until we reach the end number
for (;int_start_numb != (int_end_numb + 1); int_start_numb++) {
    //If we can divide the number by 3 and 5 then we print "FizzBuzz"
    if (int_start_numb % 3 == 0 & int_start_numb % 5 == 0) {
        Console.WriteLine("FizzBuzz");
    //If we can only divide it by 3 then we print "Fizz"
    } else if (int_start_numb % 3 == 0) {
        Console.WriteLine("Fizz");
    //If we can only divide it by 5 then we print "Buzz"
    } else if (int_start_numb % 5 == 0) {
        Console.WriteLine("Buzz");
    //Otherwise we just print the number
    } else {
        Console.WriteLine(int_start_numb);
    }
}