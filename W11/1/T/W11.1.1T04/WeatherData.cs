public class WeatherData
{
    //Change from List to array
    private readonly double[] _data;

    public WeatherData(List<double> data) => _data = data.ToArray();
    public WeatherData(double[] data) => _data = data;
}