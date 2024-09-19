public class Monster {

    public readonly string Name;
    public int CurrentHP;
    public int Strength;
    public int Experience;

    public Monster(string str_name, int int_hp, int int_strength, int int_experience) {
        Name = str_name;
        CurrentHP = int_hp;
        Strength = int_strength;
        Experience = int_experience;
    }

    public void Attack(Player player) => player.TakeDamage(Strength);

    public void TakeDamage(int int_damage) {
        if ((CurrentHP - int_damage) < 0) {
            CurrentHP = 0;
        } else {
            CurrentHP -= int_damage;
        }
    } 

    public bool IsAlive() {
        if (CurrentHP > 0) {
            return true;
        }
        return false;
    }
}