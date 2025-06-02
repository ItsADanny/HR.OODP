static class TestNecro
{
    public static void Stats()
    {
        Necromancer necro = new("Grump");
        Program.PrintStats(necro, true);
    }

    public static void InstaKill()
    {
        Console.WriteLine("====== Part 1: Necro triggers InstaKill ======");
        Necromancer necro = new("Bony Tony the Undead Homie");
        Wizard wiz = new("Erica the Enigma Ender", [SpellTypes.Meteor]);
        GlimmersteelGolem golem = new();

        wiz.CastSpell(SpellTypes.Meteor, golem);

        Program.PrintStats(golem);
        necro.Attack(golem);

        Console.WriteLine("\n====== Part 2: Necro minion does not triggers InstaKill ======");

        Console.WriteLine("\nFirst raise some minions...");
        ChaosElemental[] elementals = [new(), new(), new()];
        while (elementals.Any(elemental => elemental.IsAlive))
            foreach (var elemental in elementals)
                if (elemental.IsAlive)
                    necro.Attack(elemental);

        Console.WriteLine("\nNow attack the monster.");
        GlimmersteelGolem golem2 = new();
        for (int i = 0; i < 3; i++)
            necro.Attack(golem2);
        Program.PrintStats(golem2);
    }

    public static void IgnoreDefense()
    {
        Necromancer necro = new("Giggles the Gravekeeper");
        Barbarian barb = new("Cuddles the Conqueror");
        FrostbiteWight frosty = new();

        Program.PrintStats(necro);
        Program.PrintStats(barb);
        Program.PrintStats(frosty);

        barb.Attack(frosty, frosty);
        Program.PrintStats(frosty);
        necro.Attack(frosty); // Necromancers ignore their target's defense
        Program.PrintStats(frosty);
        Program.PrintStats(necro);
    }

    public static void Raise()
    {
        Necromancer necro1 = new("Grump");
        Goblin goblin = new();

        Program.PrintStats(necro1);
        Program.PrintStats(goblin);

        necro1.Attack(goblin); 
        goblin.Attack(necro1);
        Program.PrintStats(necro1);
        Program.PrintStats(goblin);

        necro1.Attack(goblin);
        necro1.Attack(goblin);

        Program.PrintStats(necro1);

        Console.WriteLine("\nAdding zombie...");
        Zombie zombie = new();
        necro1.Attack(zombie);
        Program.PrintStats(zombie);
        necro1.Attack(zombie);
        necro1.Attack(zombie);

        Console.WriteLine("\nAdding imp...");
        Skeleton imp = new();
        necro1.Attack(imp);
        Program.PrintStats(necro1);

        Skeleton skeleton = new();
        necro1.Attack(skeleton);
        Program.PrintStats(necro1); // Should still have only 3 minions

        FrostbiteWight wight = new();
        // Frostbite Wights attack twice; the Necromancer should lose 2 minions
        wight.Attack(necro1);
        Program.PrintStats(necro1);
        wight.Attack(necro1);
        Program.PrintStats(necro1);

        Console.WriteLine("\nA new challenger appears!");
        Necromancer necro2 = new("NotSoGrump");
        while (necro1.IsAlive)
            necro2.Attack(necro1);
        Program.PrintStats(necro2); // Should not raise other players as their minion

        while (wight.IsAlive)
        {
            necro2.Attack(wight);
        }

        Program.PrintStats(necro2); // Should not raise boss monsters
    }
}
