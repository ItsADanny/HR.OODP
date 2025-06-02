class Blizzard : Spell
{
    public Damage MyDamage => new(DamageTypes.Cold, 50);
    public Blizzard() : base("Blizzard", TargetTypes.Multi, 25) { }

    protected override bool ApplyEffects(ITargetable caster, ITargetable[] targets)
    {
        foreach (var target in targets)
            CombatManager.ProcessDamage(caster, target, MyDamage);
        return true;
    }
}
