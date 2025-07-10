/*
  This assignment didn't use the Program.cs file
  For this assignment please refer to the following files:

  * Furniture.cs
  * House.cs
  * Van.cs
  * VanCapacity.cs

*/

//===================================================================================================

/*
  This code is show that people can run the assignments with a program that will test the code in the same way as done in the exam
  (See the folder "CodeGrade testing scripts" to see the original code that the program has been tested on)

  This program will test the functionality and return the same point value as the real exam if all the right functionality has been achieved.
*/

using System.Reflection;
using System.Runtime.CompilerServices;

public class Program
{
  public static void Main()
  {
    double score = 0;
    string bar = "===========================================================================================";
    string bar2 = "-------------------------------------------------------------------------------------------";

    Console.Clear();
    Console.WriteLine($"{bar}\nEXAM ASSIGNMENT TESTER - OODP ENDTERM - ASSIGNMENT #4\n\nHighest score possible: 2.0\n{bar}\n\n");
    Console.WriteLine($"Test #1: Enum \"VanCapacity\":\n{bar2}");
    score += LocalTestUtils.TestEnumVanCapacity();
    Console.WriteLine($"\n\nTest #2: Stack type:\n{bar2}");
    score += LocalTestUtils.TestStackType();
    Console.WriteLine($"\n\nTest #3: Stack and Enum: Test Van Constructor:\n{bar2}");
    score += LocalTestUtils.TestStackEnum_ToString();
    Console.WriteLine($"\n\nTest #4: Stack and Enum: Test Van ToString:\n{bar2}");
    score += LocalTestUtils.TestStackEnum_ToString();
    Console.WriteLine($"\n\nTest #5: Stack and Enum: Test Van Load:\n{bar2}");
    score += LocalTestUtils.TestStackEnum_Load();
    Console.WriteLine($"\n\nTest #6: Stack and Enum: Test Van Unload:\n{bar2}");
    score += LocalTestUtils.TestStackEnum_Unload();
    Console.WriteLine($"\n\nTest #7: LINQ: Test House TotalInsuredValue:\n{bar2}");
    score += LocalTestUtils.TestLINQHouse_TotalInsuredValue();
    Console.WriteLine($"\n\nTest #8: LINQ: Test House GetFurnitureAboveValue:\n{bar2}");
    score += LocalTestUtils.TestLINQHouse_GetFurnitureAboveValue();

    if (score < 1.1)
    {
      Console.WriteLine($"{bar}\nFinal result: \x1b[91m{score}\x1b[39m / \x1b[92m2\x1b[39m\n{bar}");
    }
    else if (score < 2)
    {
      Console.WriteLine($"{bar}\nFinal result: \x1b[93m{score}\x1b[39m / \x1b[92m2\x1b[39m\n{bar}");
    }
    else
    {
      Console.WriteLine($"{bar}\nFinal result: \x1b[92m{score}\x1b[39m / \x1b[92m2\x1b[39m\n{bar}");
    }
  }
}

public class LocalTestUtils
{
  private readonly static Random _random = new(0);

  public static double TestEnumVanCapacity() => mTEnumVanCapacity() ? 0.1 : 0;
  public static double TestStackType() => mTStackType() ? 0.05 : 0;
  public static double TestStackEnum_Constructor() => mTStackEnum_Constructor() ? 0.05 : 0;
  public static double TestStackEnum_Load() => mTStackEnum_Load() ? 0.4 : 0;
  public static double TestStackEnum_Unload() => mTStackEnum_Unload() ? 0.3 : 0;
  public static double TestStackEnum_ToString() => mTStackEnum_ToString() ? 0.2 : 0;
  public static double TestLINQHouse_TotalInsuredValue() => mTLINQHouse_TotalInsuredValue() ? 0.3 : 0;
  public static double TestLINQHouse_GetFurnitureAboveValue() => mTLINQHouse_GetFurnitureAboveValue() ? 0.6 : 0;

  private static bool mTEnumVanCapacity()
  {
    List<string> checkValues = [
      "Small = 15",
      "Medium = 20",
      "Large = 30"
    ];

    int implement = 0;
    int pos = 0;
    string values = "";
    foreach (VanCapacity vanCapacity in Enum.GetValues<VanCapacity>())
    {
      string value = $"{vanCapacity} = {(int)vanCapacity}";
      if (checkValues.Contains(value))
      {
        implement++;
      }

      if (values != "")
      {
        values += "\n";
      }
      values += value;

      pos++;
    }

    if (implement == 3 && pos == 3)
    {
      Console.WriteLine("\x1b[92mEnum \"VanCapacity\" have been implemented correctly\x1b[39m");
      return true;
    }
    else
    {
      Console.WriteLine($"\x1b[91mEnum \"VanCapacity\" did match expected result\nExpected:\nSmall = 15\nMedium = 20\nLarge = 30\n\nActual:\n{values}\x1b[39m");
      return false;
    }
  }
  private static bool mTStackType()
  {
    var field = typeof(Van).GetProperty("Contents",
      BindingFlags.Public | BindingFlags.NonPublic |
      BindingFlags.Instance | BindingFlags.Static);

    if (field == null)
    {
      PrintPropertyNotFoundInClass(typeof(Van), "Contents");
      return false;
    }

    Type fieldType = field.PropertyType;
    string result = $"Property: {"Contents"}, Type: {GetFriendlyTypeName(fieldType)}";
    string expected = "Property: Contents, Type: Stack<Furniture>";

    bool final = result == expected;

    if (final)
    {
      Console.WriteLine("\x1b[92mEnum \"Stack<Furniture> (Van)\" has been implemented correctly\x1b[39m");
    }
    else
    {
      Console.WriteLine($"\x1b[91mEnum \"Stack<Furniture> (Van)\" has not been implemented correctly\nExpected:\n{expected}\n\nActual:\n{result}\x1b[39m");
    }

    return final;
  }
  private static bool mTStackEnum_Constructor()
  {
    //Try creating a new Van object with a small van Capacity
    Van van = new(VanCapacity.Small);

    //See if all values have been initialized correclty
    bool t1_result = van.Capacity == VanCapacity.Small;
    bool t2_result = van.Contents.Count == 0;
    bool t3_result = van.UsedVolume == 0;

    bool final = t1_result & t2_result & t3_result;

    if (final)
    {
      Console.WriteLine("\x1b[92mEnum \"Constructor (Van)\" has been implemented correctly\x1b[39m");
    }
    else
    {
      Console.WriteLine($"\x1b[91mEnum \"Constructor (Van)\" has not been implemented correctly\nExpected:\nvan.Capacity == VanCapacity.Small: True\nvan.Contents.Count == 0: True\nvan.UsedVolume == 0: True\n\nActual:\nvan.Capacity == VanCapacity.Small: {t1_result}\nvan.Contents.Count == 0: {t2_result}\nvan.UsedVolume == 0: {t2_result}\x1b[39m");
    }

    return final;
  }
  private static bool mTStackEnum_Load()
  {
    var saved = Console.Out;

    string result;
    string expected = "Testing Loading\nTesting van with capacity: 15\nAttempting to load TV with volume 5. Successful? True\nCapacity: 15\nUsed: 5Contents: TV\nAttempting to load Sofa with volume 4. Successful? True\nCapacity: 15\nUsed: 9\nContents: Sofa TV\nAttempting to load Fridge with volume 2. Successful? True\nCapacity: 15\nUsed: 11\nContents: Fridge Sofa TV\nAttempting to load Computer with volume 3. Successful? True\nCapacity: 15\n" +
                      "Used: 14\nContents: Computer Fridge Sofa TV\nAttempting to load Lamp with volume 6. Successful? False\nAttempting to load Lamp with volume 6. Successful? False\nAttempting to load Computer with volume 4. Successful? False\nAttempting to load Desk with volume 1. Successful? True\nCapacity: 15\nUsed: 15\nContents: Desk Computer Fridge Sofa TV\nAttempting to load Sofa with volume 6. Successful? False\nAttempting to load Chair with volume 3. Successful? False\n\n" +
                      "Testing van with capacity: 20\nAttempting to load Desk with volume 5. Successful? True\nCapacity: 20\nUsed: 5\nContents: Desk\nAttempting to load Fridge with volume 5. Successful? True\nCapacity: 20\nUsed: 10\nContents: Fridge Desk\nAttempting to load Table with volume 2. Successful? True\nCapacity: 20\nUsed: 12\nContents: Table Fridge Desk\nAttempting to load Computer with volume 3. Successful? True\nCapacity: 20\n" +
                      "Used: 15\nContents: Computer Table Fridge Desk\nAttempting to load Lamp with volume 5. Successful? True\nCapacity: 20\nUsed: 20\nContents: Lamp Computer Table Fridge Desk\nAttempting to load Computer with volume 2. Successful? False\nAttempting to load Chair with volume 6. Successful? False\nAttempting to load Lamp with volume 2. Successful? False\nAttempting to load Computer with volume 5. Successful? False\n\n" +
                      "Testing van with capacity: 30\nAttempting to load TV with volume 5. Successful? True\nCapacity: 30\nUsed: 5\nContents: TV\nAttempting to load Table with volume 3. Successful? True\nCapacity: 30\nUsed: 8\nContents: Table TV\nAttempting to load Computer with volume 3. Successful? True\nCapacity: 30\nUsed: 11\nContents: Computer Table TV\nAttempting to load TV with volume 5. Successful? True\nCapacity: 30\nUsed: 16\n" +
                      "Contents: TV Computer Table TV\nAttempting to load Desk with volume 4. Successful? True\nCapacity: 30\nUsed: 20\nContents: Desk TV Computer Table TV\nAttempting to load Lamp with volume 2. Successful? True\nCapacity: 30\nUsed: 22\nContents: Lamp Desk TV Computer Table TV\nAttempting to load Computer with volume 5. Successful? True\nCapacity: 30\nUsed: 27\nContents: Computer Lamp Desk TV Computer Table TV\nAttempting to load Sofa with volume 6. Successful? False";

    using (StringWriter stringWriter = new StringWriter())
    {
      Console.SetOut(stringWriter);

      //Same code as used by CodeGrade to generate the console output which will be checked
      int furnitureCount = 10;
      foreach (VanCapacity capacity in Enum.GetValues<VanCapacity>())
      {
        Van van = new(capacity);
        Console.WriteLine("Testing van with capacity: {0:D}", capacity);

        var furniture = GenerateFurnitureList(furnitureCount--);
        foreach (var item in furniture)
        {
          bool itemLoaded = van.Load(item);
          Console.WriteLine($"Attempting to load {item.Name} with volume {item.Volume}. Successful? {itemLoaded}");
          if (itemLoaded)
          {
            Console.WriteLine(van);
          }
        }
        Console.WriteLine();
      }
      Console.WriteLine();

      Console.SetOut(saved);
      result = stringWriter.ToString();
    }

    bool final = result.Replace(Environment.NewLine, "") == expected.Replace("\n", "");

    if (final) {
      Console.WriteLine("\x1b[92mEnum \"Load (Van)\" has been implemented correctly\x1b[39m");
    } else {
      Console.WriteLine($"\x1b[91mEnum \"Load (Van)\" has not been implemented correctly\nExpected:\n{expected}\n\nActual:\n{result}\x1b[39m");
    }

    return final;
  }
  private static bool mTStackEnum_Unload()
  {
    var saved = Console.Out;

    string result;
    string expected = "Testing with 2 items of furniture\n------------------------------------\nLoaded Van details:\nCapacity: 30\nUsed: 9\nContents: Sofa TV\n\nUnloaded furniture: Sofa TV\n\nVan details after unloading:\nCapacity: 30\nUsed: 0\nContents: \n\nTesting with 5 items of furniture\n------------------------------------\nLoaded Van details:\nCapacity: 30\nUsed: 21\nContents: Computer Lamp Lamp Computer Fridge\n\nUnloaded furniture: Computer Lamp Lamp Computer Fridge\n\nVan details after unloading:\nCapacity: 30\nUsed: 0\nContents: \n\n" +
                      "Testing with 8 items of furniture\n------------------------------------\nLoaded Van details:\nCapacity: 30\nUsed: 30\nContents: Lamp Computer Table Fridge Desk Chair Sofa Desk\n\nUnloaded furniture: Lamp Computer Table Fridge Desk Chair Sofa Desk\n\nVan details after unloading:\nCapacity: 30\nUsed: 0\nContents: ";

    using (StringWriter stringWriter = new StringWriter())
    {
      Console.SetOut(stringWriter);

      //Same code as used by CodeGrade to generate the console output which will be checked
      for (int i = 2; i <= 8; i += 3)
      {
        Console.WriteLine($"Testing with {i} items of furniture");
        Console.WriteLine($"------------------------------------");

        Van van = new(VanCapacity.Large);

        var furniture = GenerateFurnitureList(i);
        foreach (var item in furniture)
        {
          van.Load(item);
        }

        Console.WriteLine("Loaded Van details:");
        Console.WriteLine(van);

        List<Furniture> unloadedFurniture = van.Unload();

        string unloadedFurnitureNames = string.Join(" ", unloadedFurniture.Select(f => f.Name));
        Console.WriteLine($"\nUnloaded furniture: {unloadedFurnitureNames}");

        Console.WriteLine("\nVan details after unloading:");
        Console.WriteLine(van);
        Console.WriteLine();
      }
      Console.WriteLine();

      Console.SetOut(saved);
      result = stringWriter.ToString();
    }

    bool final = result.Replace(Environment.NewLine, "") == expected.Replace("\n", "");

    if (final) {
      Console.WriteLine("\x1b[92mEnum \"Unload (Van)\" has been implemented correctly\x1b[39m");
    } else {
      Console.WriteLine($"\x1b[91mEnum \"Unload (Van)\" has not been implemented correctly\nExpected:\n{expected}\n\nActual:\n{result}\x1b[39m");
    }

    return final;
  }
  private static bool mTStackEnum_ToString()
  {
    var saved = Console.Out;

    string result;
    string expected = "Testing ToString on initialization\nCapacity: 30\nUsed: 0\nContents:\n\nTesting ToString after loading\nCapacity: 30\nUsed: 20\nContents: Lamp Computer Fridge Sofa TV";

    using (StringWriter stringWriter = new StringWriter())
    {
      Console.SetOut(stringWriter);

      //Same code as used by CodeGrade to generate the console output which will be checked
      Van van = new(VanCapacity.Large);
      Console.WriteLine("Testing ToString on initialization");
      Console.WriteLine(van);
      Console.WriteLine();

      var furniture = GenerateFurnitureList(5);
      foreach (var item in furniture)
      {
        van.Load(item);
      }
      Console.WriteLine("Testing ToString after loading");
      Console.WriteLine(van);
      Console.WriteLine();

      Console.SetOut(saved);
      result = stringWriter.ToString();
    }

    bool final = result.Replace(Environment.NewLine, "") == expected.Replace("\n", "");

    if (final) {
      Console.WriteLine("\x1b[92mEnum \"ToString() (Van)\" has been implemented correctly\x1b[39m");
    } else {
      Console.WriteLine($"\x1b[91mEnum \"ToString() (Van)\" has not been implemented correctly\nExpected:\n{expected}\n\nActual:\n{result}\x1b[39m");
    }

    return final;
  }
  private static bool mTLINQHouse_TotalInsuredValue()
  {
    var saved = Console.Out;

    string result;
    string expected = "Testing TotalInsuredValue\nTotal cost of insured furniture items: 1277\nAll furniture at 3, Fake street:\nTV       - Volume: 5 m3, Value: 791 Euro, Insured: False\nSofa     - Volume: 4 m3, Value: 915 Euro, Insured: True\nFridge   - Volume: 2 m3, Value: 362 Euro, Insured: True\n\nTotal cost of insured furniture items: 3159\nAll furniture at 8, Fake street:\nComputer - Volume: 3 m3, Value: 983 Euro, Insured: True\nLamp     - Volume: 6 m3, Value: 709 Euro, Insured: True\nLamp     - Volume: 6 m3, Value: 992 Euro, Insured: True\nComputer - Volume: 4 m3, Value: 940 Euro, Insured: False\n" +
                      "Desk     - Volume: 1 m3, Value: 268 Euro, Insured: True\nSofa     - Volume: 6 m3, Value: 678 Euro, Insured: False\nChair    - Volume: 3 m3, Value: 408 Euro, Insured: False\nDesk     - Volume: 5 m3, Value: 207 Euro, Insured: True\n\nTotal cost of insured furniture items: 4158\nAll furniture at 13, Fake street:\nFridge   - Volume: 5 m3, Value: 403 Euro, Insured: True\nTable    - Volume: 2 m3, Value: 469 Euro, Insured: False\nComputer - Volume: 3 m3, Value: 275 Euro, Insured: False\nLamp     - Volume: 5 m3, Value: 872 Euro, Insured: False\nComputer - Volume: 2 m3, Value: 905 Euro, Insured: False\n" +
                      "Chair    - Volume: 6 m3, Value: 253 Euro, Insured: False\nLamp     - Volume: 2 m3, Value: 999 Euro, Insured: True\nComputer - Volume: 5 m3, Value: 828 Euro, Insured: True\nTV       - Volume: 5 m3, Value: 212 Euro, Insured: False\nTable    - Volume: 3 m3, Value: 586 Euro, Insured: True\nComputer - Volume: 3 m3, Value: 850 Euro, Insured: False\nTV       - Volume: 5 m3, Value: 943 Euro, Insured: True\nDesk     - Volume: 4 m3, Value: 399 Euro, Insured: True";

    using (StringWriter stringWriter = new StringWriter())
    {
      Console.SetOut(stringWriter);

      mPrintLINQHouse_TotalInsuredValue();

      Console.SetOut(saved);
      result = stringWriter.ToString();
    }

    bool final = result.Replace(Environment.NewLine, "") == expected.Replace("\n", "");

    if (final) {
      Console.WriteLine("\x1b[92mEnum \"TotalInsuredValue() (LINQ) (House)\" has been implemented correctly\x1b[39m");
    } else {
      Console.WriteLine($"\x1b[91mEnum \"TotalInsuredValue() (LINQ) (House)\" has not been implemented correctly\nExpected:\n{expected}\n\nActual:\n{result}\x1b[39m");
    }

    return final;
  }

  private static bool mTLINQHouse_GetFurnitureAboveValue()
  {
    var saved = Console.Out;

    string result;
    string expected = "Testing GetFurnitureAboveValue\nItems above 250 at 5, Fake street:\nTV       - Volume: 5 m3, Value: 791 Euro, Insured: False\nFridge   - Volume: 2 m3, Value: 362 Euro, Insured: True\nLamp     - Volume: 6 m3, Value: 709 Euro, Insured: True\nSofa     - Volume: 4 m3, Value: 915 Euro, Insured: True\nComputer - Volume: 3 m3, Value: 983 Euro, Insured: True\n\nAll furniture at 5, Fake street:\nTV       - Volume: 5 m3, Value: 791 Euro, Insured: False\nSofa     - Volume: 4 m3, Value: 915 Euro, Insured: True\nFridge   - Volume: 2 m3, Value: 362 Euro, Insured: True\nComputer - Volume: 3 m3, Value: 983 Euro, Insured: True\nLamp     - Volume: 6 m3, Value: 709 Euro, Insured: True\nCupboard - Volume: 9 m3, Value: 250 Euro, Insured: True\n" +
                      "----------------------------------------------------------\nItems above 500 at 10, Fake street:\nSofa     - Volume: 6 m3, Value: 678 Euro, Insured: False\nLamp     - Volume: 5 m3, Value: 872 Euro, Insured: False\nComputer - Volume: 4 m3, Value: 940 Euro, Insured: False\nLamp     - Volume: 6 m3, Value: 992 Euro, Insured: True\n\nAll furniture at 10, Fake street:\n" +
                      "Lamp     - Volume: 6 m3, Value: 992 Euro, Insured: True\nComputer - Volume: 4 m3, Value: 940 Euro, Insured: False\nDesk     - Volume: 1 m3, Value: 268 Euro, Insured: True\nSofa     - Volume: 6 m3, Value: 678 Euro, Insured: False\nChair    - Volume: 3 m3, Value: 408 Euro, Insured: False\nDesk     - Volume: 5 m3, Value: 207 Euro, Insured: True\nFridge   - Volume: 5 m3, Value: 403 Euro, Insured: True\n" +
                      "Table    - Volume: 2 m3, Value: 469 Euro, Insured: False\nComputer - Volume: 3 m3, Value: 275 Euro, Insured: False\nLamp     - Volume: 5 m3, Value: 872 Euro, Insured: False\nCupboard - Volume: 9 m3, Value: 500 Euro, Insured: True\n----------------------------------------------------------\nItems above 750 at 15, Fake street:\nComputer - Volume: 3 m3, Value: 850 Euro, Insured: False\nComputer - Volume: 2 m3, Value: 905 Euro, Insured: False\nComputer - Volume: 5 m3, Value: 828 Euro, Insured: True\nTV       - Volume: 5 m3, Value: 943 Euro, Insured: True\nLamp     - Volume: 2 m3, Value: 999 Euro, Insured: True\n\n" +
                      "All furniture at 15, Fake street:\nComputer - Volume: 2 m3, Value: 905 Euro, Insured: False\nChair    - Volume: 6 m3, Value: 253 Euro, Insured: False\nLamp     - Volume: 2 m3, Value: 999 Euro, Insured: True\nComputer - Volume: 5 m3, Value: 828 Euro, Insured: True\nTV       - Volume: 5 m3, Value: 212 Euro, Insured: False\nTable    - Volume: 3 m3, Value: 586 Euro, Insured: True\nComputer - Volume: 3 m3, Value: 850 Euro, Insured: False\nTV       - Volume: 5 m3, Value: 943 Euro, Insured: True\nDesk     - Volume: 4 m3, Value: 399 Euro, Insured: True\nLamp     - Volume: 2 m3, Value: 268 Euro, Insured: True\n" +
                      "Computer - Volume: 5 m3, Value: 667 Euro, Insured: False\nSofa     - Volume: 6 m3, Value: 159 Euro, Insured: False\nComputer - Volume: 1 m3, Value: 234 Euro, Insured: True\nComputer - Volume: 6 m3, Value: 541 Euro, Insured: True\nComputer - Volume: 4 m3, Value: 302 Euro, Insured: False\nCupboard - Volume: 9 m3, Value: 750 Euro, Insured: True\n----------------------------------------------------------";

    using (StringWriter stringWriter = new StringWriter())
    {
      Console.SetOut(stringWriter);

      mPrintLINQHouse_GetFurnitureAboveValue();

      Console.SetOut(saved);
      result = stringWriter.ToString();
    }

    bool final = result.Replace(Environment.NewLine, "") == expected.Replace("\n", "");

    if (final) {
      Console.WriteLine("\x1b[92mEnum \"TotalInsuredValue() (LINQ) (House)\" has been implemented correctly\x1b[39m");
    } else {
      Console.WriteLine($"\x1b[91mEnum \"TotalInsuredValue() (LINQ) (House)\" has not been implemented correctly\nExpected:\n{expected}\n\nActual:\n{result}\x1b[39m");
    }

    return final;
  }

  private static void mPrintLINQHouse_TotalInsuredValue()
  { 
    Console.WriteLine("Testing TotalInsuredValue");
        for (int i = 3; i <= 13; i += 5)
        {
            var furniture = GenerateFurnitureList(i);
            House home = new(i + ", Fake street", furniture);
            Console.WriteLine($"Total cost of insured furniture items: {home.TotalInsuredValue()}");
            Console.WriteLine($"All furniture at {home.Address}: ");
            Console.WriteLine(string.Join("\n", home.FurnitureList));
            Console.WriteLine();
        }
  }

  private static void mPrintLINQHouse_GetFurnitureAboveValue()
  {
    Console.WriteLine("Testing GetFurnitureAboveValue");
    for (int i = 5; i <= 15; i += 5)
    {
      var furniture = GenerateFurnitureList(i);
      furniture.Add(new Furniture("Cupboard", 9, i * 50, true));
      House home = new(i + ", Fake street", furniture);
      Console.WriteLine($"Items above {i * 50} at {home.Address}:");
      Console.WriteLine($"{string.Join("\n", home.GetFurnitureAboveValue(i * 50))}");

      Console.WriteLine($"\nAll furniture at {home.Address}: ");
      Console.WriteLine(string.Join("\n", home.FurnitureList));
      Console.WriteLine("----------------------------------------------------------");
    }
  }

  private static string GetFriendlyTypeName(Type type, object? provider = null)
  {
    // Check if it's a tuple type (ValueTuple)
    if (type.FullName?.StartsWith("System.ValueTuple") == true)
    {
      // Extract TupleElementNamesAttribute from the provider (MethodInfo, ParameterInfo, etc.)
      TupleElementNamesAttribute? tupleNamesAttr = provider switch
      {
        MemberInfo memberInfo => memberInfo.GetCustomAttributes(typeof(TupleElementNamesAttribute), false)
                                           .OfType<TupleElementNamesAttribute>()
                                           .FirstOrDefault(),
        ParameterInfo paramInfo => paramInfo.GetCustomAttributes(typeof(TupleElementNamesAttribute), false)
                                            .OfType<TupleElementNamesAttribute>()
                                            .FirstOrDefault(),
        _ => null
      };

      var genericArgs = type.GetGenericArguments();
      var names = tupleNamesAttr?.TransformNames ?? [.. Enumerable.Repeat<string?>(null, genericArgs.Length)];

      var friendlyElements = genericArgs.Select((t, i) =>
      {
        var elementName = names != null && i < names.Count ? names[i] : null;
        return elementName != null ? $"{GetFriendlyTypeName(t)} {elementName}" : GetFriendlyTypeName(t);
      });

      return $"({string.Join(", ", friendlyElements)})";
    }

    // Existing type cases
    if (type == typeof(string)) return "string";
    if (type == typeof(int)) return "int";
    if (type == typeof(bool)) return "bool";
    if (type == typeof(double)) return "double";
    if (type == typeof(float)) return "float";
    if (type == typeof(decimal)) return "decimal";
    if (type == typeof(object)) return "object";
    if (type == typeof(void)) return "void";

    if (type.IsArray)
      return $"{GetFriendlyTypeName(type.GetElementType()!)}{new string('[', type.GetArrayRank())}{new string(']', type.GetArrayRank())}";

    if (type.IsGenericTypeDefinition)
      return $"{type.Name.Split('`')[0]}<>";

    if (type.IsGenericType)
      return $"{type.Name.Split('`')[0]}<{string.Join(", ", type.GetGenericArguments().Select(t => GetFriendlyTypeName(t)))}>";

    return type.FullName ?? type.Name;
  }
  private static void PrintFieldNotFoundInClass(Type clsType, string fieldName) => Console.WriteLine($"\x1b[91m(Class {clsType.Name}) field {fieldName} not found. (Are you sure it is a field and not a property?)\x1b[39m");
  private static void PrintPropertyNotFoundInClass(Type clsType, string propertyName) => Console.WriteLine($"\x1b[91m(Class {clsType.Name}) property {propertyName} not found. (Are you sure it is a property and not a field?)\x1b[39m");
  private static List<Furniture> GenerateFurnitureList(int count)
    {
        string[] names = ["Chair", "Table", "Sofa", "Bed", "Cabinet", "Desk", "Computer", "TV", "Lamp", "Fridge" ];

        List<Furniture> furnitureList = [];
        for (int i = 0; i < count; i++)
        {
            string name = names[_random.Next(names.Length)];
            int volume = _random.Next(1, 7); // Random volume between 1 and 30 cubic meters
            int value = _random.Next(100, 1000); // Random value between 50 and 1000 euros
            bool isInsured = _random.Next(2) == 0; // Randomly true or false

            furnitureList.Add(new Furniture(name, volume, value, isInsured));
        }

        return furnitureList;
    }
}