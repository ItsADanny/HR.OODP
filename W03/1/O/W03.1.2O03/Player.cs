//We begin by creating the player class
class Player {
    //This class will need 5 variables:
    //1. Name         : (string)  : To store the name of the player
    //2. Points       : (integer) : To Keep track of the score of the player (By default this value will start at 0)
    //3. Skill        : (integer) : To store the skill level of the player
    //4. Intelligence : (integer) : To store the intelligence level of the player
    //5. Knowledge    : (integer) : To store the knowledge level of the player
    public string Name;
    public int Points = 0;
    public int Skill;
    public int Intelligence;
    public int Knowledge;

    //In the players constructor we will assign the players name, skill level, 
    //intelligence level and knowledge level
    public Player(string name, int skill, int intelligence, int knowledge) {
        Name = name;
        Skill = skill;
        Intelligence = intelligence;
        Knowledge = knowledge;
    }

    //With this method we can increase the players score by 1 point
    public void Score() => Points++;

    //With this static method we can call the player class itself and see which player is winning based on
    //The current point level
    //This method requires 2 player objects to work and will return the player object with the highest points score
    public static Player WhoIsWinning(Player player_p1, Player player_p2) {
        //Check to see if player 1 has more points then player 2
        if (player_p1.Points > player_p2.Points) {
            //If so return player 1
            return player_p1;
        //Check to see if player 2 has more points then player 1
        } else if (player_p1.Points < player_p2.Points) {
            //If so return player 2
            return player_p2;
        //If its a draw then return a null value
        } else {
            return null;
        }
    }
}