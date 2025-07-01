static class SentenceAnalyzer
{
    public static bool AreReversed(Sentence sentence1, Sentence sentence2)
    {
        return AreReversed(sentence1, sentence2, 0);
    }

    private static bool AreReversed(Sentence sentence1, Sentence sentence2, int index)
    {
        if (sentence1.WordCount != sentence2.WordCount) return false;
        if (index + 1 >= sentence1.WordCount) {
            string word_sentence1 = sentence1.Words[index];
            string word_sentence2 = sentence2.Words[(sentence2.WordCount - 1) - index];

            return word_sentence1 == word_sentence2;
        } else {
            string word_sentence1 = sentence1.Words[index];
            string word_sentence2 = sentence2.Words[(sentence2.WordCount - 1) - index];

            return word_sentence1 == word_sentence2 && AreReversed(sentence1, sentence2, index+1);
        }
    }
}