class Program {
    static void Main() {
        Random rnd = new Random();
        int attack = 50;
        double critChance = 0.33;
        int bossHP = 1000;

        do {
            Console.WriteLine($"Boss HP: {bossHP}");

            int damage;
            if (rnd.NextDouble() <= critChance) {
                damage = attack * 2;
            } else {
                damage = attack;
            }
            bossHP -= damage;

            Console.WriteLine($"Damage: {damage}\n");
        } while (bossHP > 0);

        Console.WriteLine("Boss defeated");
    }
}