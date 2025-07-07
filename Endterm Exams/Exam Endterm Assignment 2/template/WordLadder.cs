class WordLadder
{
    public readonly int WordLength;
    public readonly int HowManyWords;
    public readonly ... Words; // Replace ... with a 2D char array
    private int _turnsTaken = 0;
    public const char Open = '.';

    public WordLadder(int wordLength, int howManyWords)
    {
        // wordLength and howManyWords must be 1 or greater (you can ignore this)
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(wordLength);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(howManyWords);

        WordLength = wordLength;
        HowManyWords = howManyWords;        

        // Finish the constructor
    }

    public bool PlayWord(string playedWord)
    {
        playedWord = playedWord.ToUpper();


    }

    public ... GetWordChanges() // Replace ... with an array of a ValueTuple. The ValueTuple consists of two strings named From and To.
    {
        if (_turnsTaken < HowManyWords)
        {
            Console.WriteLine("The game isn't yet finished.");
            return null!;
        }
        
        
    }
    
    // Returns whether a played word is valid
    private bool IsValidPlay(string played)
    {
        if (_turnsTaken == 0 && played.Length == WordLength)
            return true;

        if (_turnsTaken >= HowManyWords || played.Length != WordLength)
            return false;

        played = played.ToUpper();
        string prev = GetWordAtTurn(_turnsTaken - 1).ToUpper();

        var playedCounts = new Dictionary<char, int>();
        var prevCounts = new Dictionary<char, int>();

        foreach (char c in played)
        {
            playedCounts[c] = playedCounts.GetValueOrDefault(c, 0) + 1;
        }

        foreach (char c in prev)
        {
            prevCounts[c] = prevCounts.GetValueOrDefault(c, 0) + 1;
        }

        int diffLetters = 0;

        var allKeys = new HashSet<char>(playedCounts.Keys.Concat(prevCounts.Keys));
        foreach (char c in allKeys)
        {
            int playedCount = playedCounts.GetValueOrDefault(c, 0);
            int prevCount = prevCounts.GetValueOrDefault(c, 0);
            if (playedCount != prevCount)
                diffLetters += Math.Abs(playedCount - prevCount);
        }

        return diffLetters == 2; // 1 letter added, 1 letter removed
    }

    // Returns the word played at a given turn (first turn is 0)
    private string GetWordAtTurn(int turn)
    {
        var chars = new char[WordLength];
        for (int x = 0; x < WordLength; x++)
        {
            chars[x] = Words[turn, x];
        }
        return new string(chars);
    }
}
