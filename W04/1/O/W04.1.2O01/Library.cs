public class Library {
    public List<Book> Books = new List<Book>();

    public Library() { }

    public Library(List<Book> listOfBooks) {
        Books = listOfBooks;
    }

    public void AddBook(Book book) => Books.Add(book);

    public void AddBook(int bookID, string bookTitle) => Books.Add(new Book(bookID, bookTitle));

    public Book FindBook(int bookID) {
        foreach (Book bookInstance in Books) {
            if (bookInstance.ID == bookID) {
                return bookInstance;
            }
        }
        return null;
     }

    public Book FindBook(string bookID) {
        if (int.TryParse(bookID, out int intBookID)) {
            return FindBook(intBookID);
        } else {
            throw new ArgumentException($"ID = {bookID}: invalid. The input string '{bookID}' was not in a correct format");
        }
    }
}