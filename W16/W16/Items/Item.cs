abstract class Item
{
    public string Name { get; }
    public ItemTypes MyType { get; }
    public TargetTypes CanTarget { get; }

    public Item(string name, ItemTypes myType, TargetTypes canTarget)
    {
        Name = name;
        MyType = myType;
        CanTarget = canTarget;
    }

    public bool UseMe(ITargetable user, ITargetable[] targets)
    {
        if (!IsValidTarget(user, targets))
        {
            return false;
        }
        return PerformUse(user, targets);
    }

    private bool IsValidTarget(ITargetable user, ITargetable[] targets) => CanTarget switch
    {
        TargetTypes.Self => targets.Length == 1 && targets[0] == user,
        TargetTypes.Single => targets.Length == 1,
        TargetTypes.Multi => targets.Length >= 1,
        _ => throw new ArgumentException("Invalid target")
    };

    public abstract bool PerformUse(ITargetable user, ITargetable[] targets);
}
