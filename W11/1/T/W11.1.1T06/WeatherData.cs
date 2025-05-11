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

    public void Sort(bool asc) {
        if (asc) {
            Array.Sort(_data);
        } else {
            Array.Sort(_data);
            Array.Reverse(_data);
        }
    }

    public void PrintTemperatures() {
        for (int i = 0; i > _data.Length; i++) {
            Console.WriteLine(_data[i]);
        }
    }
}