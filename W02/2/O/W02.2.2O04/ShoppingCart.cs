//After we made the ShopItem and GroupedShopItem, we can make the ShoppingCart Object
public class ShoppingCart {
    //We start by making a List for GroupedShopItems called Groceries
    public List<GroupedShopItem> Groceries;

    //When calling the ShoppingCart constructor we initialize the Groceries List with an empty List
    public ShoppingCart() {
        Groceries = new List<GroupedShopItem>();
    }

    //This method makes it possible to add or increase an item in our shoppingCart object
    public void AddItem(ShopItem shopitem) {
        //We make a boolean which we will use to see if the Item is already in the Groceries list
        bool itemAlreadyExists = false;
        //We then make a list in which we will store our updated Groceries list
        List<GroupedShopItem> edited_list = new List<GroupedShopItem>();
        //We Iterate through the GroupedShopItems in the Groceries
        foreach (GroupedShopItem grocerie in Groceries) {
            //If the item does exist we update the bool to true and increase the quantity of the item.
            if (shopitem.Name == grocerie.Item.Name && shopitem.ID == grocerie.Item.ID) {
                itemAlreadyExists = true;
                grocerie.Quantity++;
            }
            //We then add the item to our new edited list
            edited_list.Add(grocerie);
        }
        //if we see that this item isn't a GroupItem already then we create a new GroupedShopItem
        //and add it to the edited_list
        if (!itemAlreadyExists) {
            edited_list.Add(new(shopitem));
        }
        //And finally we set the edited_list in the Groceries variable
        Groceries = edited_list;
    }

    //This method makes it possible to find a certain item in our shopping cart and returns the GroupShopItem
    //for the inputted item
    public GroupedShopItem FindItem(ShopItem shopitem) {
        //We iterate through the Groceries list, one by one
        foreach (GroupedShopItem grocerie in Groceries) {
            //If the ID's of the items link up then we return this GroupShopItem
            if (shopitem.ID == grocerie.Item.ID) {
                return grocerie;
            }
        }
        //If we can't find a matching item then we return a null value
        return null;
     }

    //This function returns a string with all the items in the shoppingCart and their quantities
    public string GetContentsOverview() {
        //First we declare a string variable with return values
        string str_returnValue = "";
        //We iterate through the GroupShopItems in our ShoppingCart and add to the end of our string
        //The name of the item and the quantity in our Cart
        foreach (GroupedShopItem grocerie in Groceries) {
            str_returnValue += $"{grocerie.Item.Name} x {grocerie.Quantity}\n";
        }
        //Finally we return the string
        return str_returnValue;
    }

    //This function returns the total price of our shopping cart
    public double GetTotalPrice() {
        //We first declare an double with a default value of 0.0
        double double_returnValue = 0.0;
        //We iterate through the GroupItems and we times the Quantity with the Price of the Item
        //And add it up to our total
        foreach (GroupedShopItem grocerie in Groceries) {
            double_returnValue += grocerie.Quantity * grocerie.Item.Price;
        }
        //Finally we return the total
        return double_returnValue;
    }

}