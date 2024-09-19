class LimitedEditionCar {

    public const string model = "Jaguar S-Type 2007 3.0 V6 Paladium";
    public readonly string ChassisNumber;

    //Counter to keep track of how many cars have been produced
    public static int Counter = 0;


    public LimitedEditionCar() {
        ChassisNumber = $"CHNO{Counter}";
        Counter++;
    }
}