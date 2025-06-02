static class TestSpells
{
    public static void TestVortex()
    {
        Vortex vortex = new();
        Console.WriteLine($"Name: {vortex.Name}");
        Console.WriteLine($"Damage: {vortex.MyDamage.Amount}");
        Console.WriteLine($"Damage type: {vortex.MyDamage.Type}");
        Console.WriteLine($"Targets: {vortex.CanTarget}");
    }

    public static void TestCrystalShards()
    {
        CrystalShards shards = new();
        Console.WriteLine($"Name: {shards.Name}");
        Console.WriteLine($"Damage: {shards.MyDamage.Amount}");
        Console.WriteLine($"Damage type: {shards.MyDamage.Type}");
        Console.WriteLine($"Targets: {shards.CanTarget}");
        Console.WriteLine();

        Wizard wiz = new("Cragheart the Geomancer");
        wiz.LearnSpell(SpellTypes.CrystalShards);

        Monster[] monsters = [
            new Skeleton(),
            new ChaosElemental(),
        ];
        wiz.CastSpell(SpellTypes.CrystalShards, monsters);
        Console.WriteLine();

        monsters = [
            new Goblin(),
            new Imp(),
            new Zombie(),
        ];

        wiz.CastSpell(SpellTypes.CrystalShards, monsters);
    }
}
