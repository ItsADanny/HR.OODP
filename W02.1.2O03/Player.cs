public class Player
{
    public string Name;
    public int HealthPoints = 100;
    public int Power;

    public Player(string str_name, int int_power) {
        Name = str_name;
        Power = int_power;
    }

    public bool IsAlive() {
        if (HealthPoints > 0)
        {
            return true;
        }
        return false;
    }

    public void TakeDamage(int int_damage)
    {
        HealthPoints -= int_damage;
        if (HealthPoints < 0)
        {
            HealthPoints = 0;
        }
    }
}