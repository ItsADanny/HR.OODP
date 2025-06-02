using Newtonsoft.Json;

public static class InventoryManager
{
    // Class: InventoryManager

    // Add the following static methods to this class:
    // * DetectLowInventory(List<Plant> inventory): returns a List<Plant> 
    //   containing all plants in inventory with a Stock below 5. Results need to be in ascending order.
    //
    // * SearchByCategory(List<Plant> inventory, string category): returns a List<Plant> 
    //   containing all plants in inventory from the provided category.

    // * LastSoldItems(List<Plant> inventory): returns a List<Plant> 
    //   containing all plants that have been sold on the last day on which there were sales.

    // * PotentialRemoval(List<Plant> inventory): returns a List<Plant> 
    //   containing all plants that have not been sold in over 365 days and have a Stock of at least 10 or more.

    // All methods should be solved using LINQ.

    public static List<Plant> ReadInventory(string dataset)
    {
        string jsonString = File.ReadAllText(dataset);
        return JsonConvert.DeserializeObject<List<Plant>>(jsonString)!;
    }

    public static List<Plant> DetectLowInventory(List<Plant> inventory) => inventory.Where(p => p.Stock < 5).OrderBy(p => p.Stock).ToList();

    public static List<Plant> SearchByCategory(List<Plant> inventory, string category) => inventory.Where(p => p.Category == category).ToList();

    public static List<Plant> LastSoldItems(List<Plant> inventory) => inventory.Where(p => p.LastSold == inventory.Max(p => p.LastSold)).ToList();

    public static List<Plant> PotentialRemoval(List<Plant> inventory) => inventory.Where(p => (p.LastSold.DayNumber - DateOnly.FromDateTime(DateTime.Now).DayNumber) > 365 && p.Stock >= 10).ToList();
}