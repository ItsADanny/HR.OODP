class Wizard : Fighter
{
    private List<SpellTypes> _knownSpells = [];
    public int MaxMP { get; private set; } = 250;
    private int _currMP;
    public int CurrMP
    {
        get => _currMP;
        private set => _currMP = Math.Clamp(value, 0, MaxMP);
    }

    public override int ResistFire => 25;
    public override int ResistCold => 25;
    public override int ResistLightning => 25;

    public Wizard(string name) : this(name, []) { }
    public Wizard(string name, List<SpellTypes> spells) :
        base(name, 80, 3, 3)
    {
        _knownSpells = [SpellTypes.FireBolt, SpellTypes.Heal, .. spells];
        // Remove any duplicate spells
        _knownSpells = _knownSpells.Distinct().ToList();
        _knownSpells.Sort();
        CurrMP = MaxMP;
    }

    public override void Attack(ITargetable target)
    {
        base.Attack(target);
        if (target is Fighter)
            CurrMP += 10;
    }

    public override int TakeDamage(Damage damage, ITargetable damageSource)
    {
        if (CurrMP == MaxMP &&
            _knownSpells.Contains(SpellTypes.Teleport))
        {
            CastSpell(SpellTypes.Teleport, this);
            return 0;
        }
        return base.TakeDamage(damage, damageSource);
    }

    public void CastSpell(SpellTypes spellType, ITargetable target)
    {
        CastSpell(spellType, [target]);
    }
    public void CastSpell(SpellTypes spellType, ITargetable[] targets)
    {
        Spell spell = SpellFactory.GetSpell(spellType);
        if (spell == null)
        {
            Console.WriteLine($"Unknown spell: {spellType}");
            return;
        }
        if (!_knownSpells.Contains(spellType))
        {
            Console.WriteLine($"{Name} does not know spell {spellType}");
            return;
        }
        if (spell.MPCost > CurrMP)
        {
            Console.WriteLine($"Not enough MP to cast {spell.Name}");
            return;
        }

        bool cast = spell.CastMe(this, targets);
        if (cast)
            CurrMP -= spell.MPCost;
        return;
    }

    public List<SpellTypes> GetKnownSpells() => _knownSpells;

    public void LearnSpell(SpellTypes spellType)
    {
        if (_knownSpells.Contains(spellType))
            return;
        _knownSpells.Add(spellType);
        _knownSpells.Sort();
    }
}
