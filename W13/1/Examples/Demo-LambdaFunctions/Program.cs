static class Program {
    static void Main() {
        List<Car> cars = [
            new Car("Mazda", "Red"), new Car("Mazda", "Blue"),
            new Car("Kia", "Blue"), new Car("Kia", "Green"), new Car("Kia", "Green"),
            new Car("Jaguar", "Black"), new Car("Jaguar", "Pink"), new Car("Jaguar", "Rainbow"),
            new Car("Toyota", "Red"), new Car("Toyota", "Green"),
            new Car("Volvo", "Black"), new Car("Volvo", "White"), new Car("Volvo", "White"),
            new Car("Mercedes", "Gray"), new Car("", "Blue")
        ];

        List<Car> filteredAndOrdered = cars
            .Where(car => car.Brand == "Jaguar")
            .OrderBy(car => car.Color).ToList();

        filteredAndOrdered.ForEach(car => Console.WriteLine(car));
    }
}