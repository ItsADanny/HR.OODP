class Teleport : Spell
{
    public Teleport() : base("Teleport", TargetTypes.Self, 10) { }

    protected override bool ApplyEffects(ITargetable caster, ITargetable[] targets)
    {
        Console.WriteLine("Teleporting to safety...");
        return true;
    }
}
