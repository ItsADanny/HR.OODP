using System.Collections;

public class Program
{
    public static void Main()
    {
        Collection<String> FruitCollection = new Collection<string>(5);

        FruitCollection.Add("Apple");
        FruitCollection.Add("Pear");
        FruitCollection.Add("Kiwi");
        FruitCollection.Add("Banana");
        FruitCollection.Add("Pineapple");
        FruitCollection.Add("Orange"); //This will result in an message to be printed since we said that we can only have 5 items in our "Collection"

        //Because of IEnumerable we can just iterate with over our Collection object and retrieve the results from it.
        foreach (string Fruit in FruitCollection)
        {
            Console.WriteLine(Fruit);
        }
    }
}

public class Collection<T> : IEnumerable<T>
{
    //With IEnumerable we can define a sequence that can be iterated over.

    private T[] _items;
    private int _count;

    public Collection(int size)
    {
        _items = new T[size];
        _count = 0;
    }

    public void Add(T data)
    {
        if (_count < _items.Length)
        {
            _items[_count] = data;
            _count++;
        }
        else
        {
            Console.WriteLine("Max items in Collection reached");
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}