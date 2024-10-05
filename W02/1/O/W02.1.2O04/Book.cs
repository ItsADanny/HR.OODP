//We begin by creating the class
public class Book
{
    //We then add the two variables in which we are going to store the book's ID and the Title
    public int ID;
    public string Title;

    //In its constructor we are going to assign the inputted ID and Title to the Objects ID and Title fields
    public Book(int int_id, string str_title)
    {
        ID = int_id;
        Title = str_title;
    }

    //When the method Info is called we return a string with the books ID and Title
    public string Info()
    {
        return $"ID: {ID}, Title: {Title}";
    }
}