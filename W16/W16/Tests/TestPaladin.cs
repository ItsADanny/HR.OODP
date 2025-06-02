static class TestPaladin
{
    public static void Types()
    {
        Type fighterType = typeof(Fighter);
        Type paladinType = typeof(Paladin);

        Console.WriteLine($"{paladinType.Name} is derived from {fighterType}: " +
            $"{fighterType.IsAssignableFrom(paladinType) && paladinType != fighterType}");

        Type interfaceType = typeof(IReturnDamage);
        Console.WriteLine($"{paladinType.Name} has implemented {interfaceType.Name}: "
            + interfaceType.IsAssignableFrom(paladinType));
    }

    public static void Stats()
    {
        Paladin pal = new("Volt Vanguard");
        Program.PrintStats(pal, true);
    }

    public static void Undead()
    {
        // Ignore the defense of undead monsters
        Paladin pal = new("Holy Moly");

        Goblin gob = new();
        Damage damageAgainstGoblin = pal.GetAttackDamage(gob);
        Console.WriteLine($"Ignores defense against Goblin: " +
            $"{damageAgainstGoblin.IgnoreDefense}");

        Skeleton skelly = new();
        Damage damageAgainstSkeleton = pal.GetAttackDamage(skelly);
        Console.WriteLine($"Ignores defense against Skeleton: " +
            $"{damageAgainstSkeleton.IgnoreDefense}");
    }

    public static void Smite()
    {
        Paladin pal = new("Bright Boltbringer Bob");
        ThornshroudSpecter spec = new();
        Monster[] monsters = [new Goblin(), new Skeleton()];
        
        // Smites the original target and up to two others
        pal.Attack(spec, monsters);

        Program.PrintStats(spec);
        foreach (var monster in monsters)
        {
            Program.PrintStats(monster);
        }

        // May smite each target only once, including the originally attacked target
        monsters = [spec, spec];
        pal.Attack(spec, monsters);
        Program.PrintStats(spec);

        // Ignore any targets after the third one
        monsters = [new Goblin(), new Skeleton(), new Skeleton()];
        pal.Attack(spec, monsters);

        Program.PrintStats(spec);
        foreach (var monster in monsters)
        {
            Program.PrintStats(monster);
        }
    }

    public static void TakesDamage()
    {
        // The Paladin returns lightning damage.
        // Additionally, his defense increases by 1 each time he's struck by
        // a physical attack. His defense is reset to its original value
        // after he's stuck by a physical attack that does no damage.
        Paladin pal = new("Sir Jigawatt the Just");
        Zombie[] zombies = [new(), new(), new(),
                            new(), new(), new()];
        foreach (Zombie zombie in zombies)
        {
            zombie.Attack(pal);
            Program.PrintStats(pal);
        }
    }
}
