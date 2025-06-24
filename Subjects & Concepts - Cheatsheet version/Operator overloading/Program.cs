public class Program
{
    public static void Main()
    {
        //DEMO DATA
        Food Burger = new Food("Burger", "A Burger with a angus beef patty", 6.50, 7);
        Food MilkShake = new Food("MilkShake", "A Great tasting milkshake", 3.5, 7);
        Food Taco = new Food("Taco", "A Freshly made Taco with alot of spices", 4.5, 7);
        Food HariboBears = new Food("Haribo Bears", "Delicouse gelatin based candy bears with alot of fun colors", 2.5, 21);
        Food Burger2 = new Food("Burger", "A Burger with a beef patty", 6.50, 7);
        Food? NullBurger = null;
        Food? NullBurger2 = null;

        //DEMO WORKING OVERLOAD RESULTS
        Console.WriteLine("=============================================================");
        Console.WriteLine("DEMO RESULTS - OPERATOR OVERLOADING ==");
        Console.WriteLine("=============================================================");
        Console.WriteLine($"Burger     == MilkShake    : {Burger == MilkShake}");        //False
        Console.WriteLine($"Burger     == Taco         : {Burger == Taco}");             //False
        Console.WriteLine($"Burger     == HariboBears  : {Burger == HariboBears}");      //False
        Console.WriteLine($"Burger     == Burger2      : {Burger == Burger2}");          //True
        Console.WriteLine($"Burger     == NullBurger   : {Burger == NullBurger}");       //False
        Console.WriteLine($"NullBurger == NullBurger2  : {NullBurger == NullBurger2}");  //True
        Console.WriteLine("\n=============================================================");
        Console.WriteLine("DEMO RESULTS - OPERATOR OVERLOADING !=");
        Console.WriteLine("=============================================================");
        Console.WriteLine($"Burger     != MilkShake    : {Burger != MilkShake}");        //True
        Console.WriteLine($"Burger     != Taco         : {Burger != Taco}");             //True
        Console.WriteLine($"Burger     != HariboBears  : {Burger != HariboBears}");      //True
        Console.WriteLine($"Burger     != Burger2      : {Burger != Burger2}");          //False
        Console.WriteLine($"Burger     != NullBurger   : {Burger != NullBurger}");       //True
        Console.WriteLine($"NullBurger != NullBurger2  : {NullBurger != NullBurger2}");  //False
        Console.WriteLine("\n=============================================================");
        Console.WriteLine("DEMO RESULTS - OPERATOR OVERLOADING >");
        Console.WriteLine("=============================================================");
        Console.WriteLine($"Burger     > MilkShake    : {Burger > MilkShake}");        //True
        Console.WriteLine($"Burger     > Taco         : {Burger > Taco}");             //True
        Console.WriteLine($"Burger     > HariboBears  : {Burger > HariboBears}");      //True
        Console.WriteLine($"Burger     > Burger2      : {Burger > Burger2}");          //False
        Console.WriteLine($"Burger     > NullBurger   : {Burger > NullBurger}");       //True
        Console.WriteLine($"NullBurger > NullBurger2  : {NullBurger > NullBurger2}");  //False
        Console.WriteLine("\n=============================================================");
        Console.WriteLine("DEMO RESULTS - OPERATOR OVERLOADING <");
        Console.WriteLine("=============================================================");
        Console.WriteLine($"Burger     < MilkShake    : {Burger < MilkShake}");        //False
        Console.WriteLine($"Burger     < Taco         : {Burger < Taco}");             //False
        Console.WriteLine($"Burger     < HariboBears  : {Burger < HariboBears}");      //False
        Console.WriteLine($"Burger     < Burger2      : {Burger < Burger2}");          //False
        Console.WriteLine($"Burger     < NullBurger   : {Burger < NullBurger}");       //False
        Console.WriteLine($"NullBurger < Burger       : {NullBurger < Burger}");       //True
        Console.WriteLine($"NullBurger < NullBurger2  : {NullBurger < NullBurger2}");  //False
    }
}

public class Food
{
    public string Name { get; }
    public string Description { get; }
    public double Price;
    public double Tax
    {
        get
        {
            return Price / 100 * _taxPercentage;
        }
    }
    private double _taxPercentage;

    public Food(string name, string description, double price, double taxPercentage)
    {
        Name = name;
        Description = description;
        Price = price;
        _taxPercentage = taxPercentage;
    }



    //THIS WILL APPEAR ON THE CHEATSHEET
    //============================================================================================================
    public static bool operator ==(Food? item1, Food? item2) {
        if (item1 is null && item2 is null) return true;
        if (item1 is not null && item2 is null || item1 is null && item2 is not null) return false;
        return item1.Name == item2.Name && item1.Price == item2.Price;
    }
    //============================================================================================================

    //Overloading operator !=
    public static bool operator !=(Food? item1, Food? item2)
    {
        //We can customize which fields we want to use to make a negative comparison on
        if (item1 is null && item2 is null) return false;
        if (item1 is not null && item2 is null || item1 is null && item2 is not null) return true;
        return item1.Name != item2.Name && item1.Price != item2.Price;
    }

    //Overloading operator >
    public static bool operator >(Food? item1, Food? item2)
    {
        //We can customize which field we want to use to make a Greater than comparison on
        if (item1 is null && item2 is null) return false;
        if (item1 is not null && item2 is null) return true;
        return item1.Price > item2.Price;
    }

    //Overloading operator <
    public static bool operator <(Food? item1, Food? item2)
    {
        //We can customize which field we want to use to make a Lesser than comparison on
        if (item1 is null && item2 is null) return false;
        if (item1 is null && item2 is not null) return true;
        if (item1 is not null && item2 is null) return false;
        return item1.Price < item2.Price;
    }
}