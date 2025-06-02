class HighPotion : Item
{
    public HighPotion() :
        base("High Potion", ItemTypes.HighPotion, TargetTypes.Single) { }

    public override bool PerformUse(ITargetable user, ITargetable[] targets)
    {
        if (targets[0] is not Fighter fighter)
            return false;
        fighter.Heal(fighter.MaxHP);
        return true;
    }
}
