static class Program
{
    static void Main()
    {
        Dictionary<string, int> fruitBasket = new() {
            { "Apple", 3 },
            { "Orange", 2 },
            { "Pear", 4 },
        };

        Console.Write("Add what fruit? ");
        string fruitToAdd = Console.ReadLine()!;

        if (fruitBasket.ContainsKey(fruitToAdd)) {
            fruitBasket[fruitToAdd]++;
        } else {
            fruitBasket.Add(fruitToAdd, 1);
        }

        Console.WriteLine("\nFruit count:");
        foreach (string fruit in fruitBasket.Keys)
        {
            Console.WriteLine($" - {fruit}: {fruitBasket[fruit]}");
        }
    }
}