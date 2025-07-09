/*
  This assignment didn't use the Program.cs file
  For this assignment please refer to the following files:

  * ArtCollection.cs
  * ICreator.cs
  * Painting.cs
  * PaperCard.cs
  * Valuable.cs

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
    Console.WriteLine($"{bar}\nEXAM ASSIGNMENT TESTER - OODP ENDTERM - ASSIGNMENT #1\n\nHighest score possible: 2.0\n{bar}\n\n");
    Console.WriteLine($"Test #1: Generic Constraints:\n{bar2}");
    score += LocalTestUtils.RunGenericConstraintTest();
    Console.WriteLine($"\n\nTest #2: PrintCollection:\n{bar2}");
    score += LocalTestUtils.RunPrintCollectionTest();
    Console.WriteLine($"\n\nTest #3: Interfaces:\n{bar2}");
    score += LocalTestUtils.RunInterfaceTest();
    Console.WriteLine($"\n\nTest #4: IEquatable - PaperCard:\n{bar2}");
    score += LocalTestUtils.RunIEquatablePaperCardTest();
    Console.WriteLine($"\n\nTest #5: IEquatable - objects:\n{bar2}");
    score += LocalTestUtils.RunIEquatableObjectTest();
    Console.WriteLine($"\n\nTest #6: Operator overloading\n{bar2}");
    score += LocalTestUtils.RunOperatorOverloadTest();
    Console.WriteLine($"\n\nTest #7: Comparison:\n{bar2}");
    score += LocalTestUtils.RunComparisonTest();

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

public static class LocalTestUtils
{
  public static double RunGenericConstraintTest()
  {
    string expectedResult = "Inspecting generic constraints for Class 'ArtCollection<>': - Generic parameter: T  Must be (or be derived from) a: Valuable  Must implement:    - ICreator";
    if (CheckPrintedVariables(typeof(ArtCollection<>), expectedResult))
    {
      Console.WriteLine("\x1b[92mGeneric constraints have been implemented correctly\x1b[39m");
      return 0.3;
    }
    else
    {
      Console.WriteLine($"\x1b[91mGeneric constraints did match expected result\nExpected:\nInspecting generic constraints for Class 'ArtCollection<>':\n - Generic parameter: T\n  Must be (or be derived from) a: Valuable\n  Must implement:\n    - ICreator\n\nActual:\n{GetPrintedValues(typeof(ArtCollection<>))}\x1b[39m");
      return 0;
    }
  }
  public static double RunPrintCollectionTest()
  {
    ArtCollection<Painting> a1 = new();
    a1.Add(new("Sprookje", 1200, "R. Roodkapje"));
    a1.Add(new("Winter", 900, "P. Summer"));
    a1.Add(new("The Others", 400, "P. Same"));
    a1.Add(new("Abstract", 1000, "A. Beuty"));

    string a1ExpectedResult = "Sprookje by R. Roodkapje (value: 1200)Winter by P. Summer (value: 900)The Others by P. Same (value: 400)Abstract by A. Beuty (value: 1000)";

    ArtCollection<PaperCard> a2 = new();
    a2.Add(new("Blue-Eyes White Dragon", "First edition", 1000, "Maximillion Pegasus"));
    a2.Add(new("Charizard", "First edition", 2000, "Satoshi Tajiri"));

    string a2ExpectedResult = "Blue-Eyes White Dragon by Maximillion Pegasus (value: 1000)Charizard by Satoshi Tajiri (value: 2000)";

    bool a1TestResult = CheckPrintedVariables(a1, a1ExpectedResult);
    bool a2TestResult = CheckPrintedVariables(a2, a2ExpectedResult);

    if (a1TestResult && a2TestResult)
    {
      Console.WriteLine("\x1b[92mBoth collections (ArtCollection<Painting> & ArtCollection<PaperCard>) returned correct results\x1b[39m");
      return 0.5;
    }
    else
    {
      if (!a1TestResult)
      {
        Console.WriteLine($"\x1b[91mArtCollection<Painting> did not print correctly\nExpected:\nSprookje by R. Roodkapje (value: 1200)\nWinter by P. Summer (value: 900)\nThe Others by P. Same (value: 400)\nAbstract by A. Beuty (value: 1000)\n\nActual:\n{GetPrintedValues(a1)}\x1b[39m");
      }

      if (!a2TestResult)
      {
        Console.WriteLine($"\x1b[91mArtCollection<PaperCard> did not print correctly\nExpected:\nBlue-Eyes White Dragon by Maximillion Pegasus (value: 1000)\nCharizard by Satoshi Tajiri (value: 2000)\n\nActual:\n{GetPrintedValues(a2)}\x1b[39m");
      }

      return 0;
    }
  }
  public static double RunInterfaceTest()
  {
    bool interfaceResult_t1 = InterfaceImplemented(typeof(IEquatable<PaperCard>), typeof(PaperCard));
    bool interfaceResult_t2 = InterfaceImplemented(typeof(IComparable<Valuable>), typeof(Valuable));
    if (interfaceResult_t1 && interfaceResult_t2)
    {
      Console.WriteLine("\x1b[92mRequired interfaces have been correctly implemented in both classes (PaperCard & Valuable)\x1b[39m");
      return 0.1;
    }
    else
    {
      if (!interfaceResult_t1)
      {
        Console.WriteLine("\x1b[91mIEquatable<PaperCard> has not been implemented\x1b[39m");
      }
      if (!interfaceResult_t2)
      {
        Console.WriteLine("\x1b[91mIComparable<Valuable> has not been implemented\x1b[39m");
      }
      return 0;
    }
  }
  public static double RunIEquatablePaperCardTest()
  {
    PaperCard c0 = new("Chainlord", "Darkness", 10, "N. Jr.");
    PaperCard c1 = new("The Dark Wizard", "Darkness", 15, "N. Jr.");
    PaperCard c2 = new("The Light Wizard", "Lightness", 5, "N. Jr.");
    PaperCard c3 = new("Chainlord", "Darkness", 10, "N. Jr.");
    PaperCard c4 = new("Chainlord", "Darkness", 10, "N. Jr.");
    c4.Condition = 0.5;
    PaperCard c5 = null!;

    string result = $"{c0.Equals(c1)}-{c0.Equals(c2)}-{c0.Equals(c3)}-{c0.Equals(c4)}-{c0.Equals(c5)}";
    string expected = $"False-False-True-False-False";

    if (result == expected)
    {
      Console.WriteLine("\x1b[92mIEquatable Implementation for PaperCard is correct\x1b[39m");
      return 0.2;
    }
    else
    {
      Console.WriteLine("\x1b[91mThere is an incorrect result when trying to test IEquatable implementations:\x1b[39m");
      Console.WriteLine($"{c0.ToString()} = {c1.ToString()}, Result: {c0.Equals(c1)} Expected: False");
      Console.WriteLine($"{c0.ToString()} = {c2.ToString()}, Result: {c0.Equals(c2)} Expected: False");
      Console.WriteLine($"{c0.ToString()} = {c3.ToString()}, Result: {c0.Equals(c3)} Expected: True");
      Console.WriteLine($"{c0.ToString()} = {c4.ToString()}, Result: {c0.Equals(c4)} Expected: False");
      Console.WriteLine($"{c0.ToString()} = null, Result: {c0.Equals(c5)} Expected: False");
      return 0;
    }
  }

  public static double RunIEquatableObjectTest()
  {
    PaperCard c0 = new("Chainlord", "Darkness", 10, "N. Jr.");
    object c1 = new PaperCard("Chainlord", "Darkness", 10, "N. Jr.");
    Painting c2 = new("Summer", 1200, "P. Winter");
    object c3 = null!;

    string result = $"{c0.Equals(c1)}-{c0.Equals(c2)}-{c0.Equals(c3)}";
    string expected = $"True-False-False";

    if (result == expected)
    {
      Console.WriteLine("\x1b[92mIEquatable Implementation for PaperCard is correct\x1b[39m");
      return 0.2;
    }
    else
    {
      Console.WriteLine("\x1b[91mThere is an incorrect result when trying to test IEquatable implementations:\x1b[39m");
      Console.WriteLine($"{c0.ToString()} = {c1.ToString()}, Result: {c0.Equals(c1)} Expected: True");
      Console.WriteLine($"{c0.ToString()} = {c2.ToString()}, Result: {c0.Equals(c2)} Expected: False");
      Console.WriteLine($"{c0.ToString()} = null, Result: {c0.Equals(c3)} Expected: False");
      return 0;
    }
  }
  public static double RunOperatorOverloadTest()
  {
    PaperCard c0 = new("The Flying Lightness", "Lightness", 10, "N. Jr.");
    PaperCard c1 = new("Joe", "Humans", 15, "N. Jr.");
    PaperCard c2 = new("Dog", "Animals", 5, "N. Jr.");
    PaperCard c3 = new("The Flying Lightness", "Lightness", 10, "N. Jr.");
    PaperCard c4 = new("The Flying Lightness", "Lightness", 10, "N. Jr.");
    c4.Condition = 0.5;
    PaperCard c5 = null!;
    PaperCard c6 = null!;

    string result = $"{c0 == c1}-{c0 == c2}-{c0 == c3}-{c0 == c4}-{c0 == c5}-{c5 == c6}";
    string expected = $"False-False-True-False-False-True";

    if (result == expected)
    {
      Console.WriteLine("\x1b[92mIEquatable Implementation for PaperCard is correct\x1b[39m");
      return 0.3;
    }
    else
    {
      Console.WriteLine("\x1b[91mThere is an incorrect result when trying to test Operator overloading implementations:\x1b[39m");
      Console.WriteLine($"{c0.ToString()} = {c1.ToString()}, Result: {c0.Equals(c1)} Expected: False");
      Console.WriteLine($"{c0.ToString()} = {c2.ToString()}, Result: {c0.Equals(c2)} Expected: False");
      Console.WriteLine($"{c0.ToString()} = null, Result: {c0.Equals(c3)} Expected: True");
      Console.WriteLine($"{c0.ToString()} = {c4.ToString()}, Result: {c0.Equals(c1)} Expected: False");
      Console.WriteLine($"{c0.ToString()} == null, Result: {c0.Equals(c5)} Expected: False");
      Console.WriteLine($"null == null, Result: {c5.Equals(c6)} Expected: True");
      return 0;
    }
  }

  public static double RunComparisonTest()
  {
    List<Valuable> valuables = [
      new PaperCard("Green Dragon", "S1", 15, "N. Jr."),
      new PaperCard("Great Wizard", "S1", 15, "N. Jr."),
      new Painting("Summer", 1200, "P. Winter"),
      new PaperCard("Green Dragon", "S1", 10, "N. Jr."),
      new PaperCard("Storm", "S1", 5, "N. Jr."),
      new Painting("Winter", 1200, "P. Summer"),
      new PaperCard("Storm", "S1", 10, "N. Jr."),
      new Painting("Summer", 1000, "P. Winter"),
    ];

    valuables.Sort();

    string result = "";
    string expected = "Great Wizard (S1) (Rarity: 15) (Value: 15)Green Dragon (S1) (Rarity: 10) (Value: 10)Green Dragon (S1) (Rarity: 15) (Value: 15)Storm (S1) (Rarity: 5) (Value: 5)Storm (S1) (Rarity: 10) (Value: 10)Summer (Value: 1000)Summer (Value: 1200)Winter (Value: 1200)";

    foreach (Valuable v in valuables)
    {
      result += v.ToString();
    }

    if (result == expected)
    {
      Console.WriteLine("\x1b[92mIComparable Implementation for Valuable is correct\x1b[39m");
      return 0.4;
    }
    else
    {
      Console.WriteLine("\x1b[91mThere is an incorrect result when trying to test the IComparable implementation:\x1b[39m");
      Console.WriteLine("Expected:\nGreat Wizard (S1) (Rarity: 15) (Value: 15)\nGreen Dragon (S1) (Rarity: 10) (Value: 10)\nGreen Dragon (S1) (Rarity: 15) (Value: 15)\nStorm (S1) (Rarity: 5) (Value: 5)\nStorm (S1) (Rarity: 10) (Value: 10)\nSummer (Value: 1000)\nSummer (Value: 1200)\nWinter (Value: 1200)");
      Console.WriteLine("Actual:");
      foreach (Valuable v in valuables)
      {
        Console.WriteLine(v);
      }
      return 0;
    }
  }

  static bool InterfaceImplemented(Type interfaceType, Type clsType) => interfaceType.IsAssignableFrom(clsType);

  static bool CheckPrintedVariables<T>(ArtCollection<T> collection, string expectedResult) where T : Valuable, ICreator => GetPrintedValues(collection).Replace(Environment.NewLine, "") == expectedResult ? true : false;

  static bool CheckPrintedVariables(Type clsType, string expectedResult) => GetPrintedValues(clsType).Replace(Environment.NewLine, "") == expectedResult ? true : false;

  static string GetPrintedValues<T>(ArtCollection<T> collection) where T : Valuable, ICreator
  {
    var saved = Console.Out;
    using (StringWriter stringWriter = new StringWriter())
    {
      Console.SetOut(stringWriter);

      collection.PrintCollection();

      Console.SetOut(saved);
      return stringWriter.ToString();
    }
  }

  static string GetPrintedValues(Type clsType)
  {
    var saved = Console.Out;
    using (StringWriter stringWriter = new StringWriter())
    {
      Console.SetOut(stringWriter);

      PrintGenericClassConstraints(clsType);

      Console.SetOut(saved);
      return stringWriter.ToString();
    }
  }

  //ORIGINAL PART OF THE CODEGRADE TestUtils Class
  private static void PrintGenericClassConstraints(Type clsType)
  {
    if (!clsType.IsGenericTypeDefinition)
    {
      Console.WriteLine($"Class '{clsType.Name}' is not a generic type definition.");
      return;
    }

    Console.WriteLine($"Inspecting generic constraints for Class '{GetFriendlyTypeName(clsType)}':");

    var genericArgs = clsType.GetGenericArguments();
    foreach (var arg in genericArgs)
    {
      Console.WriteLine($" - Generic parameter: {arg.Name}");

      var constraints = arg.GetGenericParameterConstraints().ToList();

      var classConstraint = constraints.FirstOrDefault(c => c.IsClass);
      var interfaceConstraints = constraints.Where(c => c.IsInterface).OrderBy(c => c.Name).ToList();

      if (classConstraint == null && interfaceConstraints.Count == 0)
      {
        Console.WriteLine("  (No constraints)");
      }
      else
      {
        if (classConstraint != null)
        {
          Console.WriteLine($"  Must be (or be derived from) a: {GetFriendlyTypeName(classConstraint)}");
        }

        if (interfaceConstraints.Count > 0)
        {
          Console.WriteLine("  Must implement:");
          foreach (var c in interfaceConstraints)
          {
            Console.WriteLine($"    - {GetFriendlyTypeName(c)}");
          }
        }
      }
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
}