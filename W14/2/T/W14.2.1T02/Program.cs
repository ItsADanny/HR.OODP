public class Program
{
    public static void Main()
    {
        string[] persons = { "Dave", "John", "Peter", "Johanna", "Bart", "Henk", "Marie" };
        string[] students = { "Dave", "Michael", "Roxanne", "Johanna", "John", "Bart", "Henk" };

        Console.WriteLine("These names are in both datasets:");
        // Missing from the template, but is the most important part that will be checked:
        // Print a list of all names that occur in both datasets
        string[] matched = persons.Intersect(students).ToArray();
        Print(matched);

        Console.WriteLine("\nThese names are unique:");
        // Missing from the template, but is the most important part that will be checked:
        // Print a list of all distinct names from both datasets, in alphabetical order
        string[] unique = persons.Union(students).Distinct().OrderBy(n => n).ToArray();
        Print(unique);
    }

    public static void Print(string[] data)
    {
        foreach (string text in data) {
            Console.WriteLine(text);
        }
    }
}