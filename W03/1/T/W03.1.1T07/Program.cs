class Program
{
    public static void Main()
    {
        Car car = new Car();
        for (int i = 0; i < 10; i++)
            car.Drive();
        //Solution: Just remove the const in front of the int
        int mileage = car.Mileage;
        // const int mileage = car.Mileage; //ORIGINAL
        Console.WriteLine($"The car's mileage is {mileage}");
    }
}