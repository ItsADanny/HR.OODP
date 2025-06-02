static class TestDamage
{
    public static void Overload()
    {
        Damage damage = new(DamageTypes.Physical, 50, true, true, false);
        int splitInto = 2;
        Damage splitDamage = damage / splitInto;
        Console.WriteLine($"{damage.Amount} was split into {splitInto}, resulting in {splitDamage.Amount}");

        damage = new(DamageTypes.Fire, 100);
        splitInto = 3;
        splitDamage = damage / splitInto;
        Console.WriteLine($"{damage.Amount} was split into {splitInto}, resulting in {splitDamage.Amount}");

        damage = new(DamageTypes.Physical, int.MaxValue, true, true, true);
        splitInto = 4;
        splitDamage = damage / splitInto;
        Console.WriteLine($"{damage.Amount} was split into {splitInto}, resulting in {splitDamage.Amount}");
    }
}
