//We start by creating the Player class
class Player {
    //A player has 4 field which are:

    //Since the player will always be called Simon Belmont we initiate the 
    //player object with Simon Belmont as his name
    public readonly string Name = "Simon Belmont";
    public int MaxHP;
    public int CurrentHP;
    public int Strength;
    //We will start the Experience at 0
    public int Experience = 0;

    //We then make the constructor which will take the same 4 variables ands assigns them to our monster
    //object.
    public Player (int hp, int strength, int experience) {
        MaxHP = hp;
        CurrentHP = hp;
        Strength = strength;
        Experience = experience;
    }

    //We then create a function which we will use attack an inputted player object
    public void Attack(Player player) {
        //
        player.TakeDamage(Strength);
    }

    //We then create a function which we will use when our Monster takes damage
    public void TakeDamage(int damage) {
        //Check if the damage would cause the CurrentHP to drop below 0
        if (CurrentHP - damage < 0) {
            //if so the we set the CurrentHP to 0
            CurrentHP = 0;
        } else {
            //if not then we reduce the monsters health with the inputted damage amount
            CurrentHP -= damage;
        }
    }

    //We then create a method which returns a true or false based on if our monster still has HP
    public bool IsAlive() {
        //If the monster still has a CurrentHP level above 1 then we return true
        if (CurrentHP > 1) {
            return true;
        }
        //If not then we will always return a false
        return false;
    }
}