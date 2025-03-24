static class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "ShopItem": TestShopItem(); return;
            case "GroupedShopItem": TestGroupedShopItem(); return;
            case "Cart": TestShoppingCart(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }
    
    static void TestShopItem()
    {
        List<ShopItem> shopItems = [
            new("001A", "Bread", 3.50),
            new("001B", "Bread", 3.50),
            new("002A", "Skimmed milk", 1.85),
            new("002B", "Whole milk", 1.95),
            new("003A", "Sugar", 0.99),
        ];
        foreach (var item in shopItems)
        {
            Console.WriteLine($"{item.ID} {item.Name} {item.Price}");
        }
    }
    
    static void TestGroupedShopItem()
    {
        List<GroupedShopItem> gItems = [
            new GroupedShopItem(new ShopItem("0", "A", 0.5)),
            new GroupedShopItem(new ShopItem("1", "B", 1.5)),
            new GroupedShopItem(new ShopItem("2", "C", 2.5)),
        ];
        foreach (var gItem in gItems)
        {
            Console.WriteLine($"{gItem.Item.ID} {gItem.Item.Name} {gItem.Quantity}");
        }
    }
    
    static void TestShoppingCart()
    {
        ShopItem bread1 = new("001A", "Bread", 3.50);
        ShopItem bread2 = new("001B", "Bread", 3.50);
        ShopItem milk = new("002A", "Milk", 1.85);
        ShopItem sugar = new("003A", "Sugar", 0.99);

        ShoppingCart cart = new();

        cart.AddItem(milk);
        for (int i = 0; i < 3; i++)
        {
            cart.AddItem(bread1);
        }
        
        cart.AddItem(sugar);
        cart.AddItem(bread2);

        var gItem1 = cart.FindItem(new ShopItem("NONE", "Not existant", 0.0));
        var gItem2 = cart.FindItem(bread1);
        var gItem3 = cart.FindItem(bread2);
        foreach (var gItem in new GroupedShopItem[] { gItem1, gItem2, gItem3 })
        {
            Console.WriteLine(gItem == null ? "Not found" : $"{gItem.Item.ID} {gItem.Item.Name} {gItem.Item.Price}");
        }

        Console.WriteLine(cart.GetContentsOverview());
        Console.WriteLine(cart.GetTotalPrice());
    }
}