static class Program
{
    static void Main()
    {
        DatabaseManager dbm = new();
        //This call to the Reassign method must be removed
        //dbm.Reassign("Reassign outside constructor");

        Console.WriteLine($"Current connection: {dbm.Connection}");
    }
}