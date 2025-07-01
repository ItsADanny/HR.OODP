class Van
{
    public VanCapacity Capacity {get; set;}
    public Stack<Furniture> Contents {get; set;}
    public int UsedVolume {get; set;}

    public Van(VanCapacity capacity)
    {
       Capacity = capacity;
       Contents = new Stack<Furniture>();
       UsedVolume = 0;
    }

    public bool Load(Furniture furniture)
    {
        if (furniture.Volume + UsedVolume <= (int) Capacity) {
            Contents.Push(furniture);
            UsedVolume += furniture.Volume;
            return true;
        }
        return false;
    }

    public List<Furniture> Unload()
    {
        List<Furniture> returnValue = new List<Furniture>();
        while (Contents.Count != 0) {
            Furniture currentItem = Contents.Peek();
            UsedVolume -= currentItem.Volume;
            returnValue.Add(currentItem);
            Contents.Pop();
        }

        return returnValue;
    }

    public override string ToString()
    {
        string contentOfVan = "";
        foreach (Furniture item in Contents) {
            if (contentOfVan != "") {
                contentOfVan += " ";
            }
            contentOfVan += item.Name;
        }

        return  $"Capacity: {(int) Capacity}\n" +
                $"Used: {UsedVolume}\n" +
                $"Contents: {contentOfVan}";
    }
}