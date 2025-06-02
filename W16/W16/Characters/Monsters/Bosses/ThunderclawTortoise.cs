class ThunderclawTortoise : Monster, IReturnDamage
{
    public override bool IsBoss => true;
    public Damage ThornsDamage => new(DamageTypes.Lightning, 10);

    public override int ResistPhysical => IsRetractedInShell ? 100 : 75;
    public override int ResistFire => IsRetractedInShell ? 100 : 0;
    public override int ResistCold => IsRetractedInShell ? 100 : 0;
    public override int ResistLightning => 100;

    public bool IsRetractedInShell { get; private set; } = false;

    public ThunderclawTortoise() : base("Thunderclaw Tortoise", 125, 10, 10) { }

    public override void Attack(ITargetable target)
    {
        if (IsRetractedInShell)
        {
            Console.WriteLine($"{Name} is coming out of its shell!");
            IsRetractedInShell = false;
            return;
        }
        base.Attack(target);
    }

    public override int TakeDamage(Damage damage, ITargetable damageSource)
    {
        int damageTaken = base.TakeDamage(damage, damageSource);
        if (!IsRetractedInShell)
        {
            Console.WriteLine($"{Name} retreats in its shell!");
            IsRetractedInShell = true;
        }
        return damageTaken;
    }
}
