public class Program {
    public static void Main() {
        MenuAccess menuAccess = new MenuAccess();
        
        List<FoodItem> foodItems = menuAccess.GetFoodItems();
        foreach (FoodItem item in foodItems) {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("Adding a new menu item");
        FoodItem KipKerrieBroodje = new FoodItem(1, "Kip Kerrie Broodje", "Een lekker kip kerrie broodje", 3);
        menuAccess.Write(KipKerrieBroodje);

        List<FoodItem> foodItems2 = menuAccess.GetFoodItems();
        foreach (FoodItem item in foodItems2) {
            Console.WriteLine(item.ToString());
        }
    }
}