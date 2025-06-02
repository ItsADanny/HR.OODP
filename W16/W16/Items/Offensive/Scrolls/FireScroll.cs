class FireScroll : Scroll
{
    public override Damage MyDamage { get; } = new(DamageTypes.Fire, 25);

    public FireScroll() : base("Fire", ItemTypes.FireScroll) { }
}
