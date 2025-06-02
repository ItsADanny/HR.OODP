abstract class Spell
{
    public string Name { get; }
    public TargetTypes CanTarget { get; }
    public int MPCost { get; }

    public Spell(string name, TargetTypes possibleTargets, int mpCost)
    {
        Name = name;
        CanTarget = possibleTargets;
        MPCost = mpCost;
    }

    public void CastMe(ITargetable caster, ITargetable target)
    {
        CastMe(caster, [target]);
    }
    public bool CastMe(ITargetable caster, ITargetable[] targets)
    {
        if (!IsValidTarget(caster, targets))
        {
            return false;
        }
        Console.WriteLine($"{caster.Name} casts {Name}!");
        return ApplyEffects(caster, targets);
    }

    private bool IsValidTarget(ITargetable caster, ITargetable[] targets) => CanTarget switch
    {
        TargetTypes.Self => targets.Length == 1 && targets[0] == caster,
        TargetTypes.Other => targets.Length == 1 && targets[0] != caster,
        TargetTypes.Single => targets.Length == 1,
        TargetTypes.Multi => targets.Length > 0,
        _ => throw new ArgumentException("Invalid target type")
    };

    protected abstract bool ApplyEffects(ITargetable caster, ITargetable[] targets);
}
