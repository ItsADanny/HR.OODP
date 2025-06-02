class IceBolt : Spell
{
    public Damage MyDamage => new(DamageTypes.Cold, 10);
    public IceBolt() : base("Ice Bolt", TargetTypes.Single, 3) { }

    protected override bool ApplyEffects(ITargetable caster, ITargetable[] targets)
    {
        CombatManager.ProcessDamage(caster, targets[0], MyDamage);
        return true;
    }
}
