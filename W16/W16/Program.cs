static class Program
{
    static void Main(string[] args)
    {
        switch(args[1])
        {
            // Test new Ninja items
            // Test Wizard sorting spells

            case "DamageOpOverload": TestDamage.Overload(); return;

            case "CrateWhere": TestCrate.Where(); return;
            case "CrateFunct": TestCrate.Functionality(); return;
            
            case "SkeletonAttacks": TestSkeleton.Attacks(); return;

            case "SpellVortex": TestSpells.TestVortex(); return;
            case "SpellCrystalShards": TestSpells.TestCrystalShards(); return;
            case "Grenade": TestGrenade.Stats(); return;

            case "PaladinType": TestPaladin.Types(); return;
            case "PaladinStats": TestPaladin.Stats(); return;
            case "PaladinUndead": TestPaladin.Undead(); return;
            case "PaladinSmite": TestPaladin.Smite(); return;
            case "PaladinTakesDamage": TestPaladin.TakesDamage(); return;

            case "NecroStats": TestNecro.Stats(); return;
            case "NecroInstaKill": TestNecro.InstaKill(); return;
            case "NecroIgnoreDefense": TestNecro.IgnoreDefense(); return;
            case "NecroRaise": TestNecro.Raise(); return;

            case "NinjaStats": TestNinja.Stats(); return;
            case "NinjaCombat": TestNinja.Combat(); return;
            case "NinjaItem": TestNinja.UsesItem(); return;

            case "FrostbiteWightType": TestFrostbiteWight.Types(); return;
            case "FrostbiteWightStats": TestFrostbiteWight.Stats(); return;
            case "FrostbiteWightAttacks": TestFrostbiteWight.Attacks(); return;
            case "FrostbiteWightDrains": TestFrostbiteWight.Drains(); return;

            case "AutomatronType": TestAutomatron.Types(); return;
            case "AutomatronStats": TestAutomatron.Stats(); return;
            case "AutomatronAttacks": TestAutomatron.Attacks(); return;
            case "AutomatronTakesHealsDamage": TestAutomatron.TakesandHealsDamage(); return;

            case "MaskedType": TestMasked.Types(); return;
            case "MaskedStats": TestMasked.Stats(); return;
            case "MaskedAttacks": TestMasked.Attacks(); return;
            case "MaskedTakesDamage": TestMasked.TakesDamage(); return;

            default: throw new ArgumentException();
        }
    }

    public static void PrintStats(Fighter fighter, bool extensive = false)
    {
        Console.WriteLine($"\n=== {fighter.Name} ===");
        Console.WriteLine($"HP: {fighter.CurrHP}/{fighter.MaxHP}");
        if (fighter is Wizard wizard)
        {
            Console.WriteLine($"MP: {wizard.CurrMP}/{wizard.MaxMP}");
        }

        if (fighter is Necromancer necro)
        {
            if (necro.Minions.Count == 0)
                Console.WriteLine("No minions");
            else
            {
                Console.WriteLine("Minions:");
                foreach (Monster minion in necro.Minions)
                {
                    Console.WriteLine($" - {minion.Name}");
                }
            }
        }
        if (fighter is Ninja ninjaCln)
        {
            if (ninjaCln.MyClone is null)
                Console.WriteLine("No clone");
            else
                Console.WriteLine($"Clone:\n - HP: {ninjaCln.MyClone.CurrHP}/{ninjaCln.MyClone.MaxHP}");
        }

        if (!extensive)
        {
            Console.WriteLine();
            return;
        }

        if (fighter is Monster monster && monster.IsBoss)
            Console.WriteLine("Boss");
        Console.WriteLine($"Attack power: {fighter.AttackPower}");
        Console.WriteLine($"Defense: {fighter.Defense}");
        if (fighter is Paladin pal)
            Console.WriteLine($" - Bonus defense: {pal.BonusDefense}");
        Console.WriteLine($"Resist Physical: {fighter.ResistPhysical}");
        Console.WriteLine($"Resist Fire: {fighter.ResistFire}");
        Console.WriteLine($"Resist Cold: {fighter.ResistCold}");
        Console.WriteLine($"Resist Lightning: {fighter.ResistLightning}");

        if (fighter is IInventory inv)
        {
            Console.WriteLine("Inventory:");
            foreach (var kvp in inv.Inventory)
            {
                Console.WriteLine($" - {kvp.Key} ({kvp.Value})");
            }
        }
        if (fighter is Wizard wiz)
        {
            Console.WriteLine("Spells known:");
            foreach (var spellType in wiz.GetKnownSpells())
            {
                Console.WriteLine($" - {spellType}");
            }
        }
        Console.WriteLine();
    }
}
