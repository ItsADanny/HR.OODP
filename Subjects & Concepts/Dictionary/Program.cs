public class Program
{
    //A Dictionary is exactly what the name implies, A way to store data based on a Key value.
    //For our example we use an Integer value as the Key, but this can be anything you want.
    //And for our value we use a Book object
    public static Dictionary<int, Book> Library = new Dictionary<int, Book>();

    public static void Main()
    {
        //Our collection of Books, We will use these to populate our Dictionary (DEMO DATA)
        Book Metro2033 = new Book("Metro 2033", "By, Dmitry Glukhovsky", "09/06/2011", 464, 3);
        Book Metro2034 = new Book("Metro 2034", "By, Dmitry Glukhovsky", "13/11/2014", 320, 3);
        Book JeremyClarkson_DS_TTCCH = new Book("Til the Cows Come Home", "Diddly Squat, Til the cows come home by, Jeremy Clarkson", "29/09/2022", 240, 2);
        Book HTML_and_CSS = new Book("HTML & CSS", "HTML & CSS - design and build websites by, Jon Duckett", "30/05/2014", 490, 3);
        Book MBOICT_CSandVP = new Book("MBO-ICT, Cyber security & Veilig programmeren", "paperback by, Gabriel Sanchez Cano", "26/04/2018", 240, 3);
        Book ILoveDick = new Book("I Love Dick", "By, Chris Kraus", "01/01/2022", 272, 1);
        Book PolitiekTestament = new Book("Politiek Testament", "Politiek Testament by, Pim Fortuyn", "03/05/2022", 561, 4);
        Book CommunistManifesto = new Book("Communist manifesto", "The communist manifesto by, Carl Marx", "21/02/1848", 132, 3);
        Book AnimalFarm = new Book("Animal Farm", "By, George Orwell", "17/08/1945", 112, 3);
        Book GO1984 = new Book("1984", "By, George Orwell", "08/06/1949", 336, 3);
        Book Anarchist_CookBook = new Book("Anarchist Cookbook", "Anarchist Cookbook by, William Powell", "01/1971", 160, 3);
        Book USArmy_ExploAndDemo = new Book("U.S. Army Explosives and Demolitions Handbook", "By, the Department of The Army", "19/08/2010", 192, 1);
        Book USArmy_GuideToBooby = new Book("U.S. Army Guide to Boobytraps", "By, the Department of The Army", "18/02/2010", 144, 1);
        Book TheArtOfWar = new Book("The Art of War", "By, Sun Tzu", "475/221 BC", 296, 3);
        Book AtomicHabits = new Book("Atomic Habits", "By James Clear", "19/08/2022", 320, 3);
        Book FiftyShadesOfGrey = new Book("Fifty Shades Of Grey", "By, E L James", "04/2012", 544, 3);
        Book TJJSCookBookHTRW = new Book("The Jewish-Japanese Sex and Cook Book and How to Raise Wolves", "By, Jack Douglas", "15/12/1977", 210, 2);
        Book ITBEYITWUniverse = new Book("If This Book Exists, Youre in the Wrong Universe", "By, Jason Pargin", "18/10/2022", 432, 3);
        Book CannibalismBook = new Book("Cannibalism: A Perfectly Natural History", "By, Bill Schutt", "30/01/2018", 352, 3);
        Book APracticalGuideToR = new Book("A Practical Guide To Racism", "By, C.H. Dalton", "31/07/2014", 203, 2);
        Book TimePimp = new Book("Time Pimp", "By, Garrett Cook", "01/10/2013", 186, 1);

        //To add a book to our Dictionary we can simply use the .Add() method
        //In which we will put a Key value and the Value for that key
        //!IMPORTANT! The Key value must always be unique
        Library.Add(1, Metro2033);

        Library.Add(2, Metro2034);
        Library.Add(3, JeremyClarkson_DS_TTCCH);
        Library.Add(4, HTML_and_CSS);
        Library.Add(5, MBOICT_CSandVP);
        Library.Add(6, ILoveDick);
        Library.Add(7, PolitiekTestament);
        Library.Add(8, CommunistManifesto);
        Library.Add(9, AnimalFarm);
        Library.Add(10, GO1984);
        Library.Add(11, Anarchist_CookBook);
        Library.Add(12, USArmy_ExploAndDemo);
        Library.Add(13, USArmy_GuideToBooby);
        Library.Add(14, TheArtOfWar);
        Library.Add(15, AtomicHabits);
        Library.Add(16, FiftyShadesOfGrey);
        Library.Add(17, TJJSCookBookHTRW);
        Library.Add(18, ITBEYITWUniverse);
        Library.Add(19, CannibalismBook);
        Library.Add(20, APracticalGuideToR);
        Library.Add(21, TimePimp);

        //To remove a book from our Dictionary we can use the .Remove(key) method
        Library.Remove(15);

        //To check if a Dictionary contains a certain key we can use .ContainsKey(Key)
        Console.WriteLine($"Does the library contain the Book \"{AtomicHabits.Title}\"? {Library.ContainsKey(15)}");

        //To check if a Dictionary contains a certain value we can use .ContainsValue(value)
        Console.WriteLine($"Does the library contain the Book \"{GO1984.Title}\"? {Library.ContainsValue(GO1984)}");

        //To see how many books our Dictionary contains we can use the .Count() method
        Console.WriteLine($"Book is Library: {Library.Count()}");

        //To get a value from Dictionary you can use TryGetValue(key, out 'type' value)
        Library.TryGetValue(5, out Book? book);
        if (book is not null)
        {
            Console.WriteLine(book.ToString());
        }

        //You can also use this method in a if statement, so that it only does something when it can get it from our Dictionary
        if (Library.TryGetValue(4, out Book? book2)) {
            if (book2 is not null)
            { 
                Console.WriteLine(book2.ToString());
            }
        }
    }
}

public class Book
{
    public string Title;
    public string Description;
    public string PublishingDate;
    public int Pages;
    public int Difficulty;

    public Book(string title, string desc, string pubDate, int pages, int diff)
    {
        Title = title;
        Description = desc;
        PublishingDate = pubDate;
        Pages = pages;
        Difficulty = diff;
    }

    public override string ToString()
    {
        return $"Title           : {Title}\nDescription     : {Description}\nPublishing date : {PublishingDate}\nPages           : {Pages}\nDifficulty      : {Difficulty}";
    }
}