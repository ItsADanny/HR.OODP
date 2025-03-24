static class Program
{
    static void Main()
    {
        Console.WriteLine("What is your first name?");
        string? firstName = Console.ReadLine();
        Console.WriteLine("What is your last name?");
        string? lastName = Console.ReadLine();

        string? fullName = GetFullName(firstName, lastName);
        Console.WriteLine(fullName);
    }

    //To fix the problem just add static in between public and string
    public static string? GetFullName(string? fName, string? lName) => $"{fName} {lName}";
    // public string? GetFullName(string? fName, string? lName) => $"{fName} {lName}"; //ORIGINAL
}