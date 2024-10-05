//After we made our ShopItem we can create the GroupedShopItem class
public class GroupedShopItem {
    //We start by creating two variables.
    //Item for the ShopItem we want to be grouped with the Class object
    public ShopItem Item;
    //And Quantity for the Quantity of this item
    public int Quantity;

    //In its constructor we Assign the item field the inputted item and set the Quantity to 1 (by default)
    public GroupedShopItem(ShopItem item) {
        Item = item;
        Quantity = 1;
    }
}