class IceScroll : Scroll
{
    public override Damage MyDamage { get; } = new(DamageTypes.Cold, 25);

    public IceScroll() : base("Ice", ItemTypes.IceScroll) { }
}
