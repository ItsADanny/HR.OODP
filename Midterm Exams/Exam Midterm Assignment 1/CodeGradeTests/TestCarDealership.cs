// Do not modify this file

static class TestCarDealership
{
    public static void TestAdd()
    {
        CarDealership.AddCar("Toyota", "Camry");
        CarDealership.AddCar("Honda", "Civic");
        CarDealership.AddCar("Nissan", "Altima");
        CarDealership.AddCar("Toyota", "Camry");

        foreach (Car car in CarDealership.CarsForSale)
        {
            Console.WriteLine($"{car.Make} {car.Model} [{(car.LicensePlate ?? "None")}]");
        }
    }

    public static void TestGetIndex()
    {
        CarDealership.AddCar("Toyota", "Camry");
        CarDealership.AddCar("Honda", "Civic");
        CarDealership.AddCar("Nissan", "Altima");
        CarDealership.AddCar("Toyota", "Camry");

        int id;
        for (int i = 0; i < CarDealership.CarsForSale.Count; i++)
        {
            id = i + 1;
            PrintCarData(id);
        }

        PrintCarData(-1);
        PrintCarData(10);
    }

    private static void PrintCarData(int id)
    {
        Console.WriteLine($"ID: {id}");
        int index = CarDealership.GetCarIndexByID(id);
        Console.WriteLine($" - Index: {index}");
        if (index == -1)
        {
            Console.WriteLine(" - Car not found\n");
            return;
        }
        
        Car foundCar = CarDealership.CarsForSale[index];
        Console.WriteLine($" - Car info: {foundCar.Make} {foundCar.Model} [{(foundCar.LicensePlate ?? "None")}]\n");
    }

    public static void TestSell()
    {
        Console.WriteLine($"Amount of cars for sale: {CarDealership.CarsForSale.Count}");
        Console.WriteLine("Adding cars...");

        CarDealership.AddCar("Toyota", "Camry");
        CarDealership.AddCar("Honda", "Civic");
        CarDealership.AddCar("Nissan", "Altima");
        CarDealership.AddCar("Toyota", "Camry");

        Console.WriteLine($"Amount of cars for sale: {CarDealership.CarsForSale.Count}");

        Console.WriteLine("\n=== Start: cars for sale ===");
        PrintCarsLeftForSale();

        Console.WriteLine("=== Selling by ID ===");
        List<int> ids = [3, 0, 1, 1];
        foreach (int id in ids)
        {
            TestSellByID(id);
        }
    }

    private static void TestSellByID(int id)
    {
        Console.WriteLine($"Selling car with ID {id}");
        CarDealership.SellCar(id);
        PrintCarsLeftForSale();
    }

    private static void PrintCarsLeftForSale()
    {
        Console.WriteLine("Cars left:");
        foreach (Car car in CarDealership.CarsForSale)
        {
            Console.WriteLine($" - {car.Make} {car.Model} (ID: {car.ID})");
        }
        Console.WriteLine();
    }
}