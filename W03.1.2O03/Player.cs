class Player {
    public string Name;
    public int Points;
    public int Skill;
    public int Intelligence;
    public int Knowledge;

    public Player(string name, int skill, int intelligence, int knowledge) {
        Name = name;
        Skill = skill;
        Intelligence = intelligence;
        Knowledge = knowledge;
    }

    public void Score() => Points++;

    public static Player WhoIsWinning(Player player_p1, Player player_p2) {
        if (player_p1.Points > player_p2.Points) {
            return player_p1;
        } else if (player_p1.Points < player_p2.Points) {
            return player_p2;
        } else {
            return null;
        }
    }
}