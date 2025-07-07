static class CodeGradeTester
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "ArrayType": TestJaggedArrayType(); return;
            case "ValueTupleType": TestValueTupleType(); return;
            case "Create": TestCreateWordLadder(); return;
            case "Play": TestPlayWord(); return;
            case "Changes": TestWordChanges(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestJaggedArrayType()
    {
        TestUtils.PrintFieldType(typeof(WordLadder), "Words");
    }

    public static void TestValueTupleType()
    {
        TestUtils.PrintMethodSignature(typeof(WordLadder), "GetWordChanges", []);
    }

    public static void TestCreateWordLadder()
    {
        List<WordLadder> wls = [
            new WordLadder(3, 5),
            new WordLadder(4, 3),
            new WordLadder(5, 5),
            new WordLadder(6, 3),
        ];

        foreach (WordLadder wl in wls)
        {
            PrintGame(wl);
            Console.WriteLine();
        }
    }

    public static void TestPlayWord()
    {
        // Happy flow
        {
            Console.WriteLine("=== Test 1a: Happy flow ===");
            WordLadder wl = new(3, 4);
            PlayWordsAndPrintResult(wl, ["car", "bar", "rib", "rub"]);
        }
        {
            Console.WriteLine("=== Test 1b: Happy flow ===");
            WordLadder wl = new(4, 4);
            PlayWordsAndPrintResult(wl, ["scar", "race", "pace", "deap"]);
        }
        {
            Console.WriteLine("=== Test 1c: Happy flow ===");
            WordLadder wl = new(5, 3);
            PlayWordsAndPrintResult(wl, ["plane", "plain", "lapis"]);
        }

        // Incorrect letter count
        {
            Console.WriteLine("=== Test 2a: Incorrect letter count ===");
            WordLadder wl = new(3, 5);
            PlayWordsAndPrintResult(wl, ["kid", "skid", "skids"]);
        }
        {
            Console.WriteLine("=== Test 2b: Incorrect letter count ===");
            WordLadder wl = new(3, 5);
            PlayWordsAndPrintResult(wl, ["I", "hi", "his", "thesis", "this", "heist"]);
        }

        // Invalid follow-up
        {
            Console.WriteLine("=== Test 3a: Invalid follow-up ===");
            WordLadder wl = new(3, 5);
            PlayWordsAndPrintResult(wl, ["abc", "def", "ghi", "jkl", "mno"]);
        }
        {
            Console.WriteLine("=== Test 3b: Invalid follow-up ===");
            WordLadder wl = new(3, 3);
            PlayWordsAndPrintResult(wl, ["his", "her", "him"]);
        }

        // Game already finished
        {
            Console.WriteLine("=== Test 4a: Game is already finished ===");
            WordLadder wl = new(3, 3);
            PlayWordsAndPrintResult(wl, ["car", "bar", "rib", "rub"]);
        }
        {
            Console.WriteLine("=== Test 4b: Game is already finished ===");
            WordLadder wl = new(4, 3);
            PlayWordsAndPrintResult(wl, ["mane", "pane", "pine", "wine", "line"]);
        }
    }

    private static void PlayWordsAndPrintResult(WordLadder wl, List<string> wordsToPlay)
    {
        foreach (string word in wordsToPlay)
        {
            Console.WriteLine($"Playing word: {word}...");
            bool isValidPlay = wl.PlayWord(word);
            if (isValidPlay)
            {
                Console.WriteLine("Valid play");
                PrintGame(wl);

            }
            else
                Console.WriteLine($"Invalid play");

            Console.WriteLine();
        }
    }

    public static void TestWordChanges()
    {
        {
            Console.WriteLine("=== Test 1 ===");
            WordLadder wl = new(3, 4);
            PlayWordsAndPrintWordChanges(wl, ["car", "bar", "rib", "rub"]);
        }

        Console.WriteLine("\n=== Test 2 ===");
        {
            WordLadder wl = new(4, 3);
            PlayWordsAndPrintWordChanges(wl, ["dare", "dart", "dirt"]);
        }

        Console.WriteLine("\n=== Test 3 ===");
        {
            WordLadder wl = new(4, 3);
            PlayWordsAndPrintWordChanges(wl, ["dare", "dire", "dirt"]);
        }
    }

    private static void PlayWordsAndPrintWordChanges(WordLadder wl, List<string> wordsToPlay)
    {
        foreach (string word in wordsToPlay)
        {
            wl.PlayWord(word);
        }

        var wordChanges = wl.GetWordChanges();
        if (wordChanges == null)
        {
            Console.WriteLine("Game not yet finished.");
            return;
        }

        foreach (var (From, To) in wordChanges)
        {
            Console.WriteLine($"From {From} to {To}");
        }
    }

    private static void PrintGame(WordLadder wl)
    {
        Console.WriteLine($"How many words: {wl.HowManyWords}");
        Console.WriteLine($"Word length: {wl.WordLength}");
        for (int y = 0; y < wl.Words.GetLength(0); y++)
        {
            for (int x = 0; x < wl.Words.GetLength(1); x++)
            {
                Console.Write(wl.Words[y, x]);
            }
            Console.WriteLine();
        }
    }
}
