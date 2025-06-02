class LightningScroll : Scroll
{
    public override Damage MyDamage { get; } = new(DamageTypes.Lightning, 25);

    public LightningScroll() : base("Lightning", ItemTypes.LightningScroll) { }
}
