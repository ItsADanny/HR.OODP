static class SentenceUtils
{
    public static List<Sentence> FilterSentences(List<Sentence> sentences, Func<Sentence, bool> condition) {
        List<Sentence> returnValue = new List<Sentence>();

        foreach(Sentence item in sentences) {
            if (condition(item)) {
                returnValue.Add(item);
            }
        }

        return returnValue;
    }
}