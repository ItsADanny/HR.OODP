abstract class Valuable : IComparable<Valuable>
{
    public virtual string Name { get; set; } = "[No name]";
    public abstract double Value { get; }

    protected Valuable(string name)
    {
        Name = name;
    }
    
    // Implement the CompareTo method.
    public int CompareTo(Valuable? other) {
        if (other is null) return 1;
        int result = Name.CompareTo(other.Name);
        // return result != 0 ? result : other.Value.CompareTo(Value);
        return result != 0 ? result : Value.CompareTo(other.Value);
    }
    
    public override string ToString()
    {
        return $"{Name} (Value: {Value})";
    }
}