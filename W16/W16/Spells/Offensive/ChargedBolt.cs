class ChargedBolt : Spell
{
    public Damage MyDamage => new(DamageTypes.Lightning, 12);
    public ChargedBolt() : base("Charged Bolt", TargetTypes.Single, 3) { }

    protected override bool ApplyEffects(ITargetable caster, ITargetable[] targets)
    {
        CombatManager.ProcessDamage(caster, targets[0], MyDamage);
        return true;
    }
}
