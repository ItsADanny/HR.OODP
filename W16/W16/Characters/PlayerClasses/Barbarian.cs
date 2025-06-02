class Barbarian : Fighter
{
    public override int ResistPhysical => 50;

    public bool CanReviveSelf { get; private set; } = true;
    public int MonstersKilledSinceRevive { get; private set; } = 0;

    public Barbarian(string name) : base(name, 120, 20, 6) { }

    public override void Attack(ITargetable target)
    {
        if (target is Fighter)
        {
            CurrHP += 10;
        }

        base.Attack(target);
    }
    public void Attack(ITargetable target1, ITargetable target2)
    {
        Attack(target1);
        Attack(target2);
    }

    public override Damage GetAttackDamage(ITargetable target)
    {
        Damage damage = base.GetAttackDamage(target);
        if (target is not Fighter fighter)
            return damage;
        if (fighter.CurrHP <= MaxHP * 0.25)
            damage.Amount *= 2;
        damage.Amount += (int)(fighter.CurrHP * 0.25);
        return damage;
    }

    public override int TakeDamage(Damage damage, ITargetable damageSource)
    {
        int damageTaken = base.TakeDamage(damage, damageSource);

        if (CurrHP <= 0 && CanReviveSelf)
        {
            CurrHP = MaxHP / 2;
            CanReviveSelf = false;
            MonstersKilledSinceRevive = 0;
        }

        return damageTaken;
    }

    public void KilledMonster()
    {
        if (IsAlive && !CanReviveSelf)
        {
            MonstersKilledSinceRevive++;
            if (MonstersKilledSinceRevive >= 5)
            {
                CanReviveSelf = true;
            }
        }
    }
}
