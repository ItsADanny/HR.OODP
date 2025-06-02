enum ItemTypes
{
    Potion,
    HighPotion,
    Shuriken,
    FireScroll,
    IceScroll,
    LightningScroll,
    Grenade,
    RocketBoots
}

static class ItemFactory
{
    public static Item? GetItem(ItemTypes itemType) => itemType switch
    {
        ItemTypes.Potion => new Potion(),
        ItemTypes.HighPotion => new HighPotion(),
        ItemTypes.Shuriken => new Shuriken(),
        ItemTypes.FireScroll => new FireScroll(),
        ItemTypes.IceScroll => new IceScroll(),
        ItemTypes.LightningScroll => new LightningScroll(),
        ItemTypes.Grenade => new Grenade(),
        ItemTypes.RocketBoots => new RocketBoots(),
        _ => throw new ArgumentException($"Unknown item: {itemType}"),
    };
}
