class FireBolt : Spell
{
    public static Damage MyDamage { get; } = new(DamageTypes.Fire, 12);
    public FireBolt() : base("Fire Bolt", TargetTypes.Single, 3) { }

    protected override bool ApplyEffects(ITargetable caster, ITargetable[] targets)
    {
        CombatManager.ProcessDamage(caster, targets[0], MyDamage);
        return true;
    }
}
