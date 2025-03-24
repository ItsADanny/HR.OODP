using System.Reflection;

static class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Constant": TestConstFields(); return;
            case "Functionality": TestFunctionality(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }
    
    public static void TestConstFields()
    {
        Type clsType = typeof(Car);
        PrintIsFieldConstant(clsType, "NumberOfWheels");
    }
    
    private static void PrintIsFieldConstant(Type clsType, string fieldName)
    {
        FieldInfo? info = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (info is null)
        {
            Console.WriteLine($"Field {fieldName} not found in {clsType.Name}");
            return;
        }

        Console.WriteLine($"{info.Name} is a constant field: " +
            info.IsLiteral);
    }
    
    public static void TestFunctionality()
    {
        Car car = new("Yellow");
        Console.WriteLine(car.GetInfo());
        
        car.ChangePaintColor("Blue");
        Console.WriteLine(car.GetInfo());
    }
}