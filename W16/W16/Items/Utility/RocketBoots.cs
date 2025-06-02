class RocketBoots : Item
{
    public RocketBoots() : 
        base("Rocket Boots", ItemTypes.RocketBoots, TargetTypes.Self) { }

    public override bool PerformUse(ITargetable user, ITargetable[] targets)
    {
        Console.WriteLine("Jumping to safety...");
        return true;
    }
}
