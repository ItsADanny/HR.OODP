public class Player {
    //We begin by declaring some variables for this class

    //Name to store the players name
    public string Name;
    //HealthPoints to store the players Health
    public int HealthPoints = 100;
    //And finally Power to store the players power
    public int Power;

    //In the constructor we have to input two variables, the players name and the player starting power.
    //We don't need to put in the players health because this will always start at 100
    public Player(string str_name, int int_power) {
        Name = str_name;
        Power = int_power;
    }

    //This method will return a true or false based on if the players healthpoints are above 0
    public bool IsAlive() {
        if (HealthPoints > 0)
        {
            return true;
        }
        return false;
    }

    //This method will remove healthpoints from the player based on the amount of damage that has been inputted
    public void TakeDamage(int int_damage)
    {
        HealthPoints -= int_damage;
        //To make sure that our players health can't go below 0,
        //we check after removing the damage if the players health has dropped below 0 and
        //if so then we set the player health to 0
        if (HealthPoints < 0)
        {
            HealthPoints = 0;
        }
    }
}