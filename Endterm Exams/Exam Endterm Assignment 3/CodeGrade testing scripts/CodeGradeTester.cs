static class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Recursive": TestIsRecursive(); return;
            case "Recursion": TestRecursion(); return;
            case "HOF": TestHOF(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestIsRecursive()
    {
        TestUtils.PrintIsRecursive(typeof(SentenceAnalyzer), "AreReversed",
            [typeof(Sentence), typeof(Sentence), typeof(int)]);
    }

    public static void TestRecursion()
    {
        List<(string s1, string s2, bool expected)> testCases = [
            // Perfect reversals
            ("the quick brown fox", "fox brown quick the", true),
            ("hello world", "world hello", true),
            ("one", "one", true),
            ("Hello", "hello", true),
            ("It's a test.", "test a it's", true),
            ("OpenAI, rocks!", "rocks openai", true),
            // Not reversed
            ("hello world", "hello world", false),
            ("one two", "one two", false),
            ("a b c", "c b d", false),
            // Different lengths
            ("this is short", "short is", false),
            ("this is rather long", "long rather is", false),
        ];

        foreach (var (s1, s2, expected) in testCases)
        {
            Sentence sent1 = new(s1);
            Sentence sent2 = new(s2);
            bool actual = SentenceAnalyzer.AreReversed(sent1, sent2);
            Console.WriteLine($"[{(actual == expected ? "Pass" : "Fail")}] " +
                $"{s1} / {s2} => {actual}");
        }
    }

    public static void TestHOF()
    {
        Console.WriteLine("=== Test 1 ===");
        {
            List<Sentence> sentences1 = [
                new("the quick brown fox"),
                new("jumps over the lazy dog"),
                new("a short one"),
                new("tiny"),
                new("this is a considerably longer sentence with many words")
            ];

            var longSentences = SentenceUtils.FilterSentences(sentences1, s => s.WordCount > 5);
            Console.WriteLine("Sentences longer than 5 words:");
            foreach (var s in longSentences)
            {
                Console.WriteLine($" - {string.Join(" ", s.Words)}");
            }
        }

        Console.WriteLine("\n=== Test 2 ===");
        {
            List<Sentence> sentences2 = [
                new("hello there"),
                new("good morning"),
                new("how are you"),
                new("morning sunshine"),
                new("hi hi hi")
            ];

            var withMorning = SentenceUtils.FilterSentences(sentences2, s => s.Words.Contains("morning"));
            Console.WriteLine("Sentences containing the word 'morning':");
            foreach (var s in withMorning)
            {
                Console.WriteLine($" - {string.Join(" ", s.Words)}");
            }
        }

        Console.WriteLine("\n=== Test 3 ===");
        {
            List<Sentence> sentences3 = [
                new("yes yes yes"),
                new("no no no"),
                new("maybe maybe maybe"),
                new("yes no maybe"),
                new("yes absolutely yes")
            ];

            var allYes = SentenceUtils.FilterSentences(sentences3, s => s.Words.All(word => word == "yes"));
            Console.WriteLine("Sentences where all words are 'yes':");
            foreach (var s in allYes)
            {
                Console.WriteLine($" - {string.Join(" ", s.Words)}");
            }
        }
    }
}
