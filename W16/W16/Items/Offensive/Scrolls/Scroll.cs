abstract class Scroll : Item
{
    public abstract Damage MyDamage { get; }

    public Scroll(string element, ItemTypes type)
        : base(element + " Scroll", type, TargetTypes.Multi) { }

    public override bool PerformUse(ITargetable user, ITargetable[] targets)
    {
        Console.WriteLine($"{user.Name} used {Name}!");
        foreach (var target in targets)
            CombatManager.ProcessDamage(user, target, MyDamage);
        return true;
    }
}
