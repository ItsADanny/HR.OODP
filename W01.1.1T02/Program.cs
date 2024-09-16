Int32 int32_age;
Double double_age;

Console.WriteLine("What is your age?");
int32_age = Convert.ToInt32(int.Parse(Console.ReadLine()));
double_age = Convert.ToDouble(int32_age);
Console.WriteLine("You are " + int32_age.ToString() + ". That's old enough to program!");
Console.WriteLine("Last year you were " + (int32_age - 1));
Console.WriteLine("Next year you will be " + (int32_age + 1));
Console.WriteLine("At double your age you will be " + (int32_age * 2));
Console.WriteLine("Next year, double your age will be " + ((int32_age + 1) * 2));

Console.WriteLine("Half your age is " + (double_age / 2.0));
Console.WriteLine("Half your age (rounded down) is " + (int32_age / 2));
Console.WriteLine("The last digit of your age is " + (int32_age % 10));
