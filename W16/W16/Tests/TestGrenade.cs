static class TestGrenade
{
    public static void Stats()
    {
        Grenade grenade = new();
        Console.WriteLine($"Name: {grenade.Name}");
        Console.WriteLine($"Damage: {grenade.MyDamage.Amount}");
        Console.WriteLine($"Damage type: {grenade.MyDamage.Type}");
        Console.WriteLine($"Targets: {grenade.CanTarget}");
    }
}
