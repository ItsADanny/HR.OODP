public class Program<T> //If the program uses alot of generics then you can add it to the Program class
{
    public static void Main()
    {
        List<Item<T>> items = new List<Item<T>>();

        Item<string> 
    }
}

//GENERIC CLASS
public class Item<T>
{
    public string Name;
    public T Value;

    public Item(string name, T value)
    {
        Name = name;
        Value = value;
    }

    //Basic version of a Generic method
    public static T returnIfValueFound(T value)
    {
        return value;
    }
}

//Generic Interface
public interface IGenericsInterface<T>
{
    void Add(T item);
    void Remove(T item);
}

//Generics constraint with where
//This can be used to make a Generic class but where there a certain classes/interfaces that need to be used to use a method or class
public class Chest<T> where T : IItem, new()
{
    public List<T> StoredItems;
    public void Add(T animal)
    {
        animals.Add(animal);
    }
}

//CLASSES USED FOR THIS DEMO, THERE IS SOME GENERICS GOING ON IN SOME CLASSES BUT THIS IS MORE ADVANCED THEN THEY REQUIRE FROM YOU IN THE ENDTERM
//================================================================================================================================================================================
public interface IEntity {
    public string Name { get; set; }
}

public interface ITree : IEntity
{
    public int X { get; set; }
    public int Y { get; set; }
}

public interface IOre<T> : IEntity
{
    public int X { get; set; }
    public int Y { get; set; }
    public T drop { get; set; }
}

public interface IItem
{
    public string Name { get; set; }
    public int Durability { get; set; }
    public void Use<T>(string playerName, T thing) where T : IEntity; //Sample of a where to constraint a Generic to one that uses the IEntity interface
}

public class Pickaxe : IItem {
    public string Name { get; set; }
    public int Durability { get; set; }
    private int _mined;
    public string mined
    {
        get
        {
            return $"{_mined} have been mined";
        }
    }

    public Pickaxe(string name, int durability)
    {
        Name = name;
        Durability = durability;
    }

    public void Use<T>(string playerName, T thing) where T : IEntity
    {
        Durability--;
        _mined++;
        Console.WriteLine($"{playerName}: used his pickaxe and has decreased duribility to {Durability}");
    }
}

public class Axe : IItem {
    public string Name { get; set; }
    public int Durability { get; set; }
    private int _chopped_oak;
    private int _chopped_birch;
    private int _chopped_spruce;
    private int _chopped_jungle;
    private int _chopped_total {
        get
        {
            return _chopped_oak + _chopped_birch + _chopped_spruce + _chopped_jungle;
        }
    }
    public string chopped
    {
        get
        {
            return $"{_chopped_oak} oak trees have been chopped\n" +
                   $"{_chopped_birch} birch trees have been chopped\n" +
                   $"{_chopped_spruce} spruce trees have been chopped\n" +
                   $"{_chopped_jungle} jungle trees have been chopped\n" +
                   $"Total trees chopped {_chopped_total}";
        }
    }

    public void Use<T>(string playerName, T thing)
    {
        //Check to see if its a tree
        if (typeof(T).IsAssignableTo(typeof(ITree)))
        {
            //If its a tree then we accept it and continue
        }
        else
        {
            //If not then we return an error message
            Console.WriteLine($"{playerName}: Tried to use an axe on {thing.Name}");
        }
    }
}

//Trees
public class OakTree : ITree
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    private Random rnd = new Random();

    public OakTree(int x, int y)
    {
        Name = "Oak tree";
        X = x;
        Y = y;
    }

    public int DropApple()
    {
        int result = rnd.Next(1, 5);
        if (result == 4)
        {
            return 1;
        }
        else if (result == 2)
        {
            return 2;
        }
        return 0;
    }
}

public class BirchTree : ITree {
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public BirchTree(int x, int y)
    {
        Name = "Birch tree";
        X = x;
        Y = y;
    }
}

public class SpruceTree : ITree {
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public SpruceTree(int x, int y)
    {
        Name = "Spruce tree";
        X = x;
        Y = y;
    }
}

public class JungleTree : ITree {
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public JungleTree(int x, int y)
    {
        Name = "Jungle tree";
        X = x;
        Y = y;
    }
}