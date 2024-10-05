//We begin by creating the class
public class Library
{
    //We then add the two variables in which we are going to store the libraries book's ID and its max size
    public List<Book> Books = new List<Book>();
    public int MaxSize;

    //In its constructor we are going to assign the inputted max size to the Objects MaxSize field
    public Library(int int_maxsize) {
        MaxSize = int_maxsize;
    }

    //With this Method we can add a book to the library with just the Books ID and Title.
    //If the creation is succesfull and We have space in the library than we add this book to the library and
    //return a true, if this is not possible then we return a false
    public bool AddBook(int int_id, string str_title) {
        //Check to see if we can add a book to our library without surpassing its max size
        if ((Books.Count + 1) <= MaxSize)
        {
            //Create a new Book object
            Book book_newBook = new Book(int_id, str_title);
            //Add the book object to the libraries book list
            Books.Add(book_newBook);
            //Return a true
            return true;
        }
        //if not then we return false
        return false;
    }

    //This method finds a book by its ID
    //(This method return the first book found with the inputted ID)
    public Book FindBookByID(int int_id) {   
        //We iterate through the books in our library one by one
        foreach (Book book in Books) {
            //If the book contains a matching ID to the one we put in then we return this book rightaway
            if (book.ID == int_id) {
                return book;
            }
        }
        //If no book is found that matches the ID then we return a null value
        return null;
    }

    //This method can be used to Edit a books title if we find a book with a matching ID
    public void EditBookTitle(int int_id, string str_title) {
        //We begin by creating a List in which we will store our book with all the books. Edited or unedited
        List<Book> ls_book_editedBooks = new List<Book>();
        //We then create a variable in which we will store if we already edited a book 
        //(by default this field will be false)
        bool bool_bookAlreadyEdited = false;
        //We iterate through the books in the library to see if we can find a book with the matching ID
        foreach (Book book in Books) {
            //Check to see if we find a matching ID
            if (book.ID == int_id) {
                //Then check to see if we haven't already edited a book
                if (!bool_bookAlreadyEdited) {
                    //If not then create a book with its new title and with the currents books ID
                    Book book_updatedBook = new Book(book.ID, str_title);
                    //Add this to the edited library variable
                    ls_book_editedBooks.Add(book_updatedBook);
                    //And set the variable to indicated that we have already edited a book to true
                    bool_bookAlreadyEdited = true;
                } else {
                    //If we have already edited a book with the matching ID then we just 
                    //add the book to our edited library variable
                    ls_book_editedBooks.Add(book);
                }
            } else {
                //If the book doesn't match our books id we are searching for then we 
                //add the book to the edited library
                ls_book_editedBooks.Add(book);
            }
        }
        //After all that we set the Libraries Library to our edited library
        Books = ls_book_editedBooks;
    }

    //This method removes all Books with a inputted title
    public void RemoveBookByTitle(string str_title) {
        //We begin by creating a List in which we will store our book with all that don't have the title we
        //want to remove
        List<Book> ls_book_editedBooks = new List<Book>();
        //We iterate through the books in the library to see if we can find a book with the matching Title
        foreach (Book book in Books) {
            //If the book's title doesn't match what we are searching for then we 
            //Add the book to our edited library
            if (book.Title != str_title) {
                ls_book_editedBooks.Add(book);
            }
        }
        //After all that we set the Libraries Library to our edited library
        Books = ls_book_editedBooks;
    }
}