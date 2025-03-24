using System;
using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        switch (args[1])
        {
            case "FUNCTIONALITY": TestFunctionality(); return;
            case "ENCAPSULATION":
                {
                    TestPropertyAccessibility(new Car(), "Description");
                    return;
                }
            default: throw new ArgumentException();
        }
    }

    public static void TestFunctionality()
    { 
        Console.WriteLine("Creating someCar with default property values");
        Car someCar = new();
        Console.WriteLine("The Description of someCar is:");
        Console.WriteLine(someCar.Description);

        Car recentCar = new()
        {
            Make = "Tesla",
            Model = "Model S",
            Year = 2022
        };

        Console.WriteLine("\nCreating recentCar");

        Console.WriteLine("Property Make was set to: " + recentCar.Make);
        Console.WriteLine("Property Model was set to: " + recentCar.Model);
        Console.WriteLine("Property Year was set to: " + recentCar.Year);
        Console.WriteLine("Property Description of recentCar is:");
        Console.WriteLine(recentCar.Description);
    }

    public static void TestPropertyAccessibility(object obj, string propertyName)
    {
        Type type = obj.GetType();
        PropertyInfo property = type.GetProperty(propertyName);

        if (property == null)
        {
            Console.WriteLine($"Property {propertyName} not found on type {type.Name}.");
            return;
        }

        if (property.CanRead)
        {
            Console.WriteLine($"Property {propertyName} is readable.");
            MethodInfo getMethod = property.GetMethod;
            Console.WriteLine(" - Get method is " +
                (getMethod.IsPublic ? "public" :
                 getMethod.IsPrivate ? "private" :
                 getMethod.IsFamily ? "protected" :
                 "internal"));
        }
        else
        {
            Console.WriteLine($"Property {propertyName} is not readable.");
        }

        if (property.CanWrite)
        {
            Console.WriteLine($"Property {propertyName} is writable.");
            MethodInfo setMethod = property.SetMethod;
            Console.WriteLine(" - Set method is " +
                (setMethod.IsPublic ? "public" :
                 setMethod.IsPrivate ? "private" :
                 setMethod.IsFamily ? "protected" :
                 "internal"));
        }
        else
        {
            Console.WriteLine($"Property {propertyName} is not writable.");
        }
    }
}