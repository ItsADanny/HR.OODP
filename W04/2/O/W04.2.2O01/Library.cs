public class Library {
    //This will be the value a Libary object
    public List<Book> Books;

    //When the constructor for this called with NO VARIABLES then we will initiate the Books List with a new List
    public Library() {
        Books = [];
    }
    //When the constructor is called with a LIST OF BOOKS then we will set the Books list as that it contains 
    //all these Books
    public Library(List<Book> books) {
        Books = books;
    }

    //These method adds Books to our Books list
    //Either by giving us a ID and Title
    public void AddBook (int id, string title) => Books.Add(new Book(id, title));
    //Or by providing a Book instance
    public void AddBook (Book book) => Books.Add(book);

    //This method will try to find a Book instance based on the ID that has been provided to the method
    public Book FindBook (int id) {
        //We iterate through our list of books until we find the first instance of a book with that ID,
        //If we cannot find any book that ID then we return null
        foreach (Book book in Books) {
            if (book.ID == id) {
                return book;
            }
        }
        return null;
    }

    public Book FindBook (string id) {
        //Predefine the variable which we will later use for our parsing
        int int_id;
        //Try and see if we can parse our input into a integer, if not then we will print an error message 
        //and return null
        if (int.TryParse(id, out int_id)) {
            //If our parsing is succesfull then we will run the FindBook method with this integer
            //and return its result
            return FindBook(int_id);
        } else {
            Console.WriteLine($"ID = {id}: invalid. The input string '{id}' was not in a correct format.");
            return null;
        }
    }
}