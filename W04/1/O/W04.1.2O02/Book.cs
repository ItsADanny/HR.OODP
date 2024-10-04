public class Book {

    public string Title;
    public string Author;
    public int PublicationYear;

    public Book (string title, string author, int publicationYear) {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
    }

    public string Info () {
        return $"{Title} by {Author} ({PublicationYear})";
    }
}