class GlimmersteelGolem : Monster
{
    public override bool IsBoss => true;

    public override int ResistPhysical => 100;
    public override int ResistFire => -100;
    public override int ResistCold => -100;
    public override int ResistLightning => -100;

    public GlimmersteelGolem() : base("Glimmersteel Golem", 175, 20, 100) { }
}
