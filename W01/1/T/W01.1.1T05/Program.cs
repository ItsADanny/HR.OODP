static class Program
{
    static void Main()
    {
        double double_water_temp;

        Console.WriteLine("What is the temperature of the water? (Celsius)");
        double_water_temp = Convert.ToDouble(Console.ReadLine());

        if (double_water_temp >= 100) {
            Console.WriteLine("At " + double_water_temp + " degrees Celsius, the water will be gas");
        } else if (double_water_temp >= 0.1 & double_water_temp < 100) {
            Console.WriteLine("At " + double_water_temp + " degrees Celsius, the water will be liquid");
        } else {
            Console.WriteLine("At " + double_water_temp + " degrees Celsius, the water will be solid");
        }
    }
}