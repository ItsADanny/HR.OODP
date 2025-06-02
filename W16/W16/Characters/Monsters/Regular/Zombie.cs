class Zombie : Monster
{
    public override bool IsUndead => true;
    public override int ResistPhysical => 50;
    public override int ResistFire => -50;

    public Zombie() : base("Zombie", 25, 10, 0) { }
}
