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
        List<Furniture> insuredItems = FurnitureList.Where(f => f.IsInsured == true).ToList();
        int returnValue = 0;

        foreach (Furniture item in insuredItems)
        {
            returnValue += item.Value;
        }

        return returnValue;
    }

    public List<Furniture>? GetFurnitureAboveValue(int value)
    {
        List<Furniture>? returnValue = FurnitureList.Where(f => f.Value > value).OrderBy(f => f.Value).OrderBy(f => f.IsInsured).ToList();
        return returnValue;
    }
    
}