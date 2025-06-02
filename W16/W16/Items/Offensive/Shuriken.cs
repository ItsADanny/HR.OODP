class Shuriken : Item
{
    public Damage MyDamage { get; } = new(DamageTypes.Physical, 25, true, false, false);

    public Shuriken() : base("Shuriken", ItemTypes.Shuriken, TargetTypes.Single) { }

    public override bool PerformUse(ITargetable user, ITargetable[] targets)
    {
        CombatManager.ProcessDamage(user, targets[0], MyDamage);
        return true;
    }
}
