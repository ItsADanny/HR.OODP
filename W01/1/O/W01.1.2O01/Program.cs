double double_time;

Console.WriteLine("How many seconds?");
double_time = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Hours: " + ((int) double_time / 3600));
Console.WriteLine("Minutes: " + (int) (Convert.ToDouble(((int) double_time / 3600)) - double_time) * 60);
Console.WriteLine("Seconds left: " + (((int) (Convert.ToDouble(((int) double_time / 3600)) - double_time) * 60) - double_time) * 60);