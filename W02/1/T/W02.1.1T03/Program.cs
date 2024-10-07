class Program {
    public static void Main() {
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        DisplayName(firstName, lastName);
    }

    public static string Name(string firstName, string lastName) => $"{firstName} {lastName}";

    public static void DisplayName(string firstName, string lastName) => Console.WriteLine(Name(firstName, lastName));
}