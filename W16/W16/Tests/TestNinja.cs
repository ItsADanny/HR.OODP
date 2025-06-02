static class TestNinja
{
    public static void Stats()
    {
        Ninja ninja = new("Ryu");
        Program.PrintStats(ninja, true);
    }

    public static void Combat()
    {
        Ninja ninja = new("Hayabusa");
        ninja.Clone();
        Imp imp = new();

        imp.Attack(ninja); // Clone takes half damage and dies
        Program.PrintStats(ninja);
        imp.Attack(ninja); // Should attack Original, who will spawn a new Clone
        Program.PrintStats(ninja);
        imp.Attack(ninja); // Clone takes half damage and dies
        Program.PrintStats(ninja);

        ninja.Attack(imp); // Imp is at full HP: spawn a Clone before attacking

        ThornshroudSpecter spec = new();
        ninja.Attack(spec); // ThornshroudSpecter returns damage; Clone should die
        Program.PrintStats(ninja);
    }

    public static void UsesItem()
    {
        // Automatically use a potion when after receiving damage
        // HP is half the max or less, if you have one
        Ninja ninja = new("Sasuke");
        MaskedHorror masked = new();
        for (int i = 0; i < 3; i++)
        {
            masked.Attack(ninja);
        }
        Program.PrintStats(ninja);

        GlimmersteelGolem golem = new();
        ninja.UseItem(ItemTypes.FireScroll, golem);
        ninja.UseItem(ItemTypes.Grenade, golem);
        Program.PrintStats(ninja, true);
    }
}
