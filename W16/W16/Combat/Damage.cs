enum DamageTypes
{
    Physical,
    Fire,
    Cold,
    Lightning,
}

class Damage
{
    public DamageTypes Type { get; set; }
    public int Amount { get; set; }
    public bool IgnoreDefense { get; set; }
    public bool IgnoreResist { get; set; }
    public bool InstaKill { get; set; }

    public Damage(DamageTypes type, int amount)
        : this(type, amount, false , false, false) { }
    public Damage(DamageTypes type, int amount,
        bool ignoreDefense, bool ignoreResist, bool instaKill)
    {
        Type = type;
        Amount = amount;
        IgnoreDefense = ignoreDefense;
        IgnoreResist = ignoreResist;
        InstaKill = instaKill;
    }
}
