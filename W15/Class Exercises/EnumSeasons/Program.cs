public class Program
{
    public static void Main()
    {
        Season current = Season.Winter;
        bool Exit = false;
        while (!Exit)
        {
            Console.Clear();
            Console.WriteLine($"The current season is: {current} ({(int)current})\nWhat would you like to do?\n\nN : Next season\nP : Print all season\nF : How does the current season feel\nE : Exit");
            switch (Console.ReadLine().ToUpper())
            {
                case "N":
                    current = GetNextSeason(current);
                    break;
                case "P":
                    PrintAllSeasons();
                    Thread.Sleep(2000);
                    break;
                case "F":
                    Console.WriteLine($"The current season feels: {SeasonFeeling(current)}");
                    Thread.Sleep(2000);
                    break;
                case "E":
                    Exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid response, please try it again");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    public enum Season
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }

    public static Season GetNextSeason(Season input)
    {
        if (input == Season.Autumn)
        {
            return Season.Winter;
        }
        return input++;
    }

    public static void PrintAllSeasons()
    {
        foreach (var season in Enum.GetValues(typeof(Season)))
        {
            Console.WriteLine($"({(int)season}) : {season}");
        }
    }

    public static string SeasonFeeling(Season input)
    {
        return input switch
        {
            Season.Winter => "Cold",
            Season.Spring => "Cool",
            Season.Summer => "Hot",
            Season.Autumn => "Mild",
            _ => "No valid data inputted"
        };
    }
}