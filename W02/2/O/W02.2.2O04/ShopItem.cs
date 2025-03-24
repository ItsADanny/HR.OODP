//We start by Creating a class with the name ShopItem
public class ShopItem {
    //This item will have 3 variables in which we store the ID, the name and the price of the ShopItem object
    public string ID;
    public string Name;
    public double Price;

    //In its constructor we Assign the inputted ID, Name and Price to the ID, Name and Price of
    //the ShopItem object
    public ShopItem(string str_id, string str_name, double dbl_price) {
        ID = str_id;
        Name = str_name;
        Price = dbl_price;
    }
}