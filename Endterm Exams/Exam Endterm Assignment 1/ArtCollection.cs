class ArtCollection<T> where T : Valuable, ICreator
{
    public readonly List<T> Collection = [];
    public void Add(T p) => Collection.Add(p);

    public void PrintCollection()
    {
        foreach (T item in Collection) {
            Console.WriteLine($"{item.Name} by {item.CreatorName} (value: {item.Value})");
        }
    }
}