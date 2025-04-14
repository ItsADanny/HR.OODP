public static class CarDealership {
    public static readonly List<Car> CarsForSale = [];

    public static void AddCar(string make, string model) => CarsForSale.Add(new Car(make, model));

    public static int GetCarIndexByID(int id) {
        int pos = 0;

        foreach (Car car in CarsForSale) {
            if (car.ID == id) {
                return pos;
            }
            pos++;
        }

        return -1;
    }

    public static void SellCar(int carID) {
        bool CarFound = false;

        foreach (Car car in CarsForSale) {
            if (car.ID == carID) {
                CarFound = true;
                CarsForSale.Remove(car);
                return;
            }
        }

        if (!CarFound) {
            Console.WriteLine("ID not found");
        }
    }
}