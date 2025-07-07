abstract class Valuable
{
    public virtual string Name { get; set; } = "[No name]";
    public abstract double Value { get; }

    protected Valuable(string name)
    {
        Name = name;
    }
    
    // Implement the CompareTo method.
    
    public override string ToString()
    {
        return $"{Name} (Value: {Value})";
    }
}
