static class Program {
    static void main() {
        Car car1 = new("Tractor", "John Deer");
        Car car2 = new("McLaren", "F1");
        List<Car> cars = [car1, car2];

        foreach (Car car in cars) {
            car.Drive();
            if (car is GasCar) {
                //Deze staat uit omdat we 
                // Console.WriteLine(GasCar.GasLeft;)
            }
        }
    }
}