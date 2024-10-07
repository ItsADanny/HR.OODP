double double_temp_celcius, double_temp_fahrenheit;

Console.WriteLine("What is the temperature in Celsius?");
double_temp_celcius = Convert.ToDouble(Console.ReadLine());
double_temp_fahrenheit = (double_temp_celcius * 1.8) + 32;
Console.WriteLine(double_temp_celcius + " C = " + double_temp_fahrenheit + " F");
Console.WriteLine("Truncated that is " + (int) double_temp_fahrenheit + " F");