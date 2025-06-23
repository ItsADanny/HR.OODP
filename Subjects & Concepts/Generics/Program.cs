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
public class Home<T> where T : IAnimal, new()
{
    public List<T> animals;
    public void Add(T animal)
    {
        animals.Add(animal);
    }
}

//For a better understanding of Generics it is highly recommended to follow the OODP Course guide and do the assignments.
//It does a better job of explaining Generics than i personally can.

//================================================================================================================================================================================
public interface IAnimal
{
    string Name { get; set; }
    string Sound { get; set; }
    void MakeSound();
}