class Book
{
    public string Title {get;}
    public string Author {get;}
    public string Language {get; protected set;}

    public Book(Book book, string language)
    {
        Title = book.Title;
        Author = book.Author;
        Language = language;
    }

    public Book(string title, string author, string language)
    {
        Title = title;
        Author = author;
        Language = language;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine(
            $"Title: {Title}\n" +
            $"Author: {Author}\n" +
            $"Language: {Language}");
    }
}