class ThornshroudSpecter : Monster, IReturnDamage
{
    public override bool IsBoss => true;
    public override bool IsUndead => true;

    public Damage ThornsDamage => new Damage(DamageTypes.Physical, 10, true, false, false);

    public override int ResistPhysical => 75;
    public override int ResistFire => -100;

    public ThornshroudSpecter() : base("Thornshroud Specter", 250, 10, 20) { }
}
