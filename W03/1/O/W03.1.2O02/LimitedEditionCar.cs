//We begin by making a class called LimitedEditionCar
class LimitedEditionCar {

    //In this class we want to have 2 variables.

    //One called Model in which we will store our cars model (And constructor).
    // public const string Model = "Jaguar S-Type 2007 3.0 V6 Paladium";       //EXAMPLE
    // public const string Model = "Range Rover Sport SV 2024 4.4 V8 P635";    //EXAMPLE
    public const string Model = "Jeep Compass TrailHawk 4XE 2024";
    //And one called ChassisNumber which will need to be readonly so that nobody can change this number
    //Just like a real ChassisNumber.
    public readonly string ChassisNumber;

    //We will then create a static int called Counter which we will be using to count 
    //how many Car class we have created.
    public static int Counter = 0;

    //In the constructor for our Limited Edition Car we then start by increasing the counter
    //And then Creating a ChassisNumber and assigning it to the ChassisNumber value.
    public LimitedEditionCar() {
        Counter++;
        ChassisNumber = $"CHNO{Counter}";
    }
}