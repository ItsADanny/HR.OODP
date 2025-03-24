static class Program
{
    static void Main()
    {
        Console.Write("What is the client's name? ");
        string clientName = Console.ReadLine()!;
        Console.Write("What is date of the appointment? ");
        string date = Console.ReadLine()!;
        Console.Write("What is the time of the appointment? ");
        string time = Console.ReadLine()!;
        Console.Write("What is the company's name? ");
        string companyName = Console.ReadLine()!;

        string template = $"Dear {clientName},\n\nThank you for booking an appointment on {date}.\nWe look forward to seeing you at {time}.\n\nBest regards,\n{companyName}";

        Console.WriteLine(template);
    }
}