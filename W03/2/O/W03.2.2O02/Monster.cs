//We start by creating the Monster class
class Monster {
    //A monster has 4 field which are:
    public readonly string Name;
    public int CurrentHP;
    public int Strength;
    public int Experience;

    //We then make the constructor which will take the same 4 variables ands assigns them to our monster
    //object.
    public Monster (string name, int hp, int strength, int experience) {
        Name = name;
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