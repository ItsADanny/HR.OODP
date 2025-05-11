public class WeatherData
{
    //Change from List to array
    private readonly double[] _data;
    public int NumberOfReadings {
        get {
            return _data.Length;
        }
    }

    public WeatherData(List<double> data) => _data = data.ToArray();
    public WeatherData(double[] data) => _data = data;
    public double GetHighestTemperature() {
        double highestTemp = 0.0;
        foreach (double temp in _data) {
            if (temp > highestTemp) {
                highestTemp = temp;
            }
        }
        return highestTemp;
    }
}