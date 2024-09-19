using System.Reflection.Metadata.Ecma335;

public class Player {
    public const string Name = "Simon Belmont";
    public int MaxHP;
    public int CurrentHP;
    public int Strength;
    public static int Experience = 0;
    public static int Level = 0;

    public Player(int int_maxHP, int int_strength) {
        MaxHP = int_maxHP;
        CurrentHP = int_maxHP;
        Strength = int_strength;
    }

    public void Attack(Monster monster) {
        monster.TakeDamage(Strength);
        if (!monster.IsAlive()) {
            Experience += monster.Experience;
            int potential_level = 0;
            int new_level = 0;
            foreach (int Experience_level in World.ExperienceChart) {
                if (Experience >= Experience_level) {
                    new_level = potential_level;
                }
                potential_level++;
            }

            if (new_level > Level) {
                Level = new_level;
                MaxHP += 10;
                Strength += 3;
            }
        }
    }

    public void TakeDamage(int int_damage) {
        if ((CurrentHP - (int_damage - (Strength / 4))) < 0) {
            CurrentHP = 0;
        } else {
            CurrentHP -= int_damage;
        }
    }

    public int GetLevel() {
        return Level;
    }

    public bool IsAlive() {
        if (CurrentHP > 0) {
            return true;
        }
        return false;
    }
}