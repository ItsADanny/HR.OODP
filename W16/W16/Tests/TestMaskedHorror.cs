static class TestMasked
{
    public static void Types()
    {
        Type monsterType = typeof(Monster);
        Type maskedType = typeof(MaskedHorror);

        Console.WriteLine($"{maskedType.Name} is derived from {monsterType.Name}: " +
            $"{monsterType.IsAssignableFrom(maskedType) && maskedType != monsterType}");
    }

    public static void Stats()
    {
        MaskedHorror masked = new();
        Program.PrintStats(masked, true);
    }

    public static void Attacks()
    {
        MaskedHorror masked = new();
        Wizard wiz = new("Tim the Enchanter");

        for (int i = 0; i < 5; i++)
        {
            masked.Attack(wiz);
            Program.PrintStats(wiz);
        }
        Console.WriteLine("Done attacking");
    }

    public static void TakesDamage()
    {
        /*
        The Masked Horror (MH) has four Masks, one for each damage type.
        Mask is immune to its own damage type.
      
        The MH cannot be damaged, except through its own masks: its HP is
        linked to the four Masks, so that when a Mask's HP is damaged, so will
        the MH be. Consequently, when all of its four Masks are defeated,
        so is the MH.
        
        When the Masked Horror is attacked, it will switch to the Mask with
        the damage type it was just attacked with. After the Masked Horror has
        attacked, it will switch to the next damage type:
        Physical -> Fire -> Cold -> Lightning -> Physical -> ...
        */

        MaskedHorror masked = new();
        for (int i = 0; i < 3; i++)
        {
            // Creating a new Wizard every time, so that MP doesn't run out
            Wizard wiz = new("Cassandra, the Bringer of Nukes", new List<SpellTypes>() {
                SpellTypes.EarthSlide,
                SpellTypes.Meteor,
                SpellTypes.Blizzard,
                SpellTypes.Vortex});
            wiz.CastSpell(SpellTypes.Blizzard, masked);
            wiz.CastSpell(SpellTypes.Blizzard, masked);
            wiz.CastSpell(SpellTypes.EarthSlide, masked);
            wiz.CastSpell(SpellTypes.Meteor, masked);
            wiz.CastSpell(SpellTypes.Meteor, masked);
            wiz.CastSpell(SpellTypes.Vortex, masked);
        }

        Console.WriteLine("Done attacking");
    }
}
