class House
{
    public string Address { get; private set; }
    public readonly List<Furniture> FurnitureList;

    public House(string address, List<Furniture> furnitureList)
    {
        Address = address;
        FurnitureList = furnitureList;
    }

    public int TotalInsuredValue()
    {
        return 0; // Replace with your logic
    }

    public List<Furniture>? GetFurnitureAboveValue(int value)
    {
        return null; // Replace with your logic
    }
}
