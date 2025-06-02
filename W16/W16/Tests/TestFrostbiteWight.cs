static class TestFrostbiteWight
{
    public static void Types()
    {
        Type monsterType = typeof(Monster);
        Type wightType = typeof(FrostbiteWight);

        Console.WriteLine($"{wightType.Name} is derived from {monsterType.Name}: " +
            $"{monsterType.IsAssignableFrom(wightType) && wightType != monsterType}");

        Type interfaceType = typeof(IUseItem);
        Console.WriteLine($"{wightType.Name} has implemented {interfaceType.Name}: "
            + interfaceType.IsAssignableFrom(wightType));
    }

    public static void Stats()
    {
        FrostbiteWight wight = new();
        Program.PrintStats(wight, true);
    }

    public static void Attacks()
    {
        FrostbiteWight wight = new();
        Barbarian barb = new("Smashbeard Stoneslinger");

        wight.Attack(barb);
        Program.PrintStats(barb);
    }

    public static void Drains()
    {
        FrostbiteWight wight = new();
        Barbarian barb = new("Cassie the Crass Cagefighter");
        Wizard wiz = new("Shhharon the Silent Librarian");

        barb.Attack(wight, wight);
        wiz.CastSpell(SpellTypes.FireBolt, wight);

        wight.DrainLife(wiz);
        wight.DrainLife(wiz);
        Program.PrintStats(wight);
    }
}

