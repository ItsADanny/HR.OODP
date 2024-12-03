class Program
{
    public static void Main()
    {
        var db = new DbManager();
        //This call to the Reassign method must be removed
        // db.Reassign("Reassign outside constructor");

        Console.WriteLine($"Current connection: {db.Connection}");
    }
}