public class Weapon
{
    public string Name { get;}
    public int Strength { get; private set; }

    public Weapon(string name, int damage)
    {
        Name = name;
        Strength = damage;
    }
}