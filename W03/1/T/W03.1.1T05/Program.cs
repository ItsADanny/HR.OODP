class Program
{
    public static void Main()
    {
        Console.WriteLine("What is your first name?");
        var firstName = Console.ReadLine();
        Console.WriteLine("What is your last name?");
        var lastName = Console.ReadLine();

        var fullName = FullName(firstName, lastName);
        Console.WriteLine(fullName);
    }

    //To fix the problem just add static in between public and string
    public static string FullName(string fName, string lName) => $"{fName} {lName}";
    // public string FullName(string fName, string lName) => $"{fName} {lName}"; //ORIGINAL
}