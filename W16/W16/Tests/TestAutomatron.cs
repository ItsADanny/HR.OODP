static class TestAutomatron
{
    public static void Types()
    {
        Type monsterType = typeof(Monster);
        Type automatronType = typeof(ArtificerAutomaton);

        Console.WriteLine($"{automatronType.Name} is derived from {monsterType.Name}: " +
            $"{monsterType.IsAssignableFrom(automatronType) && automatronType != monsterType}");

        Type interfaceType = typeof(IUseItem);
        Console.WriteLine($"{automatronType.Name} has implemented {interfaceType.Name}: "
            + interfaceType.IsAssignableFrom(automatronType));
    }

    public static void Stats()
    {
        ArtificerAutomaton art = new();
        Program.PrintStats(art, true);
    }

    public static void Attacks()
    {
        ArtificerAutomaton art = new();
        Barbarian barb = new("Smashbeard Stoneslinger");

        // ArtificerAutomaton has 3 grenades. At each attacks, he tosses 1.
        for (int i = 0; i < 4; i++)
        {
            art.Attack(barb);
        }
        Console.WriteLine("Done attacking");
    }

    public static void TakesandHealsDamage()
    {
        ArtificerAutomaton art = new();
        Barbarian barb = new("Smashbeard Stoneslinger");
        barb.Attack(art, art);
        Program.PrintStats(art);

        art.Inventory[ItemTypes.Potion] = 1;
        art.UseItem(ItemTypes.Potion, art);
        Program.PrintStats(art); // Should not have HP restored
    }
}
