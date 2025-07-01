// Do not modify this file

class Painting: Valuable, ICreator
{    
    public override double Value { get; }
    public string CreatorName { get; }

    public Painting(string name, double value, string creatorName)
        : base(name)
    {
        Value = value;
        CreatorName = creatorName;
    }
}