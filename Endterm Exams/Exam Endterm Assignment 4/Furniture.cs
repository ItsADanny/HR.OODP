// Do not modify this file

class Furniture
{
    public string Name { get; private set; }
    public int Volume { get; private set; }
    public int Value { get; private set; }
    public bool IsInsured { get; private set; }

    public Furniture(string name, int volume, int value, bool isInsured)
    {
        Name = name;
        Volume = volume;
        Value = value;
        IsInsured = isInsured;
    }

    public override string ToString()
    {
        return $"{Name, -8} - Volume: {Volume} m3, Value: {Value} Euro, Insured: {IsInsured}";
    }
}