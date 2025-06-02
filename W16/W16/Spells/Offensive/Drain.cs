class Drain : Spell
{
    public Damage MyDamage => new(DamageTypes.Physical, 20);
    public Drain() : base("Drain", TargetTypes.Other, 5) { }

    protected override bool ApplyEffects(ITargetable caster, ITargetable[] targets)
    {
        // Cannot Drain non-Fighters
        if (targets[0] is not Fighter attacked)
            return false;

        int hpBefore = attacked.CurrHP;
        CombatManager.ProcessDamage(caster, targets[0], MyDamage);
        if (caster is Fighter attacker)
        {
            attacker.Heal(hpBefore - attacked.CurrHP);
        }
        return true;
    }
}
