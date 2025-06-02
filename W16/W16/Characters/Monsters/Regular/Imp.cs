class Imp : Monster
{
    public override int ResistFire => 25;
    public override int ResistCold => -25;
    public override int ResistLightning => 25;

    public Imp() : base("Imp", 30, 20, 1) { }
}
