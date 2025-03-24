static class Program
{
    static void Main()
    {
        // Create the dictionary here
        Dictionary<string, double> groceryPrices = new() {
            { "Milk", 1.49 },
            { "Bread", 0.99 },
            { "Eggs", 2.99 },
            { "Butter", 3.49 }
        };

        Console.WriteLine("Available products:");
        foreach (string product in groceryPrices.Keys)
        {
            Console.WriteLine($" - {product}");
        }

        Console.Write("\nEnter the name of the product to view its price: ");
        string item = Console.ReadLine()!;

        if (groceryPrices.ContainsKey(item)) // If the given product is in the keys of the dictionary...
        {
            Console.WriteLine($"The price of {item} is {groceryPrices[item]}"); // ... print its price
        }
        else
        {
            Console.WriteLine("Item not found");
        }
    }
}