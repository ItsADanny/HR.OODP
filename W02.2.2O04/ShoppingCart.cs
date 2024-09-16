public class ShoppingCart {

    public List<GroupedShopItem> Groceries;

    public ShoppingCart() {
        Groceries = new List<GroupedShopItem>();
    }

    public void AddItem(ShopItem shopitem) {
        List<GroupedShopItem> edited_list = new List<GroupedShopItem>();
        foreach (GroupedShopItem grocerie in Groceries) {
            if (shopitem.Name == grocerie.Item.Name) {
                grocerie.Quantity++;
            }
            edited_list.Add(grocerie);
        }
        Groceries = edited_list;
    }

    public GroupedShopItem FindItem(ShopItem shopitem) {
        foreach (GroupedShopItem grocerie in Groceries) {
            if (shopitem.ID == grocerie.Item.ID) {
                return grocerie;
            }
        }
        return null;
    }

    public string Contents() {
        string str_returnValue = "";
        foreach (GroupedShopItem grocerie in Groceries) {
            str_returnValue += $"{grocerie.Item.Name} x {grocerie.Quantity}\n";
        }
        return str_returnValue;
    }

    public double TotalPrice() {
        double double_returnValue = 0.0;
        foreach (GroupedShopItem grocerie in Groceries) {
            double_returnValue += grocerie.Quantity * grocerie.Item.Price;
        }
        return double_returnValue;
    }

}