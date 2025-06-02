interface ITargetable
{
    int TakeDamage(Damage damage, ITargetable damageSource);
    void Heal(int amount);
    string Name { get; }
}