class Program {

    const int spdOfLightInMperS = 299792458;
    const double daysInYear = 365.242199;
    const string planetName = "LP 890-9b";
    const double distanceFromEarthInLightYear = 100;

    static void Main() {
        Console.WriteLine($"The planet {planetName} is {distanceFromEarthInLightYear} lightyears away from Earth\nIn meters this is {distanceFromEarthInLightYear * (spdOfLightInMperS * daysInYear)}");
    }
}