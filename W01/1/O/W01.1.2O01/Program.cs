double double_time;

Console.WriteLine("How many seconds?");
double_time = Convert.ToDouble(Console.ReadLine());
//With this calculation we can turn the inputted seconds into Hours.
//By casting our double to Integer we automaticly remove the rounding (which would happen if we did Convert.ToInt32)
Console.WriteLine("Hours: " + (int) double_time / 3600);
//First we calculate the remaining seconds and then we divide those by 60 to get our minutes
Console.WriteLine("Minutes: " + (int) (double_time % 3600) / 60);
//Now that we have our Hours and minutes we need to calculate the remaining seconds.
//We do this by first calculating the remaining seconds and then the remaining seconds after we remove our minutes
//After this we get our remaining seconds
Console.WriteLine("Seconds left: " + (int) (double_time % 3600) % 60);
