//After making the player class we can create our game class
class Game {
    //We start by creating two variables which will both store a player (player 1 and player 2)
    public readonly Player Player1;
    public readonly Player Player2;

    //In the constuctor of the class we will assign the inputted players to our game objects Player1 and Player2
    //variable
    public Game(Player player1, Player player2) {
        Player1 = player1;
        Player2 = player2;
    }

    //When the method Round1() is called we check to see which player has the highest skill level
    public Player Round1() {
        //If player 2 has a higher skill level then player 1 we return player 2
        if (Player2.Skill > Player1.Skill) {
            return Player2;
        }
        //If its a draw or player 1 has a higher skill level then we return player 1
        return Player1;
    }

    //When the method Round2() is called we check to see which player has the highest intelligence level
    public Player Round2() {
        //If player 2 has a higher intelligence level then player 1 we return player 2
        if (Player2.Intelligence > Player1.Intelligence) {
            return Player2;
        }
        //If its a draw or player 1 has a higher intelligence level then we return player 1
        return Player1;
    }

    //When the method Round3() is called we check to see which player has the highest knowledge level
    public Player Round3() {
        //If player 2 has a higher knowledge level then player 1 we return player 2
        if (Player2.Knowledge > Player1.Knowledge) {
            return Player2;
        }
        //If its a draw or player 1 has a higher knowledge level then we return player 1
        return Player1;
    }

    //This static method will return the Instructions for the game class
    public static string Instructions() {
        return "Win at least 2 rounds to win!";
    }
}