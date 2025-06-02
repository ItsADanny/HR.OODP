public class Program
{
    public static void Main()
    {
        //This is not part of the class exercise, but this can be used to test the code and display the results
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
        //Check to see if our maximum value is reached
        if (input == Season.Autumn)
        {
            //If so return it to the first value (Winter)
            return Season.Winter;
        }
        //If it isn't our maximum value, then increase our input Season and return it
        return input++;
    }

    public static void PrintAllSeasons()
    {
        //Get all the values from our Enum Season
        foreach (var season in Enum.GetValues(typeof(Season)))
        {
            //Print the value of our Enum per value
            Console.WriteLine($"({(int)season}) : {season}");
        }
    }

    public static string SeasonFeeling(Season input)
    {
        //Switch expression that takes our inputted Season and returns a string based on its current value
        return input switch
        {
            Season.Winter => "Cold",
            Season.Spring => "Cool",
            Season.Summer => "Hot",
            Season.Autumn => "Mild",
            _ => "No valid data inputted"
        };

        //Switch statement version
        // switch (input)
        // {
        //     case Season.Winter:
        //         return "Cold";
        //     case Season.Spring:
        //         return "Cool";
        //     case Season.Summer:
        //         return "Hot";
        //     case Season.Autumn:
        //         return "Mild";
        //     default:
        //         return "No valid data inputted";
        // }
    }
}