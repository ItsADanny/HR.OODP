class Game {
    public readonly Player Player1;
    public readonly Player Player2;

    public Game(Player player1, Player player2) {
        Player1 = player1;
        Player2 = player2;
    }

    public Player Round1() {
        if (Player2.Skill > Player1.Skill) {
            return Player2;
        }
        return Player1;
    }

    public Player Round2() {
        if (Player2.Intelligence > Player1.Intelligence) {
            return Player2;
        }
        return Player1;
    }

    public Player Round3() {
        if (Player2.Knowledge > Player1.Knowledge) {
            return Player2;
        }
        return Player1;
    }

    public static string Instructions() {
        return "Win at least 2 rounds to win!";
    }
}