// Make this class implement interface IEquatable<PaperCard>

class PaperCard : Valuable, ICreator
{
    public string CreatorName { get; }
    public string Series { get; }
    public int Rarity { get; }

    private double _condition = 1;
    public double Condition {
        get => _condition;
        set => _condition = Math.Clamp(value, 0, 1);
    }

    public override double Value => Condition * Rarity;

    public PaperCard(string name, string series, int rarity, string creatorName)
        : base(name)
    {
        Series = series;
        Rarity = rarity;
        CreatorName = creatorName;
    }

    /*
    Implement method Equals with a PaperCard as its parameter.
    Also implement method Equals with a parameter of type object.
    Additionally, implement the == and the != operator.
    */
    
    public override string ToString()
    {
        return $"{Name} ({Series}) (Rarity: {Rarity}) (Value: {Value})";
    }
}
