public class Program
{
    public static void Main()
    {
        Season season = new Season();

        Console.WriteLine("===============================================");
        season.Print();
        season.PrintNL();
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine("Moving to the next season");
            season.Next();
            season.Print();
            season.PrintNL();
            Console.WriteLine("-----------------------------------------------");
        }
        Console.WriteLine("===============================================");
        season.PrintAll();
        season.PrintAllIntegerValues();
        Console.WriteLine("-----------------------------------------------");
        season.PrintAllNL();
        season.PrintAllIntegerValuesNL();
        Console.WriteLine("===============================================");
    }
}

public enum eSeason
{
    spring, //0
    summer, //1
    autumn, //2
    winter  //3
}

public enum eSeizoen
{
    //If we want to assign the values to a certain enum value we can also do that (Default starting position is 0)
    lente = 1,
    zomer = 2,
    herfst = 3,
    winter = 4
}

public class Season
{
    //To initialize a Enum as its default value we can simply use "new [NAME OF THE ENUM]()"
    private eSeason _season = new eSeason();

    public void Next()
    {
        //We perform a check to see if we haven't reached to highest value
        if (_season != eSeason.winter)
        {
            //If not, then we increase our position easily by adding 1 to our enum value
            _season++;
        }
        else
        {
            //If so, Reset it to spring
            _season = eSeason.spring;
        }
    }

    public void Print()
    {
        //To get the integer position of our current enum value we can just simply cast it to int
        Console.WriteLine($"Current season: {_season} ({(int)_season})");

        //Example output:
        // Current season: Winter (3)
    }

    public void PrintNL()
    {
        //To use an integer to get a value from an enum we can just simply cast the integer into our enum like below
        int enumPos = (int)_season;
        Console.WriteLine($"Huidig seizoen: {(eSeizoen)enumPos + 1} ({enumPos+1})");

        //Example output:
        // Huidig seizoen: Zomer (2)
    }

    public void PrintAll()
    {
        Console.WriteLine("All the seasons in eSeason");
        foreach (eSeason season in Enum.GetValues(typeof(eSeason)))
        {
            Console.WriteLine("- " + season);
        }
    }

    public void PrintAllNL()
    {
        Console.WriteLine("Alle seizoenen in eSeizoen");
        foreach (eSeizoen seizoen in Enum.GetValues(typeof(eSeizoen)))
        {
            Console.WriteLine("- " + seizoen);
        }
    }
    
    public void PrintAllIntegerValues()
    {
        Console.WriteLine("All the seasons in eSeason");
        foreach (int season in Enum.GetValues(typeof(eSeason)))
        {
            Console.WriteLine("- " + season);
        }
    }

    public void PrintAllIntegerValuesNL()
    {
        Console.WriteLine("Alle seizoenen integers in eSeizoen");
        foreach (int seizoen in Enum.GetValues(typeof(eSeizoen)))
        {
            Console.WriteLine("- " + seizoen);
        }
    }
}