abstract class Monster : Fighter
{
    public virtual bool IsBoss => false;
    public virtual bool IsUndead => false;

    public Monster(string name, int maxHP,
        int attackPower, int defense)
        : base(name, maxHP, attackPower, defense) { }

    public static Monster Resurrect(Monster monster)
    {
        Type monsterType = monster.GetType();

        // Get the default constructor of the monster type
        var constructor = monsterType.GetConstructor(Type.EmptyTypes);
        if (constructor != null)
        {
            return (Monster)constructor.Invoke(null);
        }

        throw new InvalidOperationException("Cannot resurrect monster of type: " + monsterType.Name);
    }
}
