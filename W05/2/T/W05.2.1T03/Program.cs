public class Program
{
    public static void Main()
    {
        Temperature temperature = new()
        {
            Celsius = 100
        };
        PrintTemperature(temperature);

        temperature.Kelvin = 100;
        PrintTemperature(temperature);

        temperature.Celsius = -274;
        PrintTemperature(temperature);

        temperature.Kelvin = -1;
        PrintTemperature(temperature);

        temperature.Celsius = -273.15;
        PrintTemperature(temperature);
    }

    private static void PrintTemperature(Temperature temperature)
    {
        Console.WriteLine("Temperature in Celsius: " + (int)temperature.Celsius);
        Console.WriteLine("Temperature in Kelvin: " + (int)temperature.Kelvin);
        Console.WriteLine();
    }
}