public class GameTools {
    public static bool ReturnCount = true;

    public static string CoinFlip(int amount) {
        int heads = 0;
        int tails = 0;
        string str_return = "";
        Random rnd = new Random();
        for (int i = 0; i != amount; i++) {
            int rand_int = rnd.Next(0, 1);
            if (!ReturnCount) {
                if (str_return != "") {
                    str_return += "\n";
                }
                if (rand_int == 0) {
                    str_return += "Heads";
                } else {
                    str_return += "Tails";
                }
            }
        }
        
        if (ReturnCount) {
            str_return = $"Heads: {heads}\nTails: {tails}";
        }

        return str_return;
    }

    public static string DiceRoll(int die_sides, int amount) {
        string str_returnValue = "";

        Random rnd = new Random();
        
        if (!ReturnCount) {
            for (int i = 1; i != (amount + 1); i++) {
                int die_landed = rnd.Next(1, die_sides);
                
                if (str_returnValue != "") {
                    str_returnValue += "\n";
                }

                str_returnValue += $"Roll {i}: {die_landed}";
            }
        } else {
            Dictionary<int, int> die = new Dictionary<int, int>();
            for (int i = 1; i != die_sides; i++) {
                die.Add(i, 0);
            }

            for (int i = 0; i != amount; i++) {
                int die_landed = rnd.Next(1, die_sides);
                die[die_landed]++;
            }

            foreach (KeyValuePair<int, int> die_side in die) {
                if (str_returnValue != "") {
                    str_returnValue += "\n";
                }

                str_returnValue += $"{die_side.Key} was rolled {die_side.Value} times";
            }
        }

        return str_returnValue;
    }
}