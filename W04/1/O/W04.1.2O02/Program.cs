//Import the JSON package that we are going to need for this Assignment
using System.Collections;
using Newtonsoft.Json;

public class Program {

    

    static void Main () {
        //This will be the name of the JSON file we are going to use
        string fileName = "BookCollection.json";
        //This will keep track if the user has quit the program
        bool quit = false;
        //We will continue going in this while loop until the user exits the program
        while (!quit) {
            //Retrieve our current library and put it into the CurrLibrary variable
            List<Book> CurrLibrary = GetLibrary(fileName);
            //This will print all the books in our JSON file
            PrintBookCollection(CurrLibrary);
            //Print some spacing between our Library and Menu
            Console.WriteLine(" ");
            //Print the menu
            PrintMenu();
            //Request an input from the user
            string str_choice = Console.ReadLine();
            //We check if the choice a user has made is a integer so that we can use this to index through our JSON
            if (int.TryParse(str_choice, out int int_choice)) {
                
            } else {
                //If the user didn't input a integer then we are going to check with a Switch Statement that we
                //received an input that we expect so "+", "-" or "q" if we don't receive any then we print
                //an error message
                switch (str_choice.ToLower()) {
                    case "+":
                        AddBook(fileName, CurrLibrary);
                        break;
                    case "-":
                        RemoveBook(fileName, CurrLibrary);
                        break;
                    case "q":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.\n");
                        break;
                }
            }
        }
    }

    public static void PrintBookCollection(List<Book> library) {
        int index = 1;
        foreach (Book book in library) {
            Console.WriteLine($"{index}. {book.Info()}");
            index++;
        }
    }

    public static void PrintMenu() {
        string menu = "What would you like to do?\n+: add a new book\n-: remove a book\nA number: see information on this book\nq: quit";
        Console.WriteLine(menu);
    }

    public static void AddBook(string fileName, List<Book> library) {
        string questionOne = "Enter the title of the new book:";
        string questionTwo = "Enter the author of the new book:";
        string questionThree = "Enter the publication year of the new book:";
        string errorMessage = "Year is not in a valid format.";

        Console.WriteLine(questionOne);
        string responseQuestionOne = Console.ReadLine();
        Console.WriteLine(questionTwo);
        string responseQuestionTwo = Console.ReadLine();
        Console.WriteLine(questionThree);
        string responseQuestionThree = Console.ReadLine();

        if (YearCheck(responseQuestionThree)) {
            library.Add(new(responseQuestionOne, responseQuestionTwo, Convert.ToInt32(responseQuestionThree)));
            WriteToJSON(fileName, library);
        } else {
            Console.WriteLine(errorMessage);
        }
    }

    public static void RemoveBook(string fileName, List<Book> library) {
        string questionOne = "Enter the number of the book to remove:";
        string errorMessage_NotIndex = "Not an index.";
        string errorMessage_BookDoesNotExist = "Book does not exist.";

        Console.WriteLine(questionOne);
        string responseQuestionOne = Console.ReadLine();
        if (int.TryParse(responseQuestionOne, out int value)) {
            if (value <= (library.Count() - 1) & value > 0) {
                Book selectedBook = library[value - 1];
                List<Book> edited_library = [];
                foreach (Book book in library) {
                    if (book != selectedBook) {
                        edited_library.Add(book);
                    }
                }
                WriteToJSON(fileName, edited_library);
                Console.WriteLine("Book removed.");
            } else {
                Console.WriteLine(errorMessage_BookDoesNotExist);
            }
        } else {
            Console.WriteLine(errorMessage_NotIndex);
        }
    }

    //This function can be used to see if our inputted year is a valid integer
    public static bool YearCheck(string input) => int.TryParse(input, out int year);

    //This function can be used to read values from our JSON file
    public static string ReadFromJSON (string fileName) {
        StreamReader reader = new StreamReader(fileName);
        string jsonString = reader.ReadToEnd();
        reader.Close();
        return jsonString;
    }

    //This function can be used to write values to our JSON file
    public static void WriteToJSON (string fileName, object valueToWrite) {
        StreamWriter writer = new(fileName);
        writer.Write(JsonConvert.SerializeObject(valueToWrite));
        writer.Close();
    }

    //This function retrievs and converts our List of Books from our JSON file and returns the resulting List<Book>
    public static List<Book> GetLibrary (string fileName) => JsonConvert.DeserializeObject<List<Book>>(ReadFromJSON(fileName))!;
}