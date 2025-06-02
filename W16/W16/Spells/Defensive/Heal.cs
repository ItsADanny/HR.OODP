class Heal : Spell
{
    public Heal() : base("Heal", TargetTypes.Multi, 5) { }

    protected override bool ApplyEffects(ITargetable caster, ITargetable[] targets)
    {
        // Return if none of the targets is a Fighter
        var validTargets = targets.OfType<Fighter>().ToArray();
        if (validTargets.Length == 0)
            return false;

        var healAmount = 100 / validTargets.Length;
        foreach (var fighter in validTargets)
        {
            Console.WriteLine($"Healing {fighter.Name} for {healAmount}");
            fighter.Heal(healAmount);
        }
        return true;
    }
}
