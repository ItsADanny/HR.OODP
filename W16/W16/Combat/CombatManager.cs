static class CombatManager
{
    public static void PerformAttack(Fighter attacker, ITargetable target)
    {
        PerformAttack(attacker, target, attacker.GetAttackDamage(target));
    }
    public static void PerformAttack(Fighter attacker, ITargetable target, Damage damage)
    {
        if (attacker == null || !attacker.IsAlive)
        {
            return;
        }
        if (target is Fighter fighter)
            Console.WriteLine($"{attacker.Name} attacks {fighter.Name}");
        ProcessDamage(attacker, target, damage);
    }

    public static void ProcessDamage(ITargetable attacker, ITargetable target, Damage damage)
    {
        if (damage.InstaKill && target is Fighter toBeKilled)
        {
            damage.Amount = int.MaxValue;
            Console.WriteLine($"{attacker.Name} instantly kills {toBeKilled.Name}");
            toBeKilled.TakeDamage(damage, attacker);
            if (!toBeKilled.IsAlive)
            {
                Console.WriteLine($"{toBeKilled} is defeated!");
                return;
            }
        }

        int damageTaken = target.TakeDamage(damage, attacker);
        if (target is Fighter)
        {
            Console.WriteLine($"{target.Name} takes {damageTaken} {damage.Type} damage!");
        }
        else if (target is Crate && damageTaken > 0)
        {
            Console.WriteLine($"{target.Name} breaks and is now open!");
        }

        if (target is Fighter fAttacked && !fAttacked.IsAlive)
            Console.WriteLine($"{fAttacked.Name} is defeated!");

        if (target is IReturnDamage returner)
        {
            Damage returned = returner.ThornsDamage;
            if (attacker is Fighter fAttacker)
            {
                Console.WriteLine($"{returner.Name} returns " +
                    $"{returned.Amount} {returned.Type} damage!");
                // Damage source is null; returned damage cannot be returned again
                fAttacker.TakeDamage(returner.ThornsDamage, null);
                if (!fAttacker.IsAlive)
                    Console.WriteLine($"{fAttacker.Name} is defeated!");
            }
        }
    }
}
