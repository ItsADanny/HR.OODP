class EBook : Book
{
    public EBook(string title, string author, string language) : base(title, author, language) { }

    public EBook(string title, string author) : base(title, author, "EN") { }

    public void SetLanguage(string language)
    {
        Language = language;
        Console.WriteLine($"Language set to {language}");
    }
	
    public override void PrintInfo() {
        Console.WriteLine(
            $"Title: {Title}\n" +
            $"Author: {Author}\n" +
            $"Language: {Language}\n" +
            "EBook");
    }
}