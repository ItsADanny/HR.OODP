abstract class Fighter : ITargetable
{
    public string Name { get; }
    public bool IsAlive => CurrHP > 0;

    public int MaxHP { get; protected set; }
    private int _currHP;
    public virtual int CurrHP
    {
        get => _currHP;
        protected set => _currHP = Math.Clamp(value, 0, MaxHP);
    }

    public int AttackPower { get; protected set; }
    public virtual int Defense { get; protected set; }

    // Resists are percentages. Default is 0% damage reduction.
    public virtual int ResistPhysical => 0; // Physical resist is applied after Defense
    public virtual int ResistFire => 0;
    public virtual int ResistCold => 0;
    public virtual int ResistLightning => 0;

    public Fighter(string name, int maxHP,
        int attackPower, int defense)
    {
        Name = name;
        MaxHP = maxHP;
        CurrHP = MaxHP;
        AttackPower = attackPower;
        Defense = defense; // Reduces Physical damage
    }

    public virtual void Attack(ITargetable target)
    {
        CombatManager.PerformAttack(this, target);
    }

    public virtual Damage GetAttackDamage(ITargetable target)
    {
        return new(DamageTypes.Physical, AttackPower);
    }

    public virtual int TakeDamage(Damage damage, ITargetable damageSource)
    {
        int damageAmount = ApplyDamageReduction(damage);
        CurrHP -= damageAmount;
        return damageAmount;
    }

    private int ApplyDamageReduction(Damage damage) => damage.Type switch
    {
        DamageTypes.Physical =>
            (int)(Math.Max(0, damage.Amount - (damage.IgnoreDefense ? 0 : Defense))
            * (damage.IgnoreResist ? 1 : CalculateDamageReduction(ResistPhysical))),
        DamageTypes.Fire =>
            (int)(damage.Amount
            * (damage.IgnoreResist ? 1 : CalculateDamageReduction(ResistFire))),
        DamageTypes.Cold =>
            (int)(damage.Amount
            * (damage.IgnoreResist ? 1 : CalculateDamageReduction(ResistCold))),
        DamageTypes.Lightning =>
            (int)(damage.Amount
            * (damage.IgnoreResist ? 1 : CalculateDamageReduction(ResistLightning))),
        _ => throw new ArgumentException($"Unknown damage type: {damage.Type}"),
    };

    private static double CalculateDamageReduction(int resistPercentage)
    {
        return 1 - (resistPercentage / 100.0);
    }

    public virtual void Heal(int amount)
    {
        CurrHP += amount;
    }
}
