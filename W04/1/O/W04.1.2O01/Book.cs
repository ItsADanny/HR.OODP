public class Book {
    public int ID;
    public string Title;

    public Book(int id, string title) {
        ID = id;
        Title = title;
    }

    public Book(int id) {
        new Book(id, "unknown");
    }

    public string Info() => $"ID = {ID}, Title = {Title}";
}