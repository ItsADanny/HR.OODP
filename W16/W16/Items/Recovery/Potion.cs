class Potion : Item
{
    public Potion() : 
        base("Potion", ItemTypes.Potion, TargetTypes.Single) { }

    public override bool PerformUse(ITargetable user, ITargetable[] targets)
    {
        if (targets[0] is not Fighter fighter)
            return false;
        fighter.Heal(100);
        return true;
    }
}
