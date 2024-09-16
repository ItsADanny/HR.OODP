public class Book
{
    public int ID;
    public string Title;

    public Book(int int_id, string str_title)
    {
        ID = int_id;
        Title = str_title;
    }

    public string Info()
    {
        return $"ID: {ID}, Title: {Title}";
    }
}
