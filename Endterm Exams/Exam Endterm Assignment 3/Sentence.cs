// Do not modify this file

class Sentence
{
    public string[] Words = [];
    public int WordCount => Words.Length;

    public Sentence(string sentence)
    {
        Words = [.. sentence.ToLower().Split(" ")];
    }
}