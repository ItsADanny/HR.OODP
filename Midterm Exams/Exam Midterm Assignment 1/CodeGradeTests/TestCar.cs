// Do not modify this file

static class TestCar
{
    public static void TestCounter()
    {
        Console.WriteLine($"Counter before creating cars: {Car.Counter}\n");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Creating car...");
            Car someCar = new("Some make", "Some model");
            Console.WriteLine($"Counter: {Car.Counter}\n");
        }
    }

    public static void TestID()
    {
        List<Car> cars = [
            new("Toyota", "Camry"),
            new("Honda", "Civic"),
            new("Nissan", "Altima"),
            new("Toyota", "Camry"),
        ];

        foreach (Car car in cars)
        {
            Console.WriteLine($"Car ID: {car.ID}");
        }
    }

    public static void TestLicensePlate()
    {
        Car car = new("Toyota", "Camry");
        List<string> licensePlates = [
            "12345", "123456", "1234567",
            "ABCDE", "ABCDEF", "ABCDEFG",
            "STARK4", "ECTO1", "COBRAKAI"
        ];

        bool isValid;
        foreach (string licensePlate in licensePlates)
        {
            isValid = car.SetLicensePlate(licensePlate);
            Console.WriteLine($"License plate {licensePlate} is valid: {isValid}");
            Console.WriteLine($"Car's current license plate: " +
                $"{(car.LicensePlate ?? "null")}\n");
        }
    }

    public static void TestInfo()
    {
        List<Car> cars = [
            new("Toyota", "Camry"),
            new("Honda", "Civic"),
            new("Nissan", "Altima"),
        ];

        cars[0].LicensePlate = "123456"; // Bypass the check in SetLicensePlate
        cars[1].LicensePlate = "CNH320";

        foreach (Car car in cars)
        {
            Console.WriteLine(car.GetInfo());
        }
    }
}