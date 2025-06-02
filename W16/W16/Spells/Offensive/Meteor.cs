class Meteor : Spell
{
    public Damage MyDamage => new(DamageTypes.Fire, 75);
    public Meteor() : base("Meteor", TargetTypes.Multi, 35) { }

    protected override bool ApplyEffects(ITargetable caster, ITargetable[] targets)
    {
        foreach (var target in targets)
            CombatManager.ProcessDamage(caster, target, MyDamage);
        return true;
    }
}

