public class Cat : Animal {
    public Cat(string name) : base(name) {
        Sound = "Meow!";
    }

    public void Climb() => Console.WriteLine($"{Name} climbs the curtains");
}