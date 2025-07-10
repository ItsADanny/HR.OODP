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
    score += LocalTestUtils.TestStackEnum_Constructor();
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
    string expected;
    int furnitureCount = 10;
    var furniture = GenerateFurnitureList(furnitureCount--);

    //Get the results for the expecting comparison
    using (StringWriter stringWriter = new StringWriter())
    {
      Console.SetOut(stringWriter);

      //Same code as used by CodeGrade to generate the console output which will be checked

      foreach (ExpectedVanCapacity capacity in Enum.GetValues<ExpectedVanCapacity>())
      {
        ExpectedVan expectedVan = new(capacity);
        Console.WriteLine("Testing van with capacity: {0:D}", capacity);

        foreach (var item in furniture)
        {
          bool itemLoaded = expectedVan.Load(item);
          Console.WriteLine($"Attempting to load {item.Name} with volume {item.Volume}. Successful? {itemLoaded}");
          if (itemLoaded)
          {
            Console.WriteLine(expectedVan);
          }
        }
        Console.WriteLine();
      }
      Console.WriteLine();

      Console.SetOut(saved);
      expected = stringWriter.ToString();
    }

    //Get the results from the tester made code
    using (StringWriter stringWriter = new StringWriter())
    {
      Console.SetOut(stringWriter);

      //Same code as used by CodeGrade to generate the console output which will be checked
      foreach (VanCapacity capacity in Enum.GetValues<VanCapacity>())
      {
        Van van = new(capacity);
        Console.WriteLine("Testing van with capacity: {0:D}", capacity);

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

    bool final = result == expected;

    if (final)
    {
      Console.WriteLine("\x1b[92mEnum \"Load (Van)\" has been implemented correctly\x1b[39m");
    }
    else
    {
      Console.WriteLine($"\x1b[91mEnum \"Load (Van)\" has not been implemented correctly\nExpected:\n{expected}\n\nActual:\n{result}\x1b[39m");
    }

    return final;
  }
  private static bool mTStackEnum_Unload()
  {
    var saved = Console.Out;

    string result;
    string expected;
    StringWriter resultWriter = new StringWriter();
    StringWriter expectedWriter = new StringWriter();

    for (int i = 2; i <= 8; i += 3)
    {
      Console.SetOut(resultWriter);
      Console.WriteLine($"Testing with {i} items of furniture");
      Console.WriteLine($"------------------------------------");

      Console.SetOut(expectedWriter);
      Console.WriteLine($"Testing with {i} items of furniture");
      Console.WriteLine($"------------------------------------");

      Van van = new(VanCapacity.Large);
      ExpectedVan expectedVan = new(ExpectedVanCapacity.Large);

      var furniture = GenerateFurnitureList(i);
      foreach (var item in furniture)
      {
        van.Load(item);
        expectedVan.Load(item);
      }

      Console.SetOut(resultWriter);
      Console.WriteLine("Loaded Van details:");
      Console.WriteLine(van);

      Console.SetOut(expectedWriter);
      Console.WriteLine("Loaded Van details:");
      Console.WriteLine(expectedVan);

      List<Furniture> unloadedFurniture = van.Unload();
      List<Furniture> expectedUnloadedFurniture = expectedVan.Unload();

      string unloadedFurnitureNames = string.Join(" ", unloadedFurniture.Select(f => f.Name));
      string expectedUnloadedFurnitureNames = string.Join(" ", unloadedFurniture.Select(f => f.Name));

      Console.SetOut(resultWriter);
      Console.WriteLine($"\nUnloaded furniture: {unloadedFurnitureNames}");

      Console.WriteLine("\nVan details after unloading:");
      Console.WriteLine(van);
      Console.WriteLine();

      Console.SetOut(expectedWriter);
      Console.WriteLine($"\nUnloaded furniture: {unloadedFurnitureNames}");

      Console.WriteLine("\nVan details after unloading:");
      Console.WriteLine(van);
      Console.WriteLine();
    }
    Console.SetOut(resultWriter);
    Console.WriteLine();
    Console.SetOut(expectedWriter);
    Console.WriteLine();

    Console.SetOut(saved);
    result = resultWriter.ToString();
    expected = expectedWriter.ToString();
    
    bool final = result == expected;

    if (final)
    {
      Console.WriteLine("\x1b[92mEnum \"Unload (Van)\" has been implemented correctly\x1b[39m");
    }
    else
    {
      Console.WriteLine($"\x1b[91mEnum \"Unload (Van)\" has not been implemented correctly\nExpected:\n{expected}\n\nActual:\n{result}\x1b[39m");
    }

    return final;
  }
  private static bool mTStackEnum_ToString()
  {
    var saved = Console.Out;

    string result;
    string expected = "Testing ToString on initialization\nCapacity: 30\nUsed: 0\nContents: \n\nTesting ToString after loading\nCapacity: 30\nUsed: 20\nContents: Lamp Computer Fridge Sofa TV";

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

    if (final)
    {
      Console.WriteLine("\x1b[92mEnum \"ToString() (Van)\" has been implemented correctly\x1b[39m");
    }
    else
    {
      Console.WriteLine($"\x1b[91mEnum \"ToString() (Van)\" has not been implemented correctly\nExpected:\n{expected}\n\nActual:\n{result}\x1b[39m");
    }

    return final;
  }
  private static bool mTLINQHouse_TotalInsuredValue()
  {
    var saved = Console.Out;

    string result = "";
    string expected = "";
    StringWriter resultStringWriter = new StringWriter();
    StringWriter expectedStringWriter = new StringWriter();

    Console.SetOut(resultStringWriter);
    Console.WriteLine("Testing TotalInsuredValue");
    Console.SetOut(expectedStringWriter);
    Console.WriteLine("Testing TotalInsuredValue");

    for (int i = 3; i <= 13; i += 5)
    {
      var furniture = GenerateFurnitureList(i);

      Console.SetOut(resultStringWriter);
      mPrintLINQHouse_TotalInsuredValue(furniture, i);
      result += resultStringWriter.ToString();

      Console.SetOut(expectedStringWriter);
      mExpectedPrintLINQHouse_TotalInsuredValue(furniture, i);
      expected += expectedStringWriter.ToString();
    }
    Console.SetOut(saved);

    bool final = result == expected;

    if (final)
    {
      Console.WriteLine("\x1b[92mEnum \"TotalInsuredValue() (LINQ) (House)\" has been implemented correctly\x1b[39m");
    }
    else
    {
      Console.WriteLine($"\x1b[91mEnum \"TotalInsuredValue() (LINQ) (House)\" has not been implemented correctly\nExpected:\n{expected}\n\nActual:\n{result}\x1b[39m");
    }

    return final;
  }

  private static bool mTLINQHouse_GetFurnitureAboveValue()
  {
    var saved = Console.Out;

    string result = "";
    string expected = "";
    StringWriter expectedStringWriter = new StringWriter();
    StringWriter resultStringWriter = new StringWriter();

    Console.SetOut(expectedStringWriter);
    Console.WriteLine("Testing GetFurnitureAboveValue");

    Console.SetOut(resultStringWriter);
    Console.WriteLine("Testing GetFurnitureAboveValue");

    for (int i = 5; i <= 15; i += 5)
    {
      var furniture = GenerateFurnitureList(i);

      Console.SetOut(expectedStringWriter);
      mExpectedPrintLINQHouse_GetFurnitureAboveValue(furniture, i);
      expected += expectedStringWriter.ToString();

      Console.SetOut(resultStringWriter);
      mPrintLINQHouse_GetFurnitureAboveValue(furniture, i);
      result += resultStringWriter.ToString();
    }
    Console.SetOut(saved);

    bool final = result == expected;

    if (final)
    {
      Console.WriteLine("\x1b[92mEnum \"TotalInsuredValue() (LINQ) (House)\" has been implemented correctly\x1b[39m");
    }
    else
    {
      Console.WriteLine($"\x1b[91mEnum \"TotalInsuredValue() (LINQ) (House)\" has not been implemented correctly\nExpected:\n{expected}\n\nActual:\n{result}\x1b[39m");
    }

    return final;
  }

  private static void mPrintLINQHouse_TotalInsuredValue(List<Furniture> furniture, int count)
  {
    House home = new(count + ", Fake street", furniture);
    Console.WriteLine($"Total cost of insured furniture items: {home.TotalInsuredValue()}");
    Console.WriteLine($"All furniture at {home.Address}: ");
    Console.WriteLine(string.Join("\n", home.FurnitureList));
    Console.WriteLine();
  }

  private static void mExpectedPrintLINQHouse_TotalInsuredValue(List<Furniture> furniture, int count)
  {
    ExpectedHouse expectedHome = new(count + ", Fake street", furniture);
    Console.WriteLine($"Total cost of insured furniture items: {expectedHome.TotalInsuredValue()}");
    Console.WriteLine($"All furniture at {expectedHome.Address}: ");
    Console.WriteLine(string.Join("\n", expectedHome.FurnitureList));
    Console.WriteLine();
  }

  private static void mPrintLINQHouse_GetFurnitureAboveValue(List<Furniture> furniture, int count)
  {
    // furniture.Add(new Furniture("Cupboard", 9, count * 50, true));
    House home = new(count + ", Fake street", furniture);
    Console.WriteLine($"Items above {count * 50} at {home.Address}:");
    Console.WriteLine($"{string.Join("\n", home.GetFurnitureAboveValue(count * 50))}");

    Console.WriteLine($"\nAll furniture at {home.Address}: ");
    Console.WriteLine(string.Join("\n", home.FurnitureList));
    Console.WriteLine("----------------------------------------------------------");
  }
   
  private static void mExpectedPrintLINQHouse_GetFurnitureAboveValue(List<Furniture> furniture, int count)
  {
    furniture.Add(new Furniture("Cupboard", 9, count * 50, true));
    ExpectedHouse home = new(count + ", Fake street", furniture);
    Console.WriteLine($"Items above {count * 50} at {home.Address}:");
    Console.WriteLine($"{string.Join("\n", home.GetFurnitureAboveValue(count * 50))}");

    Console.WriteLine($"\nAll furniture at {home.Address}: ");
    Console.WriteLine(string.Join("\n", home.FurnitureList));
    Console.WriteLine("----------------------------------------------------------");
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

  private static void PrintPropertyNotFoundInClass(Type clsType, string propertyName) => Console.WriteLine($"\x1b[91m(Class {clsType.Name}) property {propertyName} not found. (Are you sure it is a property and not a field?)\x1b[39m");

  private static List<Furniture> GenerateFurnitureList(int count)
  {
    string[] names = ["Chair", "Table", "Sofa", "Bed", "Cabinet", "Desk", "Computer", "TV", "Lamp", "Fridge"];

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

//Classes as they should be to function as they are required to pass the exam
class ExpectedVan
{
  public ExpectedVanCapacity Capacity { get; set; }
  public Stack<Furniture> Contents { get; set; }
  public int UsedVolume { get; set; }

  public ExpectedVan(ExpectedVanCapacity capacity)
  {
    Capacity = capacity;
    Contents = new Stack<Furniture>();
    UsedVolume = 0;
  }

  public bool Load(Furniture furniture)
  {
    if (furniture.Volume + UsedVolume <= (int)Capacity)
    {
      Contents.Push(furniture);
      UsedVolume += furniture.Volume;
      return true;
    }
    return false;
  }

  public List<Furniture> Unload()
  {
    List<Furniture> returnValue = new List<Furniture>();
    while (Contents.Count != 0)
    {
      Furniture currentItem = Contents.Peek();
      UsedVolume -= currentItem.Volume;
      returnValue.Add(currentItem);
      Contents.Pop();
    }

    return returnValue;
  }

  public override string ToString()
  {
    string contentOfVan = "";
    foreach (Furniture item in Contents)
    {
      if (contentOfVan != "")
      {
        contentOfVan += " ";
      }
      contentOfVan += item.Name;
    }

    return $"Capacity: {(int)Capacity}\n" +
            $"Used: {UsedVolume}\n" +
            $"Contents: {contentOfVan}";
  }
}

enum ExpectedVanCapacity
{
  Small = 15,
  Medium = 20,
  Large = 30
}

class ExpectedHouse
{
    public string Address { get; private set; }
    public readonly List<Furniture> FurnitureList;

    public ExpectedHouse(string address, List<Furniture> furnitureList)
    {
        Address = address;
        FurnitureList = furnitureList;
    }

    public int TotalInsuredValue()
    {
        List<Furniture> insuredItems = FurnitureList.Where(f => f.IsInsured == true).ToList();
        int returnValue = 0;

        foreach (Furniture item in insuredItems) {
            returnValue += item.Value;
        }

        return returnValue;
    }

    public List<Furniture>? GetFurnitureAboveValue(int value)
    {
        List<Furniture>? returnValue = FurnitureList.Where(f => f.Value > value).OrderBy(f => f.Value).OrderBy(f => f.IsInsured).ToList();
        return returnValue;
    }
}