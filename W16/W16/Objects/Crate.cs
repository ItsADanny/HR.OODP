class Crate
{
    public string Name => "Crate";
    public bool IsOpen { get; private set; } = false;
    public Dictionary<ItemTypes, int> Inventory { get; }

    public Crate(Dictionary<ItemTypes, int> contents)
    {
        Inventory = contents;
    }

    public int TakeDamage(Damage damage, ITargetable damageSource)
    {
        if (damage.Amount <= 0)
            return 0;

        IsOpen = true;
        return damage.Amount;
    }

    public void Heal(int amount) { } // Crates cannot be healed


}
