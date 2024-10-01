public class Book {
    //These will be the values a Book object contains
    public int ID;
    public string Title;

    //If we don't get any value as the title of a book then we set the title to "Unknown"
    public Book (int id, string title="Title unknown") {
        // We set the books values to the ones given to use when the constructor is called
        ID = id;
        Title = title;
    }

    //This function returns the ID and Title in a string format
    public string Info () {
        return $"ID = {ID}, Title = {Title}";
    }
}