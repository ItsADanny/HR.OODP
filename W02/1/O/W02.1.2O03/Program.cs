static class Program
{
    static void Main()
    {
        Player p1 = new Player("John Snow", 30);
        Player p2 = new Player("Night King", 60);
        PrintPlayerStats(p1);
        PrintPlayerStats(p2);
        
        Player winner = null;
         while (winner is null)
        {
            p1.TakeDamage(p2.Power);
            if (!p1.IsAlive())
            {
                winner = p2;
                break;
            }

            p2.TakeDamage(p1.Power);
            if (!p2.IsAlive())
            {
                winner = p1;
                break;
            }

            PrintPlayerStats(p1);
            PrintPlayerStats(p2);
        }

        PrintPlayerStats(p1);
        PrintPlayerStats(p2);
        Console.WriteLine($"\n-----The winner is:-----\n{winner.Name}: {winner.Power} Power; {winner.HealthPoints} Healthpoints");
    }
    
    static void PrintPlayerStats(Player? player)
    {
        //MISSING ) HERE \/
        if (player == null) { return; }
        Console.WriteLine($"{player.Name}: {player.Power} Power; {player.HealthPoints} Healthpoints");
    }
}