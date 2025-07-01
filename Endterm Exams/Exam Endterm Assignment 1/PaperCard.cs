// Make this class implement interface IEquatable<PaperCard>

class PaperCard : Valuable, ICreator, IEquatable<PaperCard>
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

    public bool Equals(PaperCard other) {
         if (other is null) return false;
        //The PaperCards are considered equal to each other if their Name, Condition, Series and Rarity have the same values.
        return Name == other.Name && Condition == other.Condition && Series == other.Series && Rarity == other.Rarity;
    }

    public override bool Equals(object obj) {
         return Equals(obj as PaperCard);
     }

    public static bool operator == (PaperCard? item1, PaperCard? item2) {
        if (item1 is null && item2 is null) return true;
        if (item1 is null && item2 is not null || item1 is not null && item2 is null) return false;
        return item1.Name == item2.Name && item1.Condition == item2.Condition && item1.Series == item2.Series && item1.Rarity == item2.Rarity;
     }

    public static bool operator != (PaperCard? item1, PaperCard? item2) {
        if (item1 is null && item2 is null) return false;
        if (item1 is null && item2 is not null || item1 is not null && item2 is null) return true;
        return item1.Name != item2.Name && item1.Condition != item2.Condition && item1.Series != item2.Series && item1.Rarity != item2.Rarity;
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