// Do not modify this file

static class CodeGradeTester
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Where": TestGenericConstraints(); return;
            case "Collection": TestPrintCollection(); return;
            case "Interface": TestInterfaces(); return;
            case "Equal_PaperCard": TestEqual_PaperCard(); return;
            case "Equal_Object": TestEqual_Object(); return;
            case "Equal_Operator": TestEqual_Operator(); return;
            case "CompareTo": TestCompareTo(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestInterfaces()
    {
        TestUtils.PrintIsInterfaceImplementedBy(typeof(IEquatable<PaperCard>), typeof(PaperCard));
        TestUtils.PrintIsInterfaceImplementedBy(typeof(IComparable<Valuable>), typeof(Valuable));
    }

    public static void TestPrintCollection()
    {
        ArtCollection<Painting> a1 = new();
        a1.Add(new("Sprookje", 1200, "R. Roodkapje"));
        a1.Add(new("Winter", 900, "P. Summer"));
        a1.Add(new("The Others", 400, "P. Same"));
        a1.Add(new("Abstract", 1000, "A. Beuty"));
        a1.PrintCollection();

        Console.WriteLine();

        ArtCollection<PaperCard> a2 = new();
        a2.Add(new("Blue-Eyes White Dragon", "First edition", 1000, "Maximillion Pegasus"));
        a2.Add(new("Charizard", "First edition", 2000, "Satoshi Tajiri"));
        a2.PrintCollection();
    }

    public static void TestEqual_PaperCard()
    {
        PaperCard c0 = new("Chainlord", "Darkness", 10, "N. Jr.");
        PaperCard c1 = new("The Dark Wizard", "Darkness", 15, "N. Jr.");
        PaperCard c2 = new("The Light Wizard", "Lightness", 5, "N. Jr.");
        PaperCard c3 = new("Chainlord", "Darkness", 10, "N. Jr.");
        PaperCard c4 = new("Chainlord", "Darkness", 10, "N. Jr.");
        c4.Condition = 0.5;
        PaperCard c5 = null!;
        
        Console.WriteLine($"c0.Equals(c1): {c0.Equals(c1)}"); // false
        Console.WriteLine($"c0.Equals(c2): {c0.Equals(c2)}"); // false
        Console.WriteLine($"c0.Equals(c3): {c0.Equals(c3)}"); // true
        Console.WriteLine($"c0.Equals(c4): {c0.Equals(c4)}"); // false
        Console.WriteLine($"c0.Equals(c5): {c0.Equals(c5)}"); // false
    }

    public static void TestEqual_Object()
    {
        PaperCard c0 = new("Chainlord", "Darkness", 10, "N. Jr.");
        object c1 = new PaperCard("Chainlord", "Darkness", 10, "N. Jr.");
        Painting c2 = new("Summer", 1200, "P. Winter");
        object c3 = null!;

        Console.WriteLine($"c0.Equals(c1): {c0.Equals(c1)}"); // true
        Console.WriteLine($"c0.Equals(c2): {c0.Equals(c2)}"); // false
        Console.WriteLine($"c0.Equals(c3): {c0.Equals(c3)}"); // false
    }

    public static void TestEqual_Operator()
    {
        PaperCard c0 = new("The Flying Lightness", "Lightness", 10, "N. Jr.");
        PaperCard c1 = new("Joe", "Humans", 15, "N. Jr.");
        PaperCard c2 = new("Dog", "Animals", 5, "N. Jr.");
        PaperCard c3 = new("The Flying Lightness", "Lightness", 10, "N. Jr.");
        PaperCard c4 = new("The Flying Lightness", "Lightness", 10, "N. Jr.");
        c4.Condition = 0.5;
        PaperCard c5 = null!;
        PaperCard c6 = null!;

        Console.WriteLine($"c0 == c1: {c0 == c1}"); // false
        Console.WriteLine($"c0 == c2: {c0 == c2}"); // false
        Console.WriteLine($"c0 == c3: {c0 == c3}"); // true
        Console.WriteLine($"c0 == c4: {c0 == c4}"); // false
        Console.WriteLine($"c0 == c5: {c0 == c5}"); // false
        Console.WriteLine($"c5 == c6: {c5 == c6}"); // true
    }

    public static void TestCompareTo()
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

        foreach (Valuable v in valuables)
        { 
            Console.WriteLine(v);
        }
    }

    public static void TestGenericConstraints()
    {
        TestUtils.PrintGenericClassConstraints(typeof(ArtCollection<>));
    }
}
