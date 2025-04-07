public class FoodItem {
    public Int64 ID;
    public string Name;
    public string Description;
    public Int64 Price;

    public FoodItem(Int64 id, string name, string description, Int64 price) {
        ID = id;
        Name = name;
        Description = description;
        Price = price;
    }

    public override string ToString()
    {
        return $"ID: {ID}\nName: {Name}\nDescription: {Description}\nPrice: {Price}\n===================================";
    }
}