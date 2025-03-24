public class Pedestrian : Person, ICommute
{
    public Pedestrian(string name) : base(name) { }

    public void Move(int amount) => Console.WriteLine($"Walked {amount} kms");
}