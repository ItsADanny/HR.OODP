/*
  This assignment didn't use the Program.cs file
  For this assignment please refer to the following files:

  * Sentence.cs
  * SentenceAnalyzer.cs
  * SentenceUtils.cs

*/

//===================================================================================================

/*
  This code is show that people can run the assignments with a program that will test the code in the same way as done in the exam
  (See the folder "CodeGrade testing scripts" to see the original code that the program has been tested on)

  This program will test the functionality and return the same point value as the real exam if all the right functionality has been achieved.
*/
using System.Reflection;

public class Program
{
  public static void Main()
  {
    double score = 0;
    string bar = "===========================================================================================";
    string bar2 = "-------------------------------------------------------------------------------------------";

    Console.Clear();
    Console.WriteLine($"{bar}\nEXAM ASSIGNMENT TESTER - OODP ENDTERM - ASSIGNMENT #3\n\nHighest score possible: 2.0\n{bar}\n\n");
    Console.WriteLine($"Test #1: Is Recursive:\n{bar2}");
    score += LocalTestUtils.TestIsRecursive();
    Console.WriteLine($"\n\nTest #2: Recursion:\n{bar2}");
    score += LocalTestUtils.TestRecursion();
    Console.WriteLine($"\n\nTest #3: High Order Function:\n{bar2}");
    score += LocalTestUtils.TestHOF();

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
  public static double TestIsRecursive() => mTIsRecursive(typeof(SentenceAnalyzer), "AreReversed", [typeof(Sentence), typeof(Sentence), typeof(int)]) ? 0 : 0;
  public static double TestRecursion() => mTRecursion() ? 1.4 : 0;
  public static double TestHOF() => mTHOF() ? 0.6 : 0;

  private static bool mTIsRecursive(Type clsType, string methodName, Type[] parameterTypes)
  {
    var method = clsType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static,
            null, parameterTypes, null);

    if (method == null)
    {
      Console.WriteLine($"\x1b[91mClass {clsType.Name}: method {methodName}({string.Join(", ", parameterTypes.Select(GetFriendlyTypeName))}) not found\x1b[39m");
      return false;
    }

    if (IsRecursive(method))
    {
      Console.WriteLine("\x1b[92mMethod has been found and has been found to be recursivly implemented\x1b[39m");
    }
    else
    {
      Console.WriteLine("\x1b[91mMethod has been found but has not been seen as recursive\x1b[39m");
    }

    return IsRecursive(method);
  }

  private static bool mTRecursion()
  {
    List<(string s1, string s2, bool expected)> testCases = [
            // Perfect reversals
            ("the quick brown fox", "fox brown quick the", true),
            ("hello world", "world hello", true),
            ("one", "one", true),
            ("Hello", "hello", true),
            // Not reversed
            ("hello world", "hello world", false),
            ("one two", "one two", false),
            ("a b c", "c b d", false),
            // Different lengths
            ("this is short", "short is", false),
            ("this is rather long", "long rather is", false),
    ];

    string errors = "";

    foreach (var (s1, s2, expected) in testCases)
    {
      Sentence sent1 = new(s1);
      Sentence sent2 = new(s2);
      bool actual = SentenceAnalyzer.AreReversed(sent1, sent2);

      if (actual != expected) {
        if (errors != "") {
          errors += "\n";
        }
        errors += $"sentence 1: \"{s1}\"| sentence 2: \"{s2}\", Expected: \x1b[91m{expected}\x1b[39m, Actual: \x1b[91m{actual}\x1b[39m";
      }
    }

    if (errors.Length == 0)
    {
      Console.WriteLine($"\x1b[92mThe .AreReversed has been implemented correctly\x1b[39m");
      return true;
    }
    else
    {
      Console.WriteLine($"\x1b[91mThere were errors found in the .AreReversed method:\x1b[39m\n{errors}");
      return false;
    }
  }

  private static bool mTHOF()
  {
    List<Sentence> sentences1 = [
      new("the quick brown fox"),
      new("jumps over the lazy dog"),
      new("a short one"),
      new("tiny"),
      new("this is a considerably longer sentence with many words")
    ];

    List<Sentence> sentences2 = [
      new("hello there"),
      new("good morning"),
      new("how are you"),
      new("morning sunshine"),
      new("hi hi hi")
    ];

    List<Sentence> sentences3 = [
      new("yes yes yes"),
      new("no no no"),
      new("maybe maybe maybe"),
      new("yes no maybe"),
      new("yes absolutely yes")
    ];

    int correct = 0;

    //Test 1
    //Check to see if it can use the lambda to return a sentence with atleast 5 words
    List<Sentence> c1 = SentenceUtils.FilterSentences(sentences1, s => s.WordCount > 5);
    if (c1.Count == 1 && string.Join(" ", c1[0].Words) == "this is a considerably longer sentence with many words")
    {
      correct++;
    }
    else
    {
      Console.WriteLine($"During HOF test #1 there was an error encounterd with trying to preform the lambda");
      Console.WriteLine("Expected:\nthis is a considerably longer sentence with many words");
      string sentences = "";
      foreach (Sentence sentence in c1)
      {
        if (sentences != "")
        {
          sentences += "\n";
        }
        sentences += string.Join(" ", sentence.Words);
      }
      Console.WriteLine($"Actual:\n{sentences}");
    }

    //Test 2
    //Check to see if it can use the lambda to return two sentences that contain the word "morning"
    List<Sentence> c2 = SentenceUtils.FilterSentences(sentences2, s => s.Words.Contains("morning"));
    if (c2.Count == 2 && string.Join(" ", c2[0].Words) == "good morning" && string.Join(" ", c2[1].Words) == "morning sunshine")
    {
      correct++;
    }
    else
    {
      Console.WriteLine($"During HOF test #2 there was an error encounterd with trying to preform the lambda");
      Console.WriteLine("Expected:\ngood morning\nmorning sunshine");
      string sentences = "";
      foreach (Sentence sentence in c2)
      {
        if (sentences != "")
        {
          sentences += "\n";
        }
        sentences += string.Join(" ", sentence.Words);
      }
      Console.WriteLine($"Actual:\n{sentences}");
    }

    //Test 3
    //Check to see if all the words in a sentence are "yes"
    List<Sentence> c3 = SentenceUtils.FilterSentences(sentences3, s => s.Words.All(word => word == "yes"));
    if (c3.Count == 1 && string.Join(" ", c3[0].Words) == "yes yes yes")
    {
      correct++;
    }
    else
    {
      Console.WriteLine($"During HOF test #3 there was an error encounterd with trying to preform the lambda");
      Console.WriteLine("Expected:\nyes yes yes");
      string sentences = "";
      foreach (Sentence sentence in c3)
      {
        if (sentences != "")
        {
          sentences += "\n";
        }
        sentences += string.Join(" ", sentence.Words);
      }
      Console.WriteLine($"Actual:\n{sentences}");
    }

    if (correct == 3) {
      Console.WriteLine($"\x1b[92mHigh Order Functions have been implemented correctly\x1b[39m");
    }
    return correct == 3;
  }

  private static bool IsRecursive(MethodInfo method)
  {
    MethodBody body = method.GetMethodBody() ?? throw new ArgumentException(method.Name, "Unexpected args value: {methodName}");

    var ilBytes = body.GetILAsByteArray();
    if (ilBytes == null) { return false; }

    int methodMetadataToken = method.MetadataToken;

    for (int i = 0; i < ilBytes.Length - 4; i++)
    {
      if (ilBytes[i] == 0x28)
      {
        int calledMethodToken = BitConverter.ToInt32(ilBytes, i + 1);

        if (calledMethodToken == methodMetadataToken)
        {
          return true;
        }
      }
    }

    return false;
  }
  
  private static string GetFriendlyTypeName(Type type) => type switch
  {
    // Tuple types
    _ when type!.FullName?.StartsWith("System.ValueTuple") == true =>
        $"({string.Join(", ", type.GetGenericArguments().Select(GetFriendlyTypeName))})",

    // Handle basic types
    { } when type == typeof(string) => "string",
    { } when type == typeof(int) => "int",
    { } when type == typeof(bool) => "bool",
    { } when type == typeof(double) => "double",
    { } when type == typeof(float) => "float",
    { } when type == typeof(decimal) => "decimal",
    { } when type == typeof(object) => "object",
    { } when type == typeof(void) => "void",

    // Handle arrays (1D, multi-dimensional, and jagged arrays)
    _ when type!.IsArray =>
        $"{GetFriendlyTypeName(type.GetElementType()!)}{new string('[', type.GetArrayRank())}{new string(']', type.GetArrayRank())}",

    // Handle generic types
    _ when type.IsGenericTypeDefinition =>
        $"{type.Name.Split('`')[0]}<>",

    _ when type.IsGenericType =>
        $"{type.Name.Split('`')[0]}<{string.Join(", ", type.GetGenericArguments().Select(GetFriendlyTypeName))}>",

    // Default fallback for other types
    _ => type.FullName ?? type.Name
  };
}