public static class Shop {
    public static readonly List<Item> Inventory = new List<Item>();
    public const int MaxItemQuantity = 5;

    public static void AddItemToInventory(Item item) {
        if (item is not null) {
            bool itemAlreadyExists = false;
            foreach (Item shopItem in Inventory) {
                if (shopItem.Name == item.Name && shopItem.Quantity == item.Quantity) {
                    itemAlreadyExists = true;
                }
            }

            if (itemAlreadyExists) {
                Console.WriteLine("Already in inventory");
            } else {
                if (item.Quantity > MaxItemQuantity) {
                    Console.WriteLine("Max item quantity reached");
                } else {
                    Inventory.Add(item);
                }
            }
        } else {
            Console.WriteLine("Not a valid item");
        }
    }

    public static Item? BuyItem(string name, int quantity, double amountPaid) {
        Item? returnValue = null;
        
        foreach (Item shopItem in Inventory) {
            if (shopItem.Name == name && shopItem.Quantity == quantity && shopItem.GetTotalPrice() == amountPaid) {
                returnValue = shopItem;
            }
        }

        return returnValue;
    } 
}