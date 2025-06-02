class EarthSlide : Spell
{
    public Damage MyDamage => new(DamageTypes.Physical, 50);
    public EarthSlide() : base("Earth Slide", TargetTypes.Multi, 20) { }

    protected override bool ApplyEffects(ITargetable caster, ITargetable[] targets)
    {
        foreach (var target in targets)
            CombatManager.ProcessDamage(caster, target, MyDamage);
        return true;
    }
}

