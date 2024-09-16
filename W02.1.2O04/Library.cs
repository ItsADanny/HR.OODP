public class Library
{
    public List<Book> Books = new List<Book>();
    public int MaxSize;

    public Library(int int_maxsize)
    {
        MaxSize = int_maxsize;
    }

    public bool AddBook(int int_id, string str_title)
    {
        Book book_newBook = new Book(int_id, str_title);
        if ((Books.Count + 1) <= MaxSize)
        {
            Books.Add(book_newBook);
            return true;
        }
        return false;
    }

    public Book FindBookByID(int int_id)
    {
        Book book_bookfound = null;
        foreach (Book book in Books)
        {
            if (book.ID == int_id)
            {
                book_bookfound = book;
            }
        }
        return book_bookfound;
    }

    public void EditBookTitle(int int_id, string str_title)
    {
        List<Book> ls_book_edittedBooks = new List<Book>();
        bool bool_bookAlreadyEditted = false;
        foreach (Book book in Books)
        {
            if (book.ID == int_id)
            {
                if (!bool_bookAlreadyEditted)
                {
                    Book book_updatedBook = new Book(book.ID, str_title);
                    ls_book_edittedBooks.Add(book_updatedBook);
                }
                else
                {
                    ls_book_edittedBooks.Add(book);
                }
            }
            else
            {
                ls_book_edittedBooks.Add(book);
            }
        }
        Books = ls_book_edittedBooks;
    }

    public void RemoveBookByTitle(string str_title)
    {
        List<Book> ls_book_edittedBooks = new List<Book>();
        foreach (Book book in Books)
        {
            if (book.Title != str_title)
            {
                ls_book_edittedBooks.Add(book);
            }
        }
        Books = ls_book_edittedBooks;
    }
}