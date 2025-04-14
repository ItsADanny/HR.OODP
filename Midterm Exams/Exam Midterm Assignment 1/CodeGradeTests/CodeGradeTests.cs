// Do not modify this file

static class CodeGradeTests
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Readonly": TestReadonly(); return;
            case "Constant": TestConstant(); return;
            case "Static": TestStatic(); return;

            case "CarCounter": TestCar.TestCounter(); return;
            case "CarID": TestCar.TestID(); return;
            case "CarLicensePlate": TestCar.TestLicensePlate(); return;
            case "CarInfo": TestCar.TestInfo(); return;

            case "CarDealershipAdd": TestCarDealership.TestAdd(); return;
            case "CarDealershipGetIndex": TestCarDealership.TestGetIndex(); return;
            case "CarDealershipSell": TestCarDealership.TestSell(); return;
            
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestReadonly()
    {
        TestUtils.PrintIsFieldReadOnly(typeof(Car), "Make");
        TestUtils.PrintIsFieldReadOnly(typeof(Car), "Model");
        TestUtils.PrintIsFieldReadOnly(typeof(Car), "ID");
        TestUtils.PrintIsFieldReadOnly(typeof(CarDealership), "CarsForSale");
    }

    public static void TestConstant()
    {
        string fieldName = "LicensePlateRequiredLength";
        TestUtils.PrintIsFieldConstant(typeof(Car), fieldName);
        Console.WriteLine($"{fieldName} value: {Car.LicensePlateRequiredLength}");
    }

    public static void TestStatic()
    {
        TestUtils.PrintIsFieldStatic(typeof(Car), "Counter");
        TestUtils.PrintIsClassStatic(typeof(CarDealership));
    }
}