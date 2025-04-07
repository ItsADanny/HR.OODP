class Member : Person
{
    public override string Name {get;}
	public string PreferredLanguage {get; set;}
    public int NumberOfBooksBorrowed {get; private set;} = 0;

    public Member(string name, int age, string preferredLanguage) : base(name, age)
	{
        Name = name;
        PreferredLanguage = preferredLanguage;
	}

    public void BorrowBook(Book book)
    {
        if (book is not null) {
            if (book is EBook) {
                EBook eBook = book as EBook;
                 eBook.SetLanguage(PreferredLanguage);
                 Console.WriteLine($"{Name} (member) has borrowed {eBook.Title} by {eBook.Author}");
            } else {
                if (NumberOfBooksBorrowed != 3) {
                    NumberOfBooksBorrowed++;
                    Console.WriteLine($"{Name} (member) has borrowed {book.Title} by {book.Author}");
                } else {
                    Console.WriteLine($"{Name} (member) has already borrowed the maximum number of books");
                }
            }
        } else {
            Console.WriteLine("Invalid book");
        }
        
    }

    public override string ToString() => $"Name: {Name}\nAge: {Age}\nBorrowed books: {NumberOfBooksBorrowed}";
}