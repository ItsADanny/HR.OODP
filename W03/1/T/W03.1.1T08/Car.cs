class Car
{
    //Solution: Just add = 4 to the back of the variable NumberOfWheels
    //          This will then make it so that the variable NumberOfWheels
    //          Always starts with 4 wheels (Which is required because a
    //          Const always needs to be predefined)
    public const int NumberOfWheels = 4;
    public string Color;

    public Car(string color)
    {
        //And remove this line from the Constructor
        // NumberOfWheels = 4;
        Color = color;
    }

    public void ChangePaintColor(string color) => Color = color;

    public string GetInfo() =>
        $"My color is currently {Color}, although that may change. But I will always have {NumberOfWheels} wheels.";
}